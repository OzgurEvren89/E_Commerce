﻿using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels
{
    public class InstallmentRateViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public int Installment { get; set; }       
        public decimal Rate { get; set; }
        public Guid PaymentGatewayId { get; set; }
        public PaymentGatewayViewModel PaymentGateway { get; set; }       
        public DateTime? CreatedDate { get; set; }
    }
}
