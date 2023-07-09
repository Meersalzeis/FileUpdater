using System;


/// <summary>
/// Demonstrates the capabilities of the namespace as required for the screening test.
/// </summary>
internal class Launcher
{
    private static string MOZILLA_URL = "https://www.mozilla.org/de/firefox/download/thanks/";
    private static string MOZILLA_LOCAL_DESTINATION = "firefox_setup.exe";

    private static string TOTAL_COMMANDER_URL = "https://totalcommander.ch/win/tcmd1052x32_64.exe";
    private static string TOTAL_COMMANDER_DESTINATION = "total_commander_setup.exe";


    static void Main(string[] args)
    {
        Console.WriteLine("Launcher started");
        FileUpdater mozillaAndTotalCommander = new FileUpdater("tempDownloads/temp.file");
        Console.WriteLine("FileUpdater made");
        mozillaAndTotalCommander.RegisterFile( new UrlToLocalFileRegistration(
            MOZILLA_URL,
            MOZILLA_LOCAL_DESTINATION));

        mozillaAndTotalCommander.RegisterFile( new UrlToLocalFileRegistration(
            TOTAL_COMMANDER_URL,
            TOTAL_COMMANDER_DESTINATION));

        Console.WriteLine("Files registered");
        mozillaAndTotalCommander.Update();
        Console.WriteLine("updated");
    }
}