using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace WhatsAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoBipWhatsAppController : ControllerBase
    {
        [HttpPost("SendMsg")]
        public async Task<IActionResult> SendMsg()
        {
            string BASE_URL = "https://432m1m.api.infobip.com";
            string API_KEY = "842e68394f0dbf4df4e2ef475fb14131-253231a5-3e09-4bc3-98dc-0b8d21ab8237";
            string SENDER = "447860099299";
            string RECIPIENT = "918287817167";

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("App", API_KEY);

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
            StringContent content = new StringContent(message, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(BASE_URL + "/whatsapp/1/message/template", content).Result;
            dynamic jsonResponse = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return Ok(jsonResponse);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("ConsumeAPI")]
        public async Task<IActionResult> ConsumeAPI()
        {
            string BASE_URL = "http://localhost:39192/api/Department/GetAllDepartment";
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(BASE_URL);  
            string stringData = string.Empty;
            //StringContent content = new StringContent(stringData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.GetAsync(BASE_URL).Result;
            dynamic jsonResponse = response.Content.ReadAsStringAsync().Result;
            var statusCode = Convert.ToInt32(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                dynamic deserializeData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                dynamic deserializeResult = deserializeData.data;

                dynamic serializeData = JsonConvert.SerializeObject(deserializeResult);
                //dynamic tripResult = JsonConvert.DeserializeObject<dynamic>(serializeData);

                return Ok(jsonResponse);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("GetPostAPI")]
        public async Task<IActionResult> GetPostAPI(Department dept)
        {
            var url = "http://localhost:39192/api/Department/InsertDepartment";
            /*Department objData = new Department();
            objData.departmentId = 20;
            objData.departmentName = "Hockey";*/

            string jsonString = JsonConvert.SerializeObject(dept);
            StringContent postdata = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpClient.PostAsync(url, postdata);
            dynamic jsonRespone = await httpResponse.Content.ReadAsStringAsync();
            if (httpResponse.IsSuccessStatusCode)
            {
                return Ok(jsonRespone);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
