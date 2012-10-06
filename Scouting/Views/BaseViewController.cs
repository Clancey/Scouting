using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using System.Threading.Tasks;

namespace Scouting
{
	public class BaseViewController : DialogViewController
	{
		public BaseViewController (UITableViewStyle style, bool pushing = true) : base(style,null,pushing)
		{

		}
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			ShowLoading();
			Task<RootElement>.Factory.StartNew(delegate{
				return CreateRoot();
			}).ContinueWith(task=>{
				Root = task.Result;
				HideLoading();
			},TaskScheduler.FromCurrentSynchronizationContext());
		}
		public void ShowLoading()
		{

		}
		public void HideLoading()
		{

		}

		public virtual RootElement CreateRoot()
		{
			return new RootElement("");
		}
	}
}

