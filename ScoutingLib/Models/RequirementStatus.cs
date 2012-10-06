using System;
using SQLite;

namespace Scouting
{
	public class RequirementStatus : Status
	{
		public RequirementStatus ()
		{
		}
		public int RequirementId {get;set;}
		public int RankId {get;set;}
		public string Answer {get;set;}
		public string Noted {get;set;}
	}
}

