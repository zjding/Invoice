using Foundation;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using UIKit;

namespace App4
{
    public partial class BusinessDetailsViewController : UITableViewController
    {
        public BusinessDetailsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.BusinessDetails_txtCompanyName.ShouldReturn += (BusinessDetails_txtCompanyName) =>
            {
                BusinessDetails_txtCompanyName.ResignFirstResponder();
                return true;
            };
        }

        async partial void BusinessDetails_btnSave_TouchUpInside(UIKit.UIBarButtonItem sender)
        {
            Business business = new Business();
            business.Name = this.BusinessDetails_txtCompanyName.Text;
            business.Owner = this.BusinessDetails_txtOwnerName.Text;

            string jsonString = JsonConvert.SerializeObject(business);

            HttpClient client = new HttpClient();

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var result = await client.PostAsync("http://webapitry120161228015023.azurewebsites.net/api/Business/AddBusiness", content);

            var contents = await result.Content.ReadAsStringAsync();

            string a = contents.ToString();
        }

        partial void BusinessDetails_txtCompanyName_OnEditingDidBegin(UIKit.UITextField sender)
        {
            //this.BusinessDetails_txtCompanyName.BecomeFirstResponder();


        }
    }
}