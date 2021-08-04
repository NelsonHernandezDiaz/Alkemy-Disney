using Disney.Domain.Common;
using System.Collections.Generic;

namespace Disney.Application.Models
{
    public class EmailInfo
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
    }
}
