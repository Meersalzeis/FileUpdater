namespace KaiFileUpdater;

using System.IO;
using System.Net;

class WebDownloader
{
    /// <summary>
    /// Downloads a file from a source URL to the file directory
    /// See https://stackoverflow.com/questions/307688/how-to-download-a-file-from-a-url-in-c answer 4
    /// </summary>
    /// <param name="sourceURL"></param> the url of the file to download
    /// <param name="localFilePath"></param> the destination of the file as a local file path
    private static FileStream DownloadToLocation(string sourceURL, string localFilePath)
    {
        using var client = new HttpClient();
        using var s = await client.GetStreamAsync( sourceURL );
        using var fs = new FileStream(destination, FileMode.OpenOrCreate);
        await s.CopyToAsync(fs);
    }
}
