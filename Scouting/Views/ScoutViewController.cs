using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Collections.Generic;


namespace Scouting
{
	public class ScoutViewController : BaseViewController
	{
		Person Person;
		Requirement[] Requirements;
		Dictionary<int,RequirementStatus> RequirementStatus;
		public int Rank;
		public ScoutViewController (Person person) : base(UITableViewStyle.Grouped)
		{
			Person = person;
			Rank = person.RankInProgess;
			this.Title = person.FullName();
		}
		public override RootElement CreateRoot ()
		{
			Requirements = Database.GetRequirements(Rank,0).ToArray();
			RequirementStatus = Database.GetRequirementsStatus(Rank,Person.Id);

			var section = new Section("RankImage");
			foreach(var req in Requirements)
				section.Add(ElementForRequirement(req));
			return new RootElement(Person.FullName()){
				section
			};
		}

		public Element ElementForRequirement(Requirement req)
		{
			var status = RequirementStatus.ContainsKey(req.Id)? RequirementStatus[req.Id] : new RequirementStatus(){UserId = Person.Id,RequirementId = req.Id};
			BooleanElement element = new BooleanElement(req.Display,status.DateCompleted.HasValue);
			element.ValueChanged += delegate {
				//todo, save
			};
			return element;
		}
	}
}

