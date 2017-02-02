using Foundation;
using System;
using UIKit;
using AddressBook;
using AddressBookUI;
using Invoice_Model;

namespace App4
{
	public partial class ClientDetailsViewController : UITableViewController
	{
        public Client client;

		public ClientDetailsViewController(IntPtr handle) : base(handle)
		{
            client = new Client();
            
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			btnImportFromContacts.Clicked += BtnImportFromContacts_Clicked;
		}

		public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
		{
			if (section == 1)
			{
				var header = headerView as UITableViewHeaderFooterView;

				header.TextLabel.TextColor = UIColor.DarkGray;
				header.TextLabel.Font = UIFont.BoldSystemFontOfSize(12);
			}
		}

		public void BtnImportFromContacts_Clicked(object sender, EventArgs e)
		{
			ABAuthorizationStatus status = ABAddressBook.GetAuthorizationStatus();
			NSError error;
			ABAddressBook addressBook =
			ABAddressBook.Create(out error);
			if (status == ABAuthorizationStatus.NotDetermined)
			{
				addressBook.RequestAccess((g, err) =>
				{
					if (g)
					{
						this.InvokeOnMainThread(() =>
						this.DisplayContactCard(addressBook));
					}
					else
					{
						Console.WriteLine("User denied access to the address book!");
					}
				});
			}
			else if (status == ABAuthorizationStatus.Authorized)
			{
				this.DisplayContactCard(addressBook);
			}
			else
			{
				Console.WriteLine("App does not have access to the address book!");
			}
		}


		private void DisplayContactCard(ABAddressBook addressBook)
		{
			//ABPerson[] contacts = addressBook.GetPeople();
			//ABPersonViewController personController =
			//new ABPersonViewController();
			//personController.DisplayedPerson = contacts[0];
			//this.NavigationController.PushViewController(
			//personController, true);

			ABPeoplePickerNavigationController contactController = new ABPeoplePickerNavigationController();
			contactController.SelectPerson2 += ContactController_SelectPerson2;

			PresentViewController(contactController, true, null);
		}

		void ContactController_SelectPerson2(object sender, ABPeoplePickerSelectPerson2EventArgs e)
		{
			client.firstName = e.Person.FirstName;
			client.lastName = e.Person.LastName;
		}
	}
}