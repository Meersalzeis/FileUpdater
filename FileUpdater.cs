using System.Collections.Generic;

/// <summary>
/// Updates files from registered URLs to a location designated when registering the file.
/// It is NOT optimized for huge amounts of files.
/// Uses a visitor pattern to update files.
/// </summary>
public class FileUpdater
{
    private List<FileUpdaterRegistration> filesToUpdate = new List<FileUpdaterRegistration>();
    FileUpdaterVisitor FUVisitor;

    public FileUpdater(string temporaryDownloadLocation)
    {
        FUVisitor = new FileUpdaterVisitor(temporaryDownloadLocation);
    }

    public void RegisterFile(FileUpdaterRegistration newRegistration) 
    {
        filesToUpdate.Add(newRegistration);
    }

    public void UnregisterFile(FileUpdaterRegistration oldRegistration) 
    {
        filesToUpdate.Remove(oldRegistration);
    }
    
    public void Update()
    {
        foreach (var registration in filesToUpdate)
        {
            registration.accept(FUVisitor);
        }

        // Clean up after updates
        // Currently deletes the directory while they're used by the OS to execute the updates
        // Not finished, as I do not have the time to fix this and it is optional for functionality
        //FUVisitor.CleanUp();
    }
}