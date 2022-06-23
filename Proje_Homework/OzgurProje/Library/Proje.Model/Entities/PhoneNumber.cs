using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class PhoneNumber : CoreEntity
    {
        public string Number { get; set; }      
        public string PhoneNumberType { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public User CreatedUserPhoneNumber { get; set; }
        public User ModifiedUserPhoneNumber { get; set; }
    }
}
