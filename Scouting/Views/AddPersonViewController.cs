using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace Scouting
{
	public class AddPersonViewController : BaseViewController
	{
		public bool CanSkip = true;
		public AddPersonViewController (bool canSkip) : base (UITableViewStyle.Grouped)
		{
			CanSkip = canSkip;
		}
		Person.PersonType PersonType;

		public override RootElement CreateRoot ()
		{
			var section = new Section("Are you a"){
				new StringElement("Scout",delegate{
					PersonType = Person.PersonType.Scout;
				}),
				new StringElement("Parent", delegate{
					PersonType = Person.PersonType.Parent;
				}),
				new StringElement("Scout Leader",delegate{
					PersonType = Person.PersonType.Leader;
				}),
			};
			return new RootElement("Setup"){
				section
			};
		}

	}
}

