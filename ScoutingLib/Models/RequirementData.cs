using System;
using SQLite;

namespace Scouting
{
	public class RequirementData
	{
		public RequirementData ()
		{
		}
		[PrimaryKey,AutoIncrement]
		public int Id{get;set;}
		public int Order {get;set;}
		public int RequirementId {get;set;}
		public string Title {get;set;}
		public string Description {get;set;}
	}
}

