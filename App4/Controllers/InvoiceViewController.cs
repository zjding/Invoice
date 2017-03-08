using Foundation;
using System;
using UIKit;
using BLKFlexibleHeightBarDemo;
using CoreGraphics;
using Invoice_Model;

namespace App4
{
    public partial class InvoiceViewController : UIViewController
	{
		SquareCashStyleBar _headerBar;

		public Invoice invoice;

		public InvoiceViewController(IntPtr handle) : base(handle)
		{
			invoice = new Invoice();
			invoice.name = "#2";
			invoice.issueDate = DateTime.Now.ToString("MMMMM dd, yyyy");
			invoice.dueTerm = "30 days";
			invoice.dueDate = DateTime.Now.AddDays(30).ToString("MMMMM dd, yyyy");


		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.NavigationController.SetNavigationBarHidden(true, false);

			_headerBar.numberLabel.Text = invoice.name;
			_headerBar.dateLabel.Text = invoice.issueDate;
			_headerBar.dueLabel.Text = "Due: " + invoice.dueTerm;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_headerBar = new SquareCashStyleBar(new CGRect(0f, 0f, View.Frame.Width, 50f));

			_headerBar.invoiceName = invoice.name;
			_headerBar.invoiceIssueDate = invoice.issueDate;
			_headerBar.invoiceDueTerm = invoice.dueTerm;
			_headerBar.ConfigureBar();


			SetNeedsStatusBarAppearanceUpdate();




			var behaviorDefiner = new SquareCashStyleBehaviorDefiner();
			behaviorDefiner.AddSnappingPositionProgress(0f, 0f, .5f);
			behaviorDefiner.AddSnappingPositionProgress(1f, .5f, 1f);
			behaviorDefiner.IsSnappingEnabled = true;
			behaviorDefiner.IsElasticMaximumHeightAtTop = true;
			tableView.Delegate = behaviorDefiner;
			_headerBar.BehaviorDefiner = behaviorDefiner;

			View.AddSubview(_headerBar);

			tableView.ContentInset = new UIEdgeInsets(_headerBar.MaximumBarHeight, 0f, 0f, 0f);

			var closeButton = new BLKFlexibleHeightBarSubviewUIButton();
			closeButton.Frame = new CGRect(0f, 0f, 30f, 30f);
			closeButton.TintColor = UIColor.White;
			closeButton.SetImage(UIImage.FromFile(@"Images/Multiply-50-white.png"), UIControlState.Normal);
			closeButton.AddTarget(CloseViewController, UIControlEvent.TouchUpInside);
			_headerBar.AddSubview(closeButton);

			var tapGesture = new UITapGestureRecognizer(tapHeaderBar);
			_headerBar.UserInteractionEnabled = true;
			_headerBar.AddGestureRecognizer(tapGesture);
		}

		void tapHeaderBar()
		{
			//UIAlertView alert = new UIAlertView()
			//{
			//	Title = "alert title",
			//	Message = "this is a simple alert"
			//};
			//alert.AddButton("OK");
			//alert.Show();

			UIStoryboard storyBoard = UIStoryboard.FromName("Main", null);

			InvoiceDateViewController invoiceDateVC = (InvoiceDateViewController)storyBoard.InstantiateViewController("invoiceDetailVC");
			invoiceDateVC.name = invoice.name;
			invoiceDateVC.issueDate = invoice.issueDate;
			invoiceDateVC.dueTerm = invoice.dueTerm;
			invoiceDateVC.dueDate = invoice.dueDate;
			invoiceDateVC.callingController = this;

			this.NavigationController.PushViewController(invoiceDateVC, true);
		}

		void CloseViewController(object sender, EventArgs e)
		{
			DismissViewController(true, null);
		}

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
	}
}
