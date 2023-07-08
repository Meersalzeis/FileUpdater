using System;
using KaiFileUpdater;

/// <summary>
/// Demonstrates the capabilities of the namespace as required for the screening test.
/// </summary>
public class Main
{
    private static string MOZILLA_URL = "";
    private static string MOZILLA_LOCAL_DESTINATION = "firefox_setup.exe";

    private static string TOTAL_COMMANDER_URL = "";
    private static string TOTAL_COMMANDER_DESTINATION = "total_commander_setup.exe";


    static void Main(string[] args)
    {
        FileUpdater mozillaAndTotalCommander = new FileUpdater();

        mozillaAndTotalCommander.RegisterFile( new (UrlToLocalFileRegistration(
            MOZILLA_URL,
            MOZILLA_LOCAL_DESTINATION) );
        mozillaAndTotalCommander.RegisterFile(new(UrlToLocalFileRegistration(
            TOTAL_COMMANDER_URL,
            TOTAL_COMMANDER_DESTINATION));

        mozillaAndTotalCommander.Update();
    }
}