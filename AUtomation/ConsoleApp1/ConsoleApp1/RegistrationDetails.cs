using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RegistrationDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }

    public class LoginDetails
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class ContactDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string EmailType { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string Mobile { get; set; }
        public string AddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

    }
    public class CompanyInformation
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string EmailType { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string Number { get; set; }
        public string AddressType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
    public class IdentificationTemplate
    {
        
        public string Subject { get; set; }
        public string Body { get; set; }
        
    }
}
