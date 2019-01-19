using NanoLeaf.API.Contracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NanoLeaf.API.BasicExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string address;

            do
            {
                Console.WriteLine("Welcome to the NanoLeaf example program.");
                Console.WriteLine("Please enter the address to your NanoLeaf controller:");

                Console.Write("> ");
                address = Console.ReadLine();
            }
            while (address == null);

            Console.WriteLine();
            Console.WriteLine("Before we can connect, please press on your NanoLeaf controller the \"On / Off\"-Button for 5-7 seconds until the LED flashes.");
            Console.WriteLine("After this press any key to continue.");
            Console.ReadKey(true);

            var httpClient = new HttpClient { BaseAddress = new Uri(address + "/api/v1/") };
            INanoLeafFactory nanoLeafFactory = new NanoLeafFactory(httpClient);

            Console.WriteLine();
            Console.WriteLine($"Trying to connect to \"{address}\" and to get an authorization token...");
            var nanoLeaf = await nanoLeafFactory.CreateNanoLeafAsync();

            Console.WriteLine();
            Console.WriteLine("Successful get an authorization token. Trying now to get the device information...");

            var deviceInformation = await nanoLeaf.GetDeviceInformationAsync();
            Console.WriteLine();
            Console.WriteLine("--- Some information about your NanoLeaf device ---");
            Console.WriteLine($"Name: {deviceInformation.Name}");
            Console.WriteLine($"Firmware version: {deviceInformation.FirmwareVersion}");
            Console.WriteLine($"Serial number: {deviceInformation.SerialNumber}");
            Console.WriteLine($"Status: {(deviceInformation.State.IsPoweredOn ? "On" : "Off")}");
            Console.WriteLine($"Selected effect: {deviceInformation.Effects.CurrentEffect}");
            Console.WriteLine($"Rhythm connected: {(deviceInformation.Rhythm.IsConnected ? "Yes" : "No")}");
            Console.WriteLine($"Rhythm active: {(deviceInformation.Rhythm.IsActive == true ? "Yes" : "No")}");

            // Information is also in the device information. Only for presentation purposes.
            var panelLayout = await nanoLeaf.PanelLayout.GetPanelLayoutAsync();
            Console.WriteLine();
            Console.WriteLine("--- Some information about your Panel Layout ---");
            Console.WriteLine($"Number of Panels: {panelLayout.NumberOfPanels}");
            Console.WriteLine($"Side length: {panelLayout.SideLength}");

            Console.WriteLine("Panel positions:");
            foreach (var position in panelLayout.PanelPositions)
                Console.WriteLine($" - Id: {position.PanelId}, X: {position.X}, Y: {position.Y}, Orientation: {position.Orientation}");    

            Console.WriteLine();
            Console.WriteLine("Revoking authorization token...");
            await nanoLeaf.RevokeAuthorizationTokenAsync();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit the program...");
            Console.ReadKey(true);
        }
    }
}