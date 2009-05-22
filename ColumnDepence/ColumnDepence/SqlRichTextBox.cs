using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ColumnDepence
{
	public class SqlRichTextBox : RichTextBox
	{
		public event EventHandler FindTextCompleted;
		public event EventHandler SyntaxHighlightCompleted;

		#region Private Variables

		private readonly Dictionary<int, int> m_FindedTextIndex;
		private int m_CurrentSelectionIndex;

		private readonly BackgroundWorker m_BackgroundWorkerSyntaxHighlight;
		private readonly BackgroundWorker m_BackgroundWorkerFindText;
		private readonly String[] m_SqlKeywords = {
		                                          	"and", "select", "where", "from", "into", "insert", "or", "output",
		                                          	"exists", "not", "update", "values", "delete", "inner", "left", "join",
		                                          	"order", "by", "having", "out", "in", "asc", "desc"
		                                          };

		private readonly String[] m_SqlBasicKeywords = {
		                                               	"end", "begin", "if", "goto", "set", "execute", "as", "else",
		                                               	"declare", "null", "case", "then", "on", "exec", "use", "return",
		                                               	"create", "table", "transaction", "commit", "rollback", "drop", "go",
		                                               	"while", "next", "open", "for", "cursor", "fetch", "close", "cast",
		                                               	"primary", "key", "rowcount", "procedure", "nocount","index"
		                                               };

		private readonly String[] m_SqlTypes = {
		                                       	"int", "nvarchar", "nchar", "bit", "datetime", "date", "char", "collate",
		                                       	"float", "xml"
		                                       };

		private readonly Font m_FontBold;

		#endregion

		public SqlRichTextBox()
		{
			m_BackgroundWorkerSyntaxHighlight = new BackgroundWorker();
			m_BackgroundWorkerSyntaxHighlight.DoWork += BackgroundWorkerSyntaxHighlightDoWork;
			m_BackgroundWorkerSyntaxHighlight.RunWorkerCompleted += BackgroundWorkerSyntaxHighlightRunWorkerCompleted;
			m_BackgroundWorkerSyntaxHighlight.WorkerSupportsCancellation = true;
			
			m_BackgroundWorkerFindText = new BackgroundWorker();
			m_BackgroundWorkerFindText.DoWork += BackgroundWorkerFindTextDoWork;
			m_BackgroundWorkerFindText.RunWorkerCompleted += BackgroundWorkerFindTextRunWorkerCompleted;
			m_BackgroundWorkerFindText.WorkerSupportsCancellation = true;

			m_FontBold = new Font("Courier New", 10, FontStyle.Bold);
			m_FindedTextIndex = new Dictionary<int, int>();
			CurrentSelectionIndex = 0;
			LastFindIndex = 0;			
		}

		private void InvokeSyntaxHighlightCompleted()
		{
			if (SyntaxHighlightCompleted != null)
				SyntaxHighlightCompleted(this, EventArgs.Empty);
		}

		private void InvokeFindTextCompleted()
		{
			if (FindTextCompleted != null)
				FindTextCompleted(this, EventArgs.Empty);
		}

		#region SyntaxHighLight
		void BackgroundWorkerSyntaxHighlightRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ResumeLayout();
			InvokeSyntaxHighlightCompleted();
		}


		public void ApplySyntaxHighlighting()
		{
			if (m_BackgroundWorkerSyntaxHighlight.IsBusy) return;

			m_BackgroundWorkerSyntaxHighlight.RunWorkerAsync();
		}

		private void BackgroundWorkerSyntaxHighlightDoWork(object sender, DoWorkEventArgs e)
		{
			SyntaxHighLightSafe();
		}

		private void SyntaxHighLightSafe()
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(SyntaxHighLight));
			}
			else
			{
				SyntaxHighLight();
			}
		}


		/// <summary>
		/// Apply syntax highlighting on SP's definition
		/// </summary>
		private void SyntaxHighLight()
		{
			SuspendLayout();
			/// 
			/// Backup the users current selection point.
			/// 
			int selectionStart = SelectionStart;
			int selectionLength = SelectionLength;
			/// 
			/// Split the text into tokens.
			/// 
			Regex r = new Regex(@"(/\*+(?:[^*/][.]*)*\*+/)|([ \t{}();\n,])|(--.*\n)",
								RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
			string[] tokens = r.Split(Text);
			int index = 0;

			Font fontRegular = new Font("Courier New", 10, FontStyle.Regular);
			Font fontForComments = new Font("Arial", 10, FontStyle.Regular);

			foreach (string token in tokens)
			{
				/// Set the token's default color and font.
				SelectionStart = index;
				SelectionLength = token.Length;
				SelectionColor = Color.Black;
				SelectionFont = fontRegular;

				/// 
				/// One line comments
				/// 
				if (token.StartsWith("--"))
				{
					SelectionColor = Color.Gray;
					SelectionFont = fontForComments;
					index += token.Length;
					continue;
				}
				/// 
				/// Multi line comments
				/// 
				if (token.StartsWith("/*"))
				{
					SelectionColor = Color.Gray;
					SelectionFont = fontForComments;
					index += token.Length;
					continue;
				}
				/// 
				/// Variable
				/// 
				if (token.StartsWith("@"))
				{
					SelectionColor = Color.DarkBlue;
					SelectionFont = m_FontBold;
					index += token.Length;
					continue;
				}
				/// 
				/// Check whether the token is a keyword. 
				/// 
				bool colored = SetColorOnWord(token, m_SqlKeywords, Color.Blue);
				/// 
				/// Check whether the token is a types. 
				/// 
				if (!colored)
					colored = SetColorOnWord(token, m_SqlTypes, Color.DarkGreen);
				/// 
				/// SQL keywords
				/// 
				if (!colored)
					SetColorOnWord(token, m_SqlBasicKeywords, Color.Green);

				index += token.Length;
			}
			///
			///  Restore the users current selection point. 
			/// 
			SelectionStart = selectionStart;
			SelectionLength = selectionLength;
		}

		private bool SetColorOnWord(string token, string[] keywords, Color color)
		{
			for (int i = 0; i < keywords.Length; i++)
			{
				if (keywords[i] != token.ToLower()) continue;

				SelectionColor = color;
				SelectionFont = m_FontBold;
				return true;
			}

			return false;
		}
		#endregion SyntaxHighLight


		#region Find Text
		public void FindText(string searchString)
		{
			m_BackgroundWorkerFindText.CancelAsync();

			SelectAll();
			SelectionBackColor = Color.White;

			Application.DoEvents();

			if (searchString.Trim().Length < 2)
			{
				LastFindIndex = 0;
				return;
			}

			if (m_BackgroundWorkerFindText.IsBusy == false)
				m_BackgroundWorkerFindText.RunWorkerAsync(searchString);

		}


		private int LastFindIndex { get; set; }
		private void BackgroundWorkerFindTextDoWork(object sender, DoWorkEventArgs e)
		{
			m_FindedTextIndex.Clear();
			CurrentSelectionIndex = 0;

			if (InvokeRequired)
			{
				Invoke(new FindTextDelegate(FindText), new object[] { e.Argument.ToString(), 0, true, sender as BackgroundWorker, e });
			}
			else
			{
				FindText(e.Argument.ToString(), 0, true, sender as BackgroundWorker, e);
			}
		}
		void BackgroundWorkerFindTextRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			InvokeFindTextCompleted();
		}
		
		private delegate void FindTextDelegate(string searchString, int startingFrom, bool scrollToString, BackgroundWorker worker, DoWorkEventArgs e);

		private void FindText(string searchString, int startingFrom, bool scrollToString, BackgroundWorker worker, DoWorkEventArgs e)
		{
			try
			{
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				LastFindIndex = Find(searchString, startingFrom, RichTextBoxFinds.None);

				/// Add color
				if (LastFindIndex >= 0)
				{
					SelectionStart = LastFindIndex;
					SelectionLength = searchString.Length;
					SelectionBackColor = Color.LightGreen;
					if (scrollToString)
						ScrollToCaret();

					m_FindedTextIndex.Add(m_FindedTextIndex.Count, LastFindIndex);
					FindText(searchString, LastFindIndex + 1, false, worker, e);
				}
			}
			catch { }
		}
		#endregion Find Text

		#region Move to next selected


		private int CurrentSelectionIndex
		{
			get { return m_CurrentSelectionIndex; }
			set
			{
				m_CurrentSelectionIndex = value;
				if (m_CurrentSelectionIndex >= m_FindedTextIndex.Count)
					m_CurrentSelectionIndex = m_FindedTextIndex.Count - 1;

				if (m_CurrentSelectionIndex < 0)
					m_CurrentSelectionIndex = 0;
			}
		}

		public void ScrollToNext()
		{
			if (m_FindedTextIndex == null || m_FindedTextIndex.Count == 0 || CurrentSelectionIndex >= m_FindedTextIndex.Count || CurrentSelectionIndex < 0)
				return;

			SelectionStart = m_FindedTextIndex[CurrentSelectionIndex++];
			ScrollToCaret();
		}
		public void ScrollToPrevious()
		{
			if (m_FindedTextIndex == null || m_FindedTextIndex.Count == 0 || CurrentSelectionIndex >= m_FindedTextIndex.Count || CurrentSelectionIndex < 0)
				return;

			SelectionStart = m_FindedTextIndex[CurrentSelectionIndex--];
			ScrollToCaret();
		}

		public bool IsTextFounded
		{
			get
			{
				return (m_FindedTextIndex.Count > 0);
			}
		}

		public bool PositionedAtFirst
		{
			get
			{
				return (CurrentSelectionIndex == 0);
			}
		}
		public bool PositionedAtLast
		{
			get
			{
				return (CurrentSelectionIndex == (m_FindedTextIndex.Count - 1));
			}
		}

		#endregion Move to next selected
	}
}
