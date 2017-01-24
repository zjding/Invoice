using Foundation;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;
using UIKit;


namespace App4
{
    public partial class LogoImageViewController : UITableViewController
    {
        UIImagePickerController imagePicker;

        public LogoImageViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            imagePicker = new UIImagePickerController();

            imagePicker.FinishedPickingMedia += ImagePicker_FinishedPickingMedia;
            imagePicker.Canceled += ImagePicker_Cancelled;

            imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            //var bytes = Task.Run(() => ImageManager.GetImage("EH9CX17370")).Result;
            //var data = NSData.FromArray(bytes);
            //Logo_imgLogo.Image = UIImage.LoadFromData(data);

            Logo_imgLogo.Image = UIImage.FromBundle("Settings-50");
        }

        async partial void Logo_btnLogo_TouchUpInside(UIButton sender)
        {
            await this.PresentViewControllerAsync(this.imagePicker, true);
        }



        private async void ImagePicker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            UIImage pickedImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            this.Logo_imgLogo.Image = pickedImage;
            await this.imagePicker.DismissViewControllerAsync(true);

            //var imageStream = Logo_imgLogo.Image.AsJPEG().AsStream();

            //var name = await ImageManager.UploadImage(imageStream);

            //var alert = UIAlertController.Create(
            //    null,
            //    null,
            //    UIAlertControllerStyle.ActionSheet);
            //alert.Title = "Image upload";
            //alert.Message = "The image was uploaded successully. Image Name:" + name;
            //alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (obj) => { }));
            //this.NavigationController.PresentViewController(alert, true, null);

            //// Retrieve storage account from connection string.
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=zjdingstorage;AccountKey=GzEIwmqlm6Lg8xFmsNKMA6+nLQgp/q7j7W+4H7/Ws/yfnoyGvOOMQGZEoLx1zBVyz0i5UWILwYNaSKCkj0Ywpg==");

            //// Create the blob client.
            //CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //// Retrieve reference to a previously created container.
            //CloudBlobContainer container = blobClient.GetContainerReference("container1");

            //// Create the container if it doesn't already exist.
            //await container.CreateIfNotExistsAsync();

            //// Retrieve reference to a blob named "myblob".
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            //// Create the "myblob" blob with the text "Hello, world!"
            //await blockBlob.UploadTextAsync("Hello, world!");
        }

        async private  void ImagePicker_Cancelled(object sender, EventArgs e)
        {
            await this.imagePicker.DismissViewControllerAsync(true);
        }

        async partial void Logo_btnUpload_TouchUpInside(UIButton sender)
        {
            var imageStream = Logo_imgLogo.Image.AsJPEG().AsStream();

            var name = await ImageManager.UploadImage(imageStream);

            //var alert = UIAlertController.Create(
            //    null,
            //    null,
            //    UIAlertControllerStyle.ActionSheet);
            //alert.Title = "Image upload";
            //alert.Message = "The image was uploaded successully. Image Name:" + name;
            //alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (obj) => { }));
            //this.PresentViewController(alert, true, null);
        }
    }
}