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

        public ClientListTableViewController (IntPtr handle) : base (handle)
        {
        }

		public async override void ViewDidLoad()
		{
			HttpClient httpClient = new HttpClient();


			string result = await httpClient.GetStringAsync("http://webapitry120161228015023.azurewebsites.net/api/Clients/GetClients");

			clients = JsonConvert.DeserializeObject<List<Client>>(result);

            this.TableView.ReloadData();
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

            cell.TextLabel.Text = clients[indexPath.Row].Name;

            return cell;
        }
    }
}