using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataWebApi.Models
{
    public class EmailDeliveryModel
    {        
            public int emailID { get; set; }
            public string Application { get; set; }
            public string eventDescription { get; set; }
            public string emailAccountDescription { get; set; }
            public string emailReplyAddress { get; set; }
            public string emailAddress { get; set; }
            public string emailCCAddress { get; set; }
            public string emailBCCAddress { get; set; }
            public string Subject { get; set; }
            public string MessageText { get; set; }
            public string Created { get; set; }
            public string Error { get; set; }
            public string ErrorMessage { get; set; }
            public string Sent { get; set; }

    }
}