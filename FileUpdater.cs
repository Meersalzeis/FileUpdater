using System.Collections.Generic;

namespace KaiFileUpdater;

/// <summary>
/// Updates files from registered URLs to a location designated when registering the file.
/// It is NOT optimized for huge amounts of files.
/// Uses a visitor pattern to update files.
/// </summary>
public class FileUpdater
{
    private List<FileUpdaterRegistration> filesToUpdate = new List<FileUpdaterRegistration>();

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
        FileUpdaterVisitor FUVisitor = new FileUpdaterVisitor();
        foreach (var registration in filesToUpdate)
        {
            registration.accept(FUVisitor);
        }
    }
}