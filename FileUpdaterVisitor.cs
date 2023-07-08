using System;
using System.IO;

namespace KaiFileUpdater;

class FileUpdaterVisitor
{
    private string pathToTempDownloadLocation;

    public FileUpdaterVisitor(string pathToTempDownloadLocation)
    {
        this.pathToTempDownloadLocation = pathToTempDownloadLocation;
    }


    // =============== The list of visit methods ===============

    public void visit(urlToLocalFileRegistration element)
    {
        FileStream fs = WebDownLoader.DownloadToLocation(element.URL, pathTempDownloadLocation);
        fs.

        if (element.URL != null)
        {
            // TODO replace file
            Console.WriteLine("File at " + " updated." );

        }
        else // File still up to date
        {
            // TODO Delete File in temp
        }
    }
}