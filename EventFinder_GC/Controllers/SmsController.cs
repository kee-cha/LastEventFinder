using EventFinder_GC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace EventFinder_GC.Controllers
{
    public class SmsController : TwilioController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        EventApi currentEvent = new EventApi();
        public async System.Threading.Tasks.Task<TwiMLResult> IndexAsync(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Thank you for using our rating system! You gave your event a "+ incomingMessage.Body);
            return TwiML(messagingResponse);
        }        
    }
}