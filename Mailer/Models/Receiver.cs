using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mailer.Models
{
    public class Receiver
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}