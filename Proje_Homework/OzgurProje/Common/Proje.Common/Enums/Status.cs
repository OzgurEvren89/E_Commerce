using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.Enums
{
    public enum Status
    {
        None = 0,
        Active = 1,
        Deleted = 3,
        Updated = 5
    }
}
//classları sql de yapacağım için kullanmayacağım. Çevirmek gerekirse CodeFirste diye alt yaoı maksadıyla yaptım. Bunun yerine Status adında class yapacağım SQL'de