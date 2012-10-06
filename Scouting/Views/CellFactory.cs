using System;
using MonoTouch.UIKit;

namespace Scouting
{
	public static class CellFactory
	{
		public static UITableViewCell GetCell(this Requirement requirement,UITableView tableview, RequirementStatus status)
		{
			return new UITableViewCell(UITableViewCellStyle.Default,"requirement");
		}
	}
}

