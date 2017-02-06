using Foundation;
using System;
using UIKit;
using Invoice_Model;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace App4
{
    public partial class ClientListTableViewController : UITableViewController
    {
		public List<Client> clients = new List<Client>();

		LoadingOverlay loadingOverlay;

		HttpClient httpClient = new HttpClient();

        public ClientListTableViewController (IntPtr handle) : base (handle)
        {

        }

		public async override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			var bounds = UIScreen.MainScreen.Bounds;

			loadingOverlay = new LoadingOverlay(bounds);
			this.View.Add(loadingOverlay);

			string result = await httpClient.GetStringAsync("http://webapitry120161228015023.azurewebsites.net/api/Clients/GetClients");

			clients = JsonConvert.DeserializeObject<List<Client>>(result);

			loadingOverlay.Hide();

			this.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

			//this.TableView.SeparatorColor = UIColor.Gray;

			this.TableView.ReloadData();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//var bounds = UIScreen.MainScreen.Bounds;

			//loadingOverlay = new LoadingOverlay(bounds);
			//this.View.Add(loadingOverlay);

			//HttpClient httpClient = new HttpClient();


			//string result = await httpClient.GetStringAsync("http://webapitry120161228015023.azurewebsites.net/api/Clients/GetClients");

			//clients = JsonConvert.DeserializeObject<List<Client>>(result);

			//loadingOverlay.Hide();

			//this.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;

   //         this.TableView.ReloadData();
		}


        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return clients.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = this.TableView.DequeueReusableCell("ClientCellIdentifier");

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "ClientCellIdentifier");
            }

			cell.TextLabel.Text = clients[indexPath.Row].FirstName + " " + clients[indexPath.Row].LastName;

            return cell;
        }

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "Client_List_To_New_Segue")
			{
				var destCtrl = segue.DestinationViewController as UINavigationController;

				((ClientAddViewController)(destCtrl.ViewControllers[0])).callingController = this;

			}
			else if (segue.Identifier == "Client_List_To_Detail_Segue")
			{
				var destCtrl = segue.DestinationViewController as UINavigationController;

				((ClientAddViewController)(destCtrl.ViewControllers[0])).callingController = this;

				((ClientAddViewController)(destCtrl.ViewControllers[0])).bNew = false;

				int selectedIndex = this.TableView.IndexPathForSelectedRow.Row;

				((ClientAddViewController)(destCtrl.ViewControllers[0])).client = clients[selectedIndex];
			}

			base.PrepareForSegue(segue, sender);
		}
    }
}