using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Texter.Connections
{
    public class TextConnection
    {
        readonly string _SID;
        readonly string _Token;
        readonly IOptions<DbConfiguration> _dbConfig;

        // Connection class is built by .Net Configuration.

        public TextConnection(IOptions<DbConfiguration> dbConfig)
        {
            // builds field values from appsettings.json
            _SID = dbConfig.Value.SID;
            _Token = dbConfig.Value.Token;
            _dbConfig = dbConfig;
        }

        // Uses phoneNumber from controller to send a text message using Twilio.

        public void SendMessage(string phoneNumber)
        {

            TwilioClient.Init(_SID, _Token);

            var message = MessageResource.Create(
                body: "Please hire Rich Fisher (pretty please?) - https://www.linkedin.com/in/rich-fisher-2a496719/",
                from: new Twilio.Types.PhoneNumber("+12054489575"),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }
    }
}
