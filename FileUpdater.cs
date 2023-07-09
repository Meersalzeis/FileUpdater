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
    }
}