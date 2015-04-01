namespace hackovic.DbInfo.DbInfo
{
	public class SpInfo
	{
		public string SpName { get; set; }

		public DataTableSpParameterInfo ParameterInfo { get; set; }
		public DataTableSpDependencies Dependencies { get; set; }

		public SpInfo()
		{
			ParameterInfo = new DataTableSpParameterInfo();
			Dependencies = new DataTableSpDependencies();
		}

		public SpInfo(string spName):this()
		{
			SpName = spName;
			LoadSpInfo();
		}

		public void LoadSpInfo()
		{
			ParameterInfo.FillParameters(SpName);
			Dependencies.FillDependecies(SpName);
		}

	}
}
