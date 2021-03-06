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
		public ClientListTableViewController callingController;

		public Client client;

		public bool bNew = true;

		public bool bSearching = false;

		LoadingOverlay loadingOverlay;

        public ClientAddViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//ShowActivityIndicator(this.View);

			if (!bNew)
			{
				txtFirstName.Text = client.FirstName;
				txtLastName.Text = client.LastName;
				txtPhone.Text = client.Phone;
				txtEmail.Text = client.Email;

				txtStreet1.Text = client.Street1;
				txtStreet2.Text = client.Street2;
				txtCity.Text = client.City;
				txtState.Text = client.State;
				txtCountry.Text = client.Country;
				txtPostCode.Text = client.PostCode;

				this.Title = client.FirstName + " " + client.LastName;

				barBtnImport.Title = "Delete";
				barBtnImport.SetTitleTextAttributes(new UITextAttributes()
				{
					TextColor = UIColor.Red
				}, UIControlState.Normal);
			}

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

		//public override nint NumberOfSections(UITableView tableView)
		//{
		//	if (bNew)
		//		return 3;
		//	else
		//		return 2;
		//}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{
			//if (section == 2)
			//{
			//	var header = headerView as UITableViewHeaderFooterView;

			//	header.TextLabel.TextColor = UIColor.DarkGray;
			//	header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);
			//}
		}



		void ContactController_SelectPerson2(object sender, ABPeoplePickerSelectPerson2EventArgs e)
		{
			client = new Client();

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
			Client _client = new Client();
			if (!bNew)
			{
				_client.id = client.id;
			}
			_client.FirstName = txtFirstName.Text;
			_client.LastName = txtLastName.Text;
			_client.Phone = txtPhone.Text;
			_client.Email = txtEmail.Text;
			_client.Street1 = txtStreet1.Text;
			_client.Street2 = txtStreet2.Text;
			_client.City = txtCity.Text;
			_client.State = txtState.Text;
			_client.Country = txtCountry.Text;
			_client.PostCode = txtPostCode.Text;

			string jsonString = JsonConvert.SerializeObject(_client);

			HttpClient httpClient = new HttpClient();

			var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			if (bNew)
			{
				var result = await httpClient.PostAsync("http://webapitry120161228015023.azurewebsites.net/api/Client/AddClient", content);

				var contents = await result.Content.ReadAsStringAsync();

				string returnMessage = contents.ToString();

				loadingOverlay.Hide();

				if (returnMessage == "\"Added client successfully\"")
				{
					callingController.DismissViewController(true, null);

				}
			}
			else
			{
				var result = await httpClient.PutAsync("http://webapitry120161228015023.azurewebsites.net/api/Client/PutClient", content);

				var contents = await result.Content.ReadAsStringAsync();

				string returnMessage = contents.ToString();

				loadingOverlay.Hide();

				if (returnMessage == "\"Updated client successfully\"")
				{
					callingController.DismissViewController(true, null);

				}
			}
		}


		partial void btnCancel_TouchUpInside(UIBarButtonItem sender)
		{
			callingController.DismissViewController(true, null);

			if (bSearching)
				callingController.DismissViewController(true, null);
		}

		partial void barBtnImport_TouchUpInside(UIBarButtonItem sender)
		{
			if (bNew)
			{
				ABPeoplePickerNavigationController contactController = new ABPeoplePickerNavigationController();
				contactController.SelectPerson2 += ContactController_SelectPerson2;

				PresentViewController(contactController, true, null);
			}
			else
			{
				//Create Alert
				var okCancelAlertController = UIAlertController.Create("Delete", "Do you confirm to delete the client?", UIAlertControllerStyle.Alert);

				//Add Actions
				okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => DeleteClient()));
				okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => Console.WriteLine("Cancel was clicked")));

				//Present Alert
				PresentViewController(okCancelAlertController, true, null);
			}
		}

		public async void DeleteClient()
		{
			HttpClient httpClient = new HttpClient();

			var result = await httpClient.DeleteAsync("http://webapitry120161228015023.azurewebsites.net/api/Clients/Delete/" + client.id.ToString());

			result.EnsureSuccessStatusCode();

			if (result.IsSuccessStatusCode)
			{
				callingController.DismissViewController(true, null);
			}
		}
	}
}