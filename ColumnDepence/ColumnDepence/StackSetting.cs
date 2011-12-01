using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using ColumnDepence.Properties;

namespace ColumnDepence
{
  /// <summary>
  /// Save last used strings in StringCollection. 
  /// </summary>
  public class StackSetting
  {
    public const string StackConnectionHistory = "ConnectionHistory";
    public const string StackDatabaseHistory = "DatabaseHistory";


    private readonly Dictionary<int,string> m_ValueDictionary ;
    private string m_SettingName;


    public StackSetting()
    {
      MaxSize = 20;
      m_ValueDictionary = new Dictionary<int, string>();
      DataSource = new string[]{};
    }

    
    /// <summary>
    /// Gets or sets Max count of unique elements in stack
    /// </summary>
    public int MaxSize { get; set; }

    public string[] DataSource { get; set; }

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

    private StringCollection SettingStringCollection
    {
      get
      {
        if (Settings.Default[SettingName] == null)
          Settings.Default[SettingName] = new StringCollection();
                
        return (StringCollection) Settings.Default[SettingName];
      }
    }

    /// <summary>
    /// Clear and save all elements from history
    /// </summary>
    internal void Clear()
    {
      Settings.Default[SettingName] = new StringCollection();
      Settings.Default.Save();
      FillTableHistoryList();
    }

    /// <summary>
    /// Add or move value to top of stack.		
    /// </summary>
    /// <param name="value"></param>
    public void AddValue(string value)
    {
      AddFirst(value);
    }

    /// <summary>
    /// Remove by zero based index
    /// </summary>
    /// <param name="index"></param>
    internal void Remove(int index)
    {
      try
      {
        if (0 > index || SettingStringCollection.Count <= index)
          return;

        SettingStringCollection.RemoveAt(index);
        Settings.Default.Save();
        FillTableHistoryList();
      }
      catch { }
    }

    /// <summary>
    /// Remove this value from history
    /// </summary>
    /// <param name="value"></param>
    internal void Remove(string value)
    {
      try
      {
        if(SettingStringCollection.Contains(value)== false) 
          return;

        SettingStringCollection.Remove(value);
        Settings.Default.Save();
        FillTableHistoryList();
      }
      catch { }
    }


    #region Private methods
    
    private void AddFirst(string value)
    {			
      List<string> values = m_ValueDictionary.Values.ToList();
      int index = 1;
      m_ValueDictionary.Clear();
      
      m_ValueDictionary.Add(index, value);
      index++;

      foreach (string item in values)
      {
        if (m_ValueDictionary.ContainsValue(item)) continue;

        m_ValueDictionary.Add(index, item);
        index++;

        if (index >= MaxSize) break;
      }
      UpdateTableHistory();		
    }

    private void FillTableHistoryList()
    {
      try
      {
        if (SettingName == null) return;
        if (Settings.Default[SettingName] == null) return;

        StringCollection collection = (StringCollection) Settings.Default[SettingName];
        m_ValueDictionary.Clear();
        foreach (string value in collection)
        {
          m_ValueDictionary.Add(m_ValueDictionary.Count , value );
        }

        DataSource = m_ValueDictionary.Values.ToArray();
      }catch
      {
      }
    }

    private void UpdateTableHistory()
    {
      if (SettingName == null) return;

      Settings.Default[SettingName] = new StringCollection();

      try
      {
        ((StringCollection)Settings.Default[SettingName]).AddRange(m_ValueDictionary.Values.ToArray());
        Settings.Default.Save();
        FillTableHistoryList();
      }
      catch { }

    }

    #endregion Private methods

  }
}
