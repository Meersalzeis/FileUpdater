using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public static class WebDownloader
{
    /// <summary>
    /// Downloads a file from a source URL to the file directory
    /// See https://stackoverflow.com/questions/307688/how-to-download-a-file-from-a-url-in-c answer 4
    /// </summary>
    /// <param name="sourceURL"></param> the url of the file to download
    /// <param name="localFilePath"></param> the destination of the file as a local file path
    public static async Task<FileStream> DownloadToLocationAsync(string sourceURL, string localFilePath)
    {
        HttpClient client = new HttpClient();
        Stream s = await client.GetStreamAsync(sourceURL);
        FileStream fs = new FileStream(localFilePath, FileMode.OpenOrCreate);
        await s.CopyToAsync(fs);
        return fs;
    }
}
