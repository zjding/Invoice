using Foundation;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.IO;
using System.Net;
using UIKit;

namespace App4
{
    public partial class PDFPreviewViewController : UIViewController
    {
        public PDFPreviewViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Document document = new Document(PageSize.A4, 70, 70, 70, 70);

            //MemoryStream PDFData = new MemoryStream();
            //PdfWriter write = PdfWriter.GetInstance(document, PDFData);

            string path = NSBundle.MainBundle.BundlePath;

            

            path = path + "/invoice.html";

            string content = File.ReadAllText(path);

            //content = content.Replace("#LOGO_IMAGE#", "file://" + NSBundle.MainBundle.BundlePath + "/google.png");
            //content = content.Replace("#LOGO_IMAGE#", "https:///zjdingstorage.blob.core.windows.net//container1//google.png");
            //content = content.Replace("#INVOICE_NUMBER#", "123456789");
            //content = content.Replace("#INVOICE_DATE#", "1/20/2017");

            
            //this.PDFPreview_wvPDF.LoadHtmlString(content, null);

            //byte[] bPDF = GetPDF(content);

            var document = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fileName = Path.Combine(document, "invoice.pdf");

            //File.WriteAllBytes(fileName, bPDF);

            GeneratePDF(content, fileName);
            
            this.PDFPreview_wvPDF.LoadRequest(new NSUrlRequest(new NSUrl(fileName)));
        }

        public void GeneratePDF(string html, string filepath)
        {
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filepath, FileMode.Create));
            document.Open();
            HTMLWorker hw = new HTMLWorker(document);
            StringReader sr = new StringReader(html);
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
            document.Close();

        }

        //public byte[] GetPDF(string pHTML)
        //{
        //    byte[] bPDF = null;

        //    MemoryStream ms = new MemoryStream();
        //    TextReader txtReader = new StringReader(pHTML);

        //    // 1: create object of a itextsharp document class
        //    Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

        //    // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
        //    PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

        //    // 3: we create a worker parse the document
        //    HTMLWorker htmlWorker = new HTMLWorker(doc);

        //    // 4: we open document and start the worker on the document
        //    doc.Open();
        //    htmlWorker.StartDocument();

        //    // 5: parse the html into the document
        //    htmlWorker.Parse(txtReader);

        //    // 6: close the document and the worker
        //    htmlWorker.EndDocument();
        //    htmlWorker.Close();
        //    doc.Close();

        //    bPDF = ms.ToArray();

        //    return bPDF;
        //}
    }
}