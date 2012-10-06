//
// Copyright 2010 Miguel de Icaza
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Scouting
{
	public class Database : SQLiteConnection {
		public readonly static string BaseDir = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "..");
		internal Database (string file, bool islocal) : base (file,true)
		{
			if (islocal) {
				CreateTable<ContactInfo> ();
				CreateTable<Person> ();
				CreateTable<RankStatus>();
				CreateTable<RequirementStatus>();
				CreateTable<ScoutParentGroup>();
			} else {
				CreateTable<Rank> ();
				CreateTable<Requirement> ();
				CreateTable<RequirementData> ();
			}
		}

		static Database ()
		{
			// For debugging
			var db = BaseDir + "/Documents/requirements.db";
			//System.IO.File.Delete (tweetsdb);
			Main = new Database (db,false);
			Local = new Database(BaseDir + "/Documents/local.db",true);
		}
		
		static public Database Main { get; private set; }
		static public Database Local { get; private set; }

		public static Task<List<Person>> GetScoutsAsync()
		{
			return Task.Factory.StartNew(delegate{
				return GetScouts();
			});
		}
		public static List<Person> GetScouts()
		{
			return Local.Table<Person>().Where(x=> x.Type == Person.PersonType.Scout).ToList();
		}
		public static Task<List<Rank>> GetRanksAsync()
		{
			return Task.Factory.StartNew(delegate{
				return GetRanks();
			});
		}
		public static List<Rank> GetRanks()
		{
			return Main.Table<Rank>().Where(x=> x.Achievable == true).OrderBy(x=> x.SortOrder).ToList();
		}

		public static Task<List<Requirement>> GetRequirementsAsync(int rankId,int parent)
		{
			return Task.Factory.StartNew(delegate {
				return GetRequirements(rankId,parent);
			});
		}
		public static List<Requirement> GetRequirements(int rankId,int parent)
		{
			return Main.Table<Requirement>().Where(x=> x.RankId == rankId && x.ParentId == parent).OrderBy(x=> x.SortOrder).ToList();
		}
		public static Dictionary<int,RequirementData> GetRequirementsData(int rankId)
		{
			return Local.Query<RequirementData>("select rd.* from RequirementData rd inner join Requirement r on r.Id = rd.RequirementId and r.RankId = ?",rankId).ToDictionary(x=> x.RequirementId,x=> x);
		}
		public static Dictionary<int,RequirementStatus> GetRequirementsStatus(int rankId, int personId)
		{
			return Local.Table<RequirementStatus>().Where(x=> x.RankId == rankId && x.UserId == personId).ToDictionary(x=> x.RequirementId,x=> x);
		}
		public static List<Person> GetScouts(int groupId)
		{
			return Local.Table<Person>().Where(x=> x.Type == Person.PersonType.Scout && x.AssignedGroup == groupId).ToList();
		}
	}
}

