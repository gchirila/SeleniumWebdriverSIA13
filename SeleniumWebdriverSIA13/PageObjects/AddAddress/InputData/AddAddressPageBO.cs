using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriverSIA13.PageObjects.AddAddress.InputData
{
    public class AddAddressPageBO
    {
        public string FirstName { get; set; } = "Default first name";
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Color { get; set; }
    }
}
