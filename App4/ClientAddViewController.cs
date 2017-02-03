using Foundation;
using System;
using UIKit;
using AddressBookUI;
using Invoice_Model;

namespace App4
{
    public partial class ClientAddViewController : UITableViewController
    {
		public Client client = new Client();

        public ClientAddViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

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
			if (section == 2)
			{
				var header = headerView as UITableViewHeaderFooterView;

				header.TextLabel.TextColor = UIColor.DarkGray;
				header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);
			}
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

		partial void btnSave_TouchUpInside(UIBarButtonItem sender)
		{
			throw new NotImplementedException();
		}
	}
}