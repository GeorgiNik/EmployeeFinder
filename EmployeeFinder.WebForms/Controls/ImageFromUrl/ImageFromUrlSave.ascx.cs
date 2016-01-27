namespace EmployeeFinder.WebForms.Controls.ImageFromUrl
{
    using System;
    using System.IO;
    using System.Net;
    using System.Web.UI;

    public partial class ImageFromUrlSave : UserControl
    {
        public decimal ContentLength { get; set; }

        public string DownloadRemoteImageFile(string fileName)
        {
            var uri = this.ImageUploadUrl.Text;
            var request = (HttpWebRequest)WebRequest.Create(uri);
            var response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Moved
                 || response.StatusCode == HttpStatusCode.Redirect)
                && response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {
                // if the remote file was found, download it
                var extension = response.ContentType.Substring(response.ContentType.LastIndexOf('/') + 1);
                fileName = fileName + '.' + extension;
                using (var inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    var buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    }
                    while (bytesRead != 0);

                    return extension;
                }
            }

            throw new Exception("URL doesn't contain image file");
        }

        public bool HaveUrl()
        {
            return !string.IsNullOrEmpty(this.ImageUploadUrl.Text);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}