using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ConsoleApp
{
    public class TwilioWhatsApp
    {
        public static void WhatsAppMsg()
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            var accountSid = "AC2be3a5bc963007574fe114056afecaef";
            var authToken = "90f6cf03ef890b1e5e3d01be92eb78ce";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            body: "Hello india!",
            from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            to: new Twilio.Types.PhoneNumber("whatsapp:+918287817167")
        );
            Console.WriteLine(message.Status);
        }
    }
}
