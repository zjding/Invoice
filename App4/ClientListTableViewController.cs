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

		public List<Client> filteredClients = new List<Client>();

		LoadingOverlay loadingOverlay;

		HttpClient httpClient = new HttpClient();

		UISearchController searchController;

		UISearchBar searchBar;

		bool bSearching = false;

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

			//var searchResultsController = new UISearchResultsViewController();

			//searchController = new UISearchController();
			//searchController.SearchBar.SizeToFit();

			//TableView.TableHeaderView = searchController.SearchBar;searchBar = new UISearchBar ();

			searchController = new UISearchController((UIViewController)null);

			searchController.DimsBackgroundDuringPresentation = false;
			DefinesPresentationContext = true;

			searchBar = searchController.SearchBar;
			//searchBar = new UISearchBar();
			searchBar.Placeholder = "Enter Search Text";
			searchBar.SizeToFit();
			searchBar.AutocorrectionType = UITextAutocorrectionType.No;
			searchBar.AutocapitalizationType = UITextAutocapitalizationType.None;
			searchBar.BarTintColor = UIColor.White;

			foreach (var view in searchBar.Subviews)
			{
				foreach (var subview in view.Subviews)
				{
					if (subview is UITextField)
					{
						(subview as UITextField).BackgroundColor = UIColor.FromRGB(247,247,247);
					}
				}
			}

			searchBar.TextChanged += SearchBar_TextChanged;
			searchBar.CancelButtonClicked += SearchBar_CancelButtonClicked;
			searchBar.OnEditingStarted += SearchBar_OnEditingStarted;


			TableView.TableHeaderView = searchBar;
		}

		void SearchBar_TextChanged(object sender, UISearchBarTextChangedEventArgs e)
		{
			if (searchBar.Text.Length == 0)
			{
				bSearching = false;
				TableView.ReloadData();
			}
			else
			{
				bSearching = true;

				filteredClients = clients.FindAll(s => (s.FirstName + s.LastName).ToUpper().Contains(searchBar.Text.ToUpper())); 
				TableView.ReloadData();
			}
		}

		void SearchBar_CancelButtonClicked(object sender, EventArgs e)
		{
			bSearching = false;
			TableView.ReloadData();
		}

		void SearchBar_OnEditingStarted(object sender, EventArgs e)
		{
			//filteredClients.Clear();
			//filteredClients.Add(clients[0]);
			//TableView.ReloadData();
		}

		public override nint RowsInSection(UITableView tableView, nint section)
        {
			if (!bSearching)
				return clients.Count;
			else
				return filteredClients.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = this.TableView.DequeueReusableCell("ClientCellIdentifier");

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "ClientCellIdentifier");
            }

			if (!bSearching)
				cell.TextLabel.Text = clients[indexPath.Row].FirstName + " " + clients[indexPath.Row].LastName;
			else 
				cell.TextLabel.Text = filteredClients[indexPath.Row].FirstName + " " + filteredClients[indexPath.Row].LastName;

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
				((ClientAddViewController)(destCtrl.ViewControllers[0])).bSearching = bSearching;

				int selectedIndex = this.TableView.IndexPathForSelectedRow.Row;

				if (!bSearching)
					((ClientAddViewController)(destCtrl.ViewControllers[0])).client = clients[selectedIndex];
				else 
					((ClientAddViewController)(destCtrl.ViewControllers[0])).client = filteredClients[selectedIndex];
			}

			searchBar.Text = "";

			bSearching = false;

			base.PrepareForSegue(segue, sender);
		}
    }
}