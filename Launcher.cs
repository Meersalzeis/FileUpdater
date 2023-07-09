using System;
using System.IO;
using System.Reflection;

/// <summary>
/// Demonstrates the capabilities of the namespace as required for the screening test.
/// </summary>
internal class Launcher
{
    private static string MOZILLA_URL = "https://www.mozilla.org/de/firefox/download/thanks/";
    private static string MOZILLA_LOCAL_DESTINATION = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/someFolder/firefox_setup.exe";

    private static string TOTAL_COMMANDER_URL = "https://totalcommander.ch/win/tcmd1052x32_64.exe";
    private static string TOTAL_COMMANDER_DESTINATION = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/someFolder/total_commander_setup.exe";

    private static string TEMP_DIRECTORY = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/temp/";

    static void Main(string[] args)
    {
        FileUpdater mozillaAndTotalCommander = new FileUpdater(TEMP_DIRECTORY);
        
        mozillaAndTotalCommander.RegisterFile( new UrlToLocalFileRegistration(
            MOZILLA_URL,
            MOZILLA_LOCAL_DESTINATION)); 
        
        mozillaAndTotalCommander.RegisterFile( new UrlToLocalFileRegistration(
            TOTAL_COMMANDER_URL,
            TOTAL_COMMANDER_DESTINATION)); // **/

        mozillaAndTotalCommander.Update();

        Console.WriteLine("File Updater, Please type enter to close the console");

        // To let users read the console 
        Console.ReadLine();
    }
}