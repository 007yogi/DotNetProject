using System.Net.Http.Headers;
using System.Text;

namespace AsyncAwaitDemo
{
    public class InfoBipWhatsApp
    {
        /**
         * Send the WhatsApp template message directly by calling HTTP endpoint.
         *
         * THIS CODE EXAMPLE IS READY BY DEFAULT. HIT RUN TO SEND THE MESSAGE!
         *
         * Send WhatsApp API reference: https://www.infobip.com/docs/api#channels/whatsapp/send-whatsapp-template-message
         * See Readme file for details.
         */

        private static readonly string BASE_URL = "https://432m1m.api.infobip.com";
        private static readonly string API_KEY = "842e68394f0dbf4df4e2ef475fb14131-253231a5-3e09-4bc3-98dc-0b8d21ab8237";
        private static readonly string SENDER = "447860099299";
        private static readonly string RECIPIENT = "918287817167";

       public static async Task SendMsg()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("App", API_KEY);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string message = $@"
            {{
                ""messages"": [
                {{
                    ""from"": ""{SENDER}"",
                    ""to"": ""{RECIPIENT}"",
                    ""content"": {{
                    ""templateName"": ""registration_success"",
                    ""templateData"": {{
                        ""body"": {{
                        ""placeholders"": [
                            ""sender"",
                            ""message"",
                            ""delivered"",
                            ""testing""
                        ]
                        }},
                        ""header"": {{
                        ""type"": ""IMAGE"",
                        ""mediaUrl"": ""https://api.infobip.com/ott/1/media/infobipLogo""
                        }},
                        ""buttons"": [
                        {{
                            ""type"": ""QUICK_REPLY"",
                            ""parameter"": ""yes-payload""
                        }},
                        {{
                            ""type"": ""QUICK_REPLY"",
                            ""parameter"": ""no-payload""
                        }},
                        {{
                            ""type"": ""QUICK_REPLY"",
                            ""parameter"": ""later-payload""
                        }}
                        ]
                    }},
                    ""language"": ""en""
                }}
                }}
            ]
            }}";

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "/whatsapp/1/message/template");
            httpRequest.Content = new StringContent(message, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(httpRequest);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);

        }
    }
}
