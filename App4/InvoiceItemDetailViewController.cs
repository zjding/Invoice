using Foundation;
using System;
using UIKit;
using Invoice_Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace App4
{
    public partial class InvoiceItemDetailViewController : UITableViewController
    {
		public InvoiceDynamicDetailViewController callingController;
		LoadingOverlay loadingOverlay;

        public InvoiceItemDetailViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			UIToolbar toolbar = new UIToolbar();


			var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
			doneButton.Clicked += doneButtonClicked;

			var bbs = new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				doneButton
			};

			toolbar.SetItems(bbs, false);
			toolbar.SizeToFit();	

			txtCost.InputAccessoryView = toolbar;
			txtQuan.InputAccessoryView = toolbar;
		}

		void doneButtonClicked(object sender, EventArgs e)
		{
			txtCost.ResignFirstResponder();
			txtQuan.ResignFirstResponder();
		}

		public override void DidMoveToParentViewController(UIViewController parent)
		{

		}

		public override void ViewWillDisappear(Boolean animated)
		{
			//callingController.items.Add("Item " + (callingController.items.Count + 1).ToString());
		}

		async partial void btnSave_TouchUpInside(UIBarButtonItem sender)
		{
			Item item = new Item();

			item.Name = txtDescription.Text;
			item.Price = Convert.ToDecimal(txtCost.Text);
			item.Quantity = Convert.ToInt16(txtQuan.Text);
			item.bTaxable = swTaxable.On;
			item.Note = txtNote.Text;

			string jsonString = JsonConvert.SerializeObject(item);

			HttpClient httpClient = new HttpClient();

			var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

				var result = await httpClient.PostAsync("http://webapitry120161228015023.azurewebsites.net/api/Item/AddItem", content);

				var contents = await result.Content.ReadAsStringAsync();

				string returnMessage = contents.ToString();

				loadingOverlay.Hide();

				if (returnMessage == "\"Added item successfully\"")
				{
					callingController.DismissViewController(true, null);

				}


		}

		partial void btnClose_TouchUpInside(UIBarButtonItem sender)
		{
			
		}
    }
}