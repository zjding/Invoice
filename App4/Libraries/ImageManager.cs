using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;
using System.IO;
using UIKit;
using System.Drawing;

namespace App4
{
    public class ImageManager
    {
        public ImageManager()
        {
        }

        /// <summary>
        /// Gets a reference to the container for storing the images
        /// </summary>
        /// <returns></returns>
        private static CloudBlobContainer GetContainer()
        {
            // Parses the connection string for the WindowS Azure Storage Account
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=zjdingstorage;AccountKey=GzEIwmqlm6Lg8xFmsNKMA6+nLQgp/q7j7W+4H7/Ws/yfnoyGvOOMQGZEoLx1zBVyz0i5UWILwYNaSKCkj0Ywpg==");
            var client = account.CreateCloudBlobClient();

            // Gets a reference to the images container
            var container = client.GetContainerReference("images");

            return container;
        }

        /// <summary>
        /// Uploads a new image to a blob container.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static async Task<string> UploadImage(Stream image)
        {
            var container = GetContainer();

            // Creates the container if it does not exist
            await container.CreateIfNotExistsAsync();

            // Uses a random name for the new images
            var name = RandomString(10);

            // Uploads the image the blob storage
            var imageBlob = container.GetBlockBlobReference(name);
            await imageBlob.UploadFromStreamAsync(image);

            return name;
        }

        /// <summary>
        /// Lists of all the available images in the blob container
        /// </summary>
        /// <returns></returns>
        public static async Task<string[]> ListImages()
        {
            var container = GetContainer();

            // Iterates multiple times to get all the available blobs
            var allBlobs = new List<string>();
            BlobContinuationToken token = null;

            do
            {
                var result = await container.ListBlobsSegmentedAsync(token);
                if (result.Results.Count() > 0)
                {
                    var blobs = result.Results.Cast<CloudBlockBlob>().Select(b => b.Name);
                    allBlobs.AddRange(blobs);
                }

                token = result.ContinuationToken;
            } while (token != null); // no more blobs to retrieve

            return allBlobs.ToArray();
        }

        /// <summary>
        /// Gets an image from the blob container using the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task<byte[]> GetImage(string name)
        {
            var container = GetContainer();

            //Gets the block blob representing the image
            var blob = container.GetBlobReference(name);

            if (await blob.ExistsAsync())
            {
                // Gets the block blob length to initialize the array in memory
                await blob.FetchAttributesAsync();

                byte[] blobBytes = new byte[blob.Properties.Length];

                // Downloads the block blob and stores the content in an array in memory
                await blob.DownloadToByteArrayAsync(blobBytes, 0);

                return blobBytes;
            }

            return null;
        }

        /// <summary>
        /// Generates a random string
        /// </summary>
        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

		public static UIImage ResizeImage(UIImage sourceImage, float maxWidth, float maxHeight)
		{
			var sourceSize = sourceImage.Size;
			var maxResizeFactor = Math.Max(maxWidth / sourceSize.Width, maxHeight / sourceSize.Height);
			if (maxResizeFactor > 1) return sourceImage;
			float width = (float)(maxResizeFactor * sourceSize.Width);
			float height = (float)(maxResizeFactor * sourceSize.Height);
			UIGraphics.BeginImageContext(new SizeF(width, height));
			sourceImage.Draw(new RectangleF(0, 0, width, height));
			var resultImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return resultImage;
		}
    }
}


