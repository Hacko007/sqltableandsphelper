using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace ColumnDepence
{
	/// <summary>
	/// Save last used strings in StringCollection. 
	/// </summary>
	public class StackSetting
	{

		/// <summary>
		/// Add or move value on/to top of stack.		
		/// </summary>
		/// <param name="value"></param>
		public void AddValue(string value)
		{
			ItemName = value;
			UpdateTableHistory();
		}

		public string[] DataSource { get; set; }

		private int _max_size = 100;
		
		/// <summary>
		/// Gets or sets Max count of unique elements in stack
		/// </summary>
		public int MaxSize {
			get { return _max_size; }
			set { _max_size = value; }
		}

    


		private string m_SettingName = null;

		/// <summary>
		/// Gets or Sets which Setting Name to use from 
		/// Properties.Settings.Default.
		/// </summary>
		/// <remarks>SettingName must exists in Properties.Settings.Default </remarks>
		public string SettingName
		{
			get { return m_SettingName; }

			set
			{
				m_SettingName = value;
				FillTableHistoryList();
			}
		}


		private string ItemName { get; set; }

		private Queue<string> m_TableHistoryQueue = new Queue<string>();


		private void UpdateTableHistory()
		{
			if (SettingName == null) return;

			Properties.Settings.Default[SettingName] = new StringCollection();

			try
			{
				/// 
				/// Remove table from queue if in queue
				/// 
				m_TableHistoryQueue.Enqueue(this.ItemName);
				var hist = m_TableHistoryQueue.ToArray().Where(tab => tab != this.ItemName);
				
				m_TableHistoryQueue.Clear();
				if (hist != null && hist.Count() > 0)
				{					
					foreach (string tab in hist)
					{
						if (!m_TableHistoryQueue.Contains(tab))
							m_TableHistoryQueue.Enqueue(tab);
					}
				}

				/// 
				/// Add table on top
				/// 
				m_TableHistoryQueue.Enqueue(this.ItemName);

				((StringCollection)Properties.Settings.Default[SettingName]).AddRange(m_TableHistoryQueue.ToArray());
				Properties.Settings.Default.Save();
				FillTableHistoryList();
			}
			catch { }

		}

		public void FillTableHistoryList()
		{
			if (SettingName == null || Properties.Settings.Default[SettingName] == null) return;

			StringCollection collection = (StringCollection)Properties.Settings.Default[SettingName];

			m_TableHistoryQueue = new Queue<string>();
			int c = 0;

			for (int i = collection.Count - 1; i > -1; i--)
			{
				string tab = collection[i];
				if (!m_TableHistoryQueue.Contains(tab))
				{
					m_TableHistoryQueue.Enqueue(tab);
					if (c >= MaxSize) break; c++;
				}
			}

			StringCollection _sc = new StringCollection();
			_sc.AddRange( m_TableHistoryQueue.ToArray());
			DataSource = m_TableHistoryQueue.ToArray();
		}




		internal void RemoveValue(string value)
		{
			try
			{
				((StringCollection)Properties.Settings.Default[SettingName]).Remove(value);
				Properties.Settings.Default.Save();
				FillTableHistoryList();
			}
			catch { }
		}

		internal void Clear()
		{
			Properties.Settings.Default[SettingName] = new StringCollection();
			Properties.Settings.Default.Save();
			FillTableHistoryList();
		}
	}
}
