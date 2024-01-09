using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class EncodingDecoding
    {
        public static void EncodingAndDecoding()
        {

            // Encoding data
            string originalData = "Hello, this is some data to be encoded!";
            byte[] encodedBytes = Encoding.UTF8.GetBytes(originalData);

            // Transporting data using HTTP
            using (HttpClient client = new HttpClient())
            {
                // Sending data
                 client.PostAsync("https://example.com/api", new ByteArrayContent(encodedBytes));

                // Receiving data
                HttpResponseMessage response =  client.GetAsync("https://example.com/api").Result;
                byte[] receivedBytes = response.Content.ReadAsByteArrayAsync().Result;

                // Decoding data
                string decodedData = Encoding.UTF8.GetString(receivedBytes);

                Console.WriteLine("Original Data: " + originalData);
                Console.WriteLine("Decoded Data: " + decodedData);
            }
        }
    }
}
