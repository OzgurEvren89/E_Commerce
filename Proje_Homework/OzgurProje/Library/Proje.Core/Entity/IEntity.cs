using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Core.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
//classları sql de yapacağım için kullanmayacağım. Çevirmek gerekirse CodeFirste diye alt yaoı maksadıyla yaptım 