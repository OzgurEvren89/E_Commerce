using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class AddressType : CoreEntity
    {
        public string TypeName { get; set; }
        public User CreatedUserAddressType { get; set; }
        public User ModifiedUserAddressType { get; set; }
    }
}
