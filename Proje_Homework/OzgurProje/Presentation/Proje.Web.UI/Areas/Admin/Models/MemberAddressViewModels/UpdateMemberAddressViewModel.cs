using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels
{
    public class UpdateMemberAddressViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string TCLD { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        [Required(ErrorMessage = "Adres sdınızı belirtmeniz zorunludur.")]
        public string AddressName { get; set; }
        [Required(ErrorMessage = "Adres Tipi Id'si alanı zorunludur.")]
        public Guid AddressTypeId { get; set; }
        [Required(ErrorMessage = "Şehir kodu alanı zorunludur.")]
        public int CityCode { get; set; }
        [Required(ErrorMessage = "İlçe kodu alanı zorunludur.")]
        public int CountyCode { get; set; }
        [Required(ErrorMessage = "Adres alanı zorunludur.")]
        public string Address { get; set; }
    }
}
