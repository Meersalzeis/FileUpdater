using System;
using System.IO;


public class FileUpdaterVisitor
{
    private string pathToTempDownloadLocation;

    public FileUpdaterVisitor(string pathToTempDownloadLocation)
    {
        this.pathToTempDownloadLocation = pathToTempDownloadLocation;
    }


    // =============== The list of visit methods ===============

    public async void visit(UrlToLocalFileRegistration element)
    {
        FileStream fs = await WebDownloader.DownloadToLocationAsync(element.URL, this.pathToTempDownloadLocation);
        var serverFileInfo = new FileInfo(pathToTempDownloadLocation);
        var localFileInfo = new FileInfo(element.Location);

        if (serverFileInfo.LastWriteTime > localFileInfo.LastWriteTime)
        {
            localFileInfo.Delete();
            serverFileInfo.CopyTo(element.Location);
            Console.WriteLine("File updated! New " + element.Location);

        }
        else // File still up to date
        {
            localFileInfo.Delete();
        }
    }
}