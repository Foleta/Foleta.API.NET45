using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foleta.API.NET45
{
    /// <summary>
    /// Example application for .NET 4.5.
    /// </summary>
    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            // Settings
            const string apiAddress = "API-ADDRESS";
            const string apiKey = "API-KEY";

            // Init the client
            var client = new FoletaApiClient(apiAddress, apiKey);

            // Execute request
            var departments = await client.GetAsync<List<Department>>("department/?schoolId=406&schoolYearId=72");
        }

    }
}
