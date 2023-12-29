using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text;
using System.Text.Json;

namespace WhatsAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        [HttpPost("SendMsg")]
        public async Task<IActionResult> SendMsg()
        {            
            var instanceId = 72793;
            var tokenId = "6xsbdu9odkbjmgys";
            var to = "8287817167";
            var message = "hi i am testing whats app msg.";

            var url = $"https://api.ultramsg.com/instance{instanceId}/messages/chat";

            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);

            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("token", tokenId);
            request.AddParameter("to", to);
            request.AddParameter("body", message);

            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var output = response.Content;
                return Ok(output);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("SendWhatsAppMsg")]
        public async Task<IActionResult> SendWhatsAppMsg(RequestModel model)
        {           
            var url = $"https://api.ultramsg.com/instance{model.InstanceId}/messages/chat";
            var data = new
            {
                token = model.TokenId,
                to = model.SendTo,
                body = model.Message
            };
            string jsonString = JsonSerializer.Serialize(data);
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
