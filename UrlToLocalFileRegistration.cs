namespace KaiFileUpdater;

/// <summary>
/// Data object to represent a file location locally that should be updated from a given URL
/// Used in FileAutoUpdater according to visitor pattern.
/// </summary>
class UrlToLocalFileRegistration : FileUpdaterRegistration
{
    // No getter or setter necessary for data objects
    public string URL;
    public string Location;

    FileToUpdate(string newURL, string newLocation)
    {
        this.URL = newURL;
        this.Location = newLocation;
    }
}