using System;
using System.Collections.Generic;
using System.Text;

namespace WeVsVirus.Business.Utility
{
    public class EmailConfiguration
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string SendGridApiKey { get; set; }
    }
}
