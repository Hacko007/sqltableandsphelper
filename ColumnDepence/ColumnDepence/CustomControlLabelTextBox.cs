using System;
using System.Drawing;
using System.Windows.Forms;

namespace hackovic.DbInfo
{
	public partial class CustomControlLabelTextBox : UserControl
	{
		public CustomControlLabelTextBox()
		{
			InitializeComponent();
			ValueType = typeof(string);			
			m_TextBox.TextChanged += TextBoxTextChanged;
		}

		public Type ValueType { get; set; }

		public TextBox TextBox
		{
			get { return m_TextBox; }
		}

		public string LabelText
		{
			get { return m_Label.Text; }
			set { 
				m_Label.Text = value;
				Graphics g = m_Label.CreateGraphics();
				SizeF size = g.MeasureString(value, m_Label.Font);

				m_Label.Width = (int)size.Width + 10;

				m_TextBox.Location = new Point(m_Label.Width , 0);
				m_TextBox.Width = Width - m_Label.Width;
			}
		}
	
		void TextBoxTextChanged(object sender, EventArgs e)
		{
			if (m_TextBox.Text == "") return;

			if (ValueType == typeof(int))				
			{
				int myInt;
				if( int.TryParse( TextBox.Text, out myInt) == false)
				{
					m_TextBox.Text = m_TextBox.Text.Substring(0, m_TextBox.Text.Length - 1);
				}
				
			}
		}


	}
}
