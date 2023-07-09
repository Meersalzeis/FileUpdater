using System;
using System.IO;

/// <summary>
/// The Visitor according to visitor pattern, to update the Registrations of FileUpdater
/// </summary>
public class FileUpdaterVisitor
{
    private string pathToTempDownloadFolder;
    private static int tempFileNr = 0;
    private static DirectoryInfo tempDir = null;

    public FileUpdaterVisitor(string pathToTempDownloadFolder)
    {
        this.pathToTempDownloadFolder = pathToTempDownloadFolder;
    }

    public void CleanUp()
    {
        tempDir.Delete(true);
    }


    // =============== The list of visit methods ===============

    /// <summary>
    /// Updates the files in the Registration from the given URL to the given Location 
    /// </summary>
    /// <param name="registration"></param> Registration to be updated
    public async void visit(UrlToLocalFileRegistration registration)
    {
        // Still inside linear thread code
        tempFileNr++;

        FileInfo serverFileInfo = null;
        FileInfo localFileInfo = null;

        // Create tempDir if not existent
        if (tempDir == null)
        {
            tempDir = Directory.CreateDirectory(this.pathToTempDownloadFolder);
        }

        try
        {
            // Download file
            string tempFileLocation = "temp" + tempFileNr + ".file";
            FileStream fs = await WebDownloader.DownloadToLocationAsync(registration.URL, this.pathToTempDownloadFolder + tempFileLocation);

            // Compare files
            serverFileInfo = new FileInfo(pathToTempDownloadFolder + tempFileLocation);
            localFileInfo = new FileInfo(registration.Location);

            if (serverFileInfo.CreationTime > localFileInfo.CreationTime)
            {
                //localFileInfo.Delete();
                serverFileInfo.CopyTo(registration.Location, true); // true == overwrite 
                Console.WriteLine("File updated! New " + registration.Location);

            } // else do nothing
        }
        catch (Exception e)
        {
            Console.WriteLine(" Update failed - " + e.ToString());
        }

        // Cleanup for folders intended for end of FileUpdater.Update()
        // Files are overwritten and thus need no clean up
    }
}