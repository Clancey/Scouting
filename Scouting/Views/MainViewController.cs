using System;
using MonoTouch.Dialog;

namespace Scouting
{
	public class MainViewController : BaseViewController
	{
		public MainViewController () : base(MonoTouch.UIKit.UITableViewStyle.Grouped,false)
		{
		
		}
		public override RootElement CreateRoot ()
		{
			return new RootElement("Main Menu")
			{
				new Section("Troop 12345")
				{
					new StringElement("Weblos",delegate{
						var weblows = Database.GetScouts(5);
						this.ActivateController(new ScoutViewController(weblows[0]));
					}),
				},
				new Section()
				{
					new StringElement("Ranks", delegate {
						this.ActivateController(new RanksViewController());
					}),
				}
			};
		}

	}
}

