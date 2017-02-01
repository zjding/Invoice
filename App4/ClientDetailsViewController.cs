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

		void BtnImportFromContacts_Clicked(object sender, EventArgs e)
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
			PresentViewController(contactController, true, null);
		}
	}
}