using System;
using SQLite;

namespace Scouting
{
	public class Status
	{
		public Status ()
		{
		}
		[PrimaryKey,AutoIncrement]
		public int Id {get;set;}
		public int UserId {get;set;}
		public DateTime? DateCompleted {get;set;}

	}
}

