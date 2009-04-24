using System;
using System.Windows.Forms;

namespace ColumnDepence
{
	/// <summary>
	/// This class represent Custom ToolStripItem with Label and 
	/// TextBox.
	/// </summary>
	public partial class UserControlToolStripLabelTextBox : ToolStripControlHost
	{		

		public UserControlToolStripLabelTextBox()
			: base(new CustomControlLabelTextBox())
		{
			InitializeComponent();			
			ValueType = typeof (string);
		}

		/// <summary>
		/// Gets boolean. True if TextBox is not empty.
		/// </summary>
		public bool HasValue
		{
			get { return Text != ""; }
		}

		/// <summary>
		/// Gets ToolStripItem internal control
		/// </summary>
		public CustomControlLabelTextBox CustomControlLabelTextBox {
			get { return Control as CustomControlLabelTextBox; }
		}		


		/// <summary>
		/// Gets and Sets Labels text
		/// </summary>
		public string LabelText
		{
			get
			{
				return CustomControlLabelTextBox != null ? CustomControlLabelTextBox.LabelText : "";
			}
			set
			{
				if (CustomControlLabelTextBox != null)
					CustomControlLabelTextBox.LabelText = value;
			}
		}

		/// <summary>
		/// Gets underlaying TextBox
		/// </summary>
		public TextBox TextBox
		{
			get
			{
				return CustomControlLabelTextBox != null ? CustomControlLabelTextBox.TextBox : null;
			}
		}
		
		/// <summary>
		/// Gets and Sets underlaying TextBox Text.
		/// </summary>
		public new string Text
		{
			get
			{
				return TextBox == null ? "": this.TextBox.Text;
			}
			set { if (TextBox != null) TextBox.Text = value; }
		}

		/// <summary>
		/// Value that shlould be writen in TextBox
		/// </summary>
		public Type ValueType
		{
			get
			{
				return CustomControlLabelTextBox != null ? CustomControlLabelTextBox.ValueType : typeof (string);
			}
			set
			{
				if (CustomControlLabelTextBox != null) CustomControlLabelTextBox.ValueType = value;
			}
		}
		
	}
}
