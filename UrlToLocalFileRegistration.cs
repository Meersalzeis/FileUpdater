

/// <summary>
/// Data object to represent a file location locally that should be updated from a given URL
/// Used in FileAutoUpdater according to visitor pattern.
/// </summary>
public class UrlToLocalFileRegistration : FileUpdaterRegistration
{
    // No getter or setter necessary for data objects
    public string URL;
    public string Location;

    public UrlToLocalFileRegistration(string newURL, string newLocation)
    {
        this.URL = newURL;
        this.Location = newLocation;
    }

    public override void accept(FileUpdaterVisitor FUVisitor)
    {
        FUVisitor.visit(this);
    }
}