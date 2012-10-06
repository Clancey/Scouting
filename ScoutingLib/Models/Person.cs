using System;
using SQLite;

namespace Scouting
{
	public class Person
	{
		public enum PersonType {
			Scout,
			Parent,
			Leader,
		}
		public Person ()
		{
		}
		[PrimaryKey,AutoIncrement]
		public int Id {get;set;}
		public string FirstName {get;set;}
		public string LastName {get;set;}
		public int CurrentRankId {get;set;}
		public int RankInProgess {get;set;}
		public PersonType Type {get;set;}
		public int AssignedGroup {get;set;}
		public DateTime Birthday {get;set;}

		public string FullName()
		{
			return string.Format("{0}, {1}", LastName,FirstName);
		}
	}
}

