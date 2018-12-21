using System;
using System.Collections.Generic;

namespace UserType.Contracts.Model
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public string Address { get; set; }
        public string NgoName { get; set; }
        public string password { get; set; }


    }
}
