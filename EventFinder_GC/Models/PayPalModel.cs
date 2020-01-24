﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace EventFinder_GC.Models
{
    public class PayPalModel
    {
        private bool useSandbox;

        public PayPalModel()
        {

        }
       

        public string Cmd { get; set; }
        public string business { get; set; }
        public string no_shipping { get; set; }

        public string @return { get; set; }
        public string cancel_return { get; set; }
        public string notify_url { get; set; }
        public string currency_code { get; set; }
        public string EventName { get; set; }
        public string amount { get; set; }
        public string actionURL { get; set; }

        public PayPalModel(bool useSandbox)
        {
            this.Cmd = "_xclick";
            this.business = ConfigurationManager.AppSettings["business"];
            this.cancel_return = ConfigurationManager.AppSettings["cancel_return"];
            this.@return = ConfigurationManager.AppSettings["return"];
            if (useSandbox)
            {
                this.actionURL = ConfigurationManager.AppSettings["test_url"];
            }
            else
            {
                this.actionURL = ConfigurationManager.AppSettings["Prod_u"];
            }
            // We can add parameters here, for example OrderId, CustomerId, etc….
            this.notify_url = ConfigurationManager.AppSettings["notify_url"];
            // We can add parameters here, for example OrderId, CustomerId, etc….
            this.currency_code = ConfigurationManager.AppSettings["currency_code"];
        }


    }
}