using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ColumnDepence.DbInfo;

namespace ColumnDepence
{
	public enum FullNameListType
	{
		TableNames,
		SPNames
	}

	public partial class UserControlFullNameList : UserControl
	{
		public event EventHandler NameSelected;

		public UserControlFullNameList()
		{
			InitializeComponent();
			FullNameListType = FullNameListType.TableNames;
		}

		#region Properties

		public FullNameListType  FullNameListType  { get; set; }
		public string SelectedName { get; set; }
		public List<string> StringList { get; set; }
		
		#endregion Properties

		private void OpenFormFullNameList()
		{
			if (StringList == null)
			{
				InitStringList();
			}
			FormFullNameList form = new FormFullNameList();
			form.StringList = StringList;
			form.NameSelected += delegate(object obj, EventArgs er)
			{
				SelectedName = form.SelectedName;
				RaiseNameSelected();
			};
			form.ShowDialog(this.ParentForm);			
		}

		private void InitStringList()
		{

			string sqlStr;
			if (FullNameListType == FullNameListType.TableNames)
			{
				sqlStr = @"SELECT DISTINCT TB.TABLE_NAME As Name FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TB  ORDER BY TB.TABLE_NAME";
			}
			else
			{
				sqlStr = "SELECT ROUTINE_NAME as Name FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE='PROCEDURE' ORDER BY ROUTINE_NAME";
			}
			/// 
			/// Table auto complete
			/// 

			DataTable dt = TableInfo.FillDataTable("Names", sqlStr, new DataTable());

			StringList = new List<string>();
			foreach (DataRow row in dt.Rows)
			{
				try
				{
					StringList.Add(row[0].ToString());
				}
				catch { }
			}

		}

		private void RaiseNameSelected() {
			if (NameSelected != null )
			{
				NameSelected(this, EventArgs.Empty);
			}
		}	
		
		private void ButtonOpen_Click(object sender, EventArgs e)
		{
			OpenFormFullNameList();
		}

	}
}
