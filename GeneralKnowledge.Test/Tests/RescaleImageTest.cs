using NetVips;
using System.IO;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            using (WebClient webClient = new WebClient())
            {
                byte[] dataArr = webClient.DownloadData("https://upload.wikimedia.org/wikipedia/en/9/97/Far_Cry_2_cover_art.jpg");
                //save file
                File.WriteAllBytes(@"../../Resources/Far_Cry_2_cover_art.jpg", dataArr);
            }
            //saved path as source
            Image image = Image.Thumbnail(@"../../Resources/Far_Cry_2_cover_art.jpg", 300, 300);
            image.WriteToFile(@"../../Resources/serious-grasshopper-1-1056340_resized.jpg");
        }
    }
}
