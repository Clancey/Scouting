using System;
using SQLite;

namespace Scouting
{
	public class Requirement
	{
		public Requirement ()
		{
		}
		[PrimaryKey,AutoIncrement]
		[Indexed]
		public int Id{get;set;}
		[Indexed]
		public int ParentId {get;set;}
		[Indexed]
		public int RankId {get;set;}
		public int Level {get;set;}
		public int BadgeId {get;set;}
		public int BadgeGroupId {get;set;}
		public int SortOrder{get;set;}
		public string Designation {get;set;}
		public string Name{get;set;}
		public int ChildrenCount {get;set;}
		public int RequiredChildrenCount {get;set;}
		public string GetIndent()
		{
			return "".PadLeft((Level -1) * 4);
		}
		[Ignore]
		public string Display {get {return string.Format("{0}{1}  {2}",GetIndent(),Designation,Name);}}

	}
}

