using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalogue.Models
{
    public class ResponseMessage
    {
        public int statusCode { get; set; }
        public string response_Message { get; set; }
        public object data { get; set; }
    }
}
