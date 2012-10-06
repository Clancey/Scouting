using System;
using SQLite;

namespace Scouting
{
	public class Rank
	{
		public Rank ()
		{
		}
		[AutoIncrement,PrimaryKey]
		public int Id {get;set;}
		public int SortOrder {get;set;}
		public string Name {get;set;}
		public int RequiredRank {get;set;}
		public bool Achievable {get;set;}
		public int StartAge {get;set;}
		public int EndAge {get;set;}
	}
}

