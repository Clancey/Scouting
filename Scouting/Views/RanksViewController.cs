using System;
using MonoTouch.Dialog;

namespace Scouting
{
	public class RanksViewController : BaseViewController
	{
		public RanksViewController () : base(MonoTouch.UIKit.UITableViewStyle.Grouped)
		{
			this.Title = "Ranks";
		}
		public override MonoTouch.Dialog.RootElement CreateRoot ()
		{
			var section = new Section();
			foreach(var rank in Database.GetRanks())
			{
				var theRank = rank;
				section.Add(new StringElement(rank.Name, delegate{
					this.ActivateController(new RequirementsViewController(theRank));
				}));
			}
			return new RootElement("Ranks"){
				section
			};
		}
	}
}

