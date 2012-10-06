using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace Scouting
{
	public class RequirementsViewController : BaseViewController
	{
		public Rank Rank;
		public RequirementsViewController (Rank rank) : base (UITableViewStyle.Grouped)
		{
			Rank = rank;
			this.Title = Rank.Name;
		}
		public override MonoTouch.Dialog.RootElement CreateRoot ()
		{
			var section = new Section();
			foreach(var req in Database.GetRequirements(Rank.Id, 0))
			{
				section.Add(new StringElement(req.Display));
			}
			return new RootElement(Rank.Name){section};
		}
	}
}

