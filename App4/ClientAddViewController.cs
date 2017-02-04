using Foundation;
using System;
using UIKit;
using AddressBookUI;
using Invoice_Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Drawing;

namespace App4
{
    public partial class ClientAddViewController : UITableViewController
    {
		public Client client = new Client();
		LoadingOverlay loadingOverlay;

        public ClientAddViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//ShowActivityIndicator(this.View);



			this.txtFirstName.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtLastName.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtPhone.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtEmail.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtStreet1.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtStreet2.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtCity.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtState.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtCountry.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};

			this.txtPostCode.ShouldReturn += (textField) =>
			{
				((UITextField)textField).ResignFirstResponder();
				return true;
			};


		}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{
			//if (section == 2)
			//{
			//	var header = headerView as UITableViewHeaderFooterView;

			//	header.TextLabel.TextColor = UIColor.DarkGray;
			//	header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);
			//}
		}

		partial void btnImportContact_UpInside(UIButton sender)
		{
			ABPeoplePickerNavigationController contactController = new ABPeoplePickerNavigationController();
			contactController.SelectPerson2 += ContactController_SelectPerson2;

			PresentViewController(contactController, true, null);
		}

		void ContactController_SelectPerson2(object sender, ABPeoplePickerSelectPerson2EventArgs e)
		{
			client.FirstName = e.Person.FirstName;
			client.LastName = e.Person.LastName;

	         var phones = e.Person.GetPhones();
	         var emails = e.Person.GetEmails();
	         var addresses = e.Person.GetAllAddresses();

	         if (phones.Count > 0)
	         {
	             client.Phone = phones[0].Value;
	         }

	         if (emails.Count > 0)
	         {
				client.Email = emails[0].Value;
	         }

	         if (addresses.Count > 0)
	         {
				client.Street1 = addresses[0].Value.Street;
				client.City = addresses[0].Value.City;
				client.State = addresses[0].Value.State;
				client.Country = addresses[0].Value.Country;
				client.PostCode = addresses[0].Value.Zip;
	         }

			this.txtFirstName.Text = client.FirstName;
			this.txtLastName.Text = client.LastName;
			this.txtPhone.Text = client.Phone;
			this.txtEmail.Text = client.Email;
			this.txtStreet1.Text = client.Street1;
			this.txtStreet2.Text = client.Street2;
			this.txtCity.Text = client.City;
			this.txtState.Text = client.State;
			this.txtCountry.Text = client.Country;
			this.txtPostCode.Text = client.PostCode;
		}

		async partial void btnSave_TouchUpInside(UIBarButtonItem sender)
		{
			Client client = new Client();
			client.FirstName = txtFirstName.Text;
			client.LastName = txtLastName.Text;
			client.Phone = txtPhone.Text;
			client.Email = txtEmail.Text;
			client.Street1 = txtStreet1.Text;
			client.Street2 = txtStreet2.Text;
			client.City = txtCity.Text;
			client.State = txtState.Text;
			client.Country = txtCountry.Text;
			client.PostCode = txtPostCode.Text;

			string jsonString = JsonConvert.SerializeObject(client);

			HttpClient httpClient = new HttpClient();

			var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			var result = await httpClient.PostAsync("http://webapitry120161228015023.azurewebsites.net/api/Client/AddClient", content);

			//var contents = await result.Content.ReadAsStringAsync();

			//string a = contents.ToString();

			loadingOverlay.Hide();
		}

		public void ShowActivityIndicator(UIView view)
		{
			UIActivityIndicatorView actInd = new UIActivityIndicatorView();
			actInd.Frame = new Rectangle(0, 0, 40, 40);
			actInd.Center = view.Center;
			actInd.HidesWhenStopped = true;
			actInd.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.WhiteLarge;
			view.AddSubview(actInd);
			actInd.StartAnimating();
		}
	}
}