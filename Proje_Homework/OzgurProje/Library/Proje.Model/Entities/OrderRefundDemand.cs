using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class OrderRefundDemand : CoreEntity
    {        
        public string Reason { get; set; }
        public string Details { get; set; }
        public string ResultStatus { get; set; }//onaylanmadı olarak api atayacak, admin inceleyip onaylandıya çekebilecek.
        public decimal Fee { get; set; }//kabul edilmesi durumunda geri ödenecek tutar.
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public User CreatedUserOrderRefundDemand { get; set; }
        public User ModifiedUserOrderRefundDemand { get; set; }
    }
}
