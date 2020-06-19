

namespace HomeRadar.Core.Model
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;

    /// <summary>
    /// The following class handles the vendor api call.
    /// </summary>
    public class VendorUtils
    {
        /// <summary>
        /// The following method gets the name of the NIC vendor.
        /// </summary>
        /// <param name="mac">NIC mac address.</param>
        /// <returns>NIC vendor name.</returns>
        public static string GetVendor(string mac)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.macvendors.com/"),
            };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            // Wait due to api timing requests
            Thread.Sleep(1000);
            HttpResponseMessage response = client.GetAsync(mac).Result;

            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            string vendor = null;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                vendor = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine($"{(int)response.StatusCode} ({response.ReasonPhrase})");
            }

            // Make any other calls using HttpClient here.
            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return vendor;
        }
    }
}
