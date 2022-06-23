using AutoMapper;
using Proje.Common.DTOs.AddressType;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.AddressTypeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class AddressTypeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAddressTypeApi _addressTypeApi;
        private readonly IMapper _mapper;

        public AddressTypeController(
            IWebHostEnvironment env,
            IAddressTypeApi addressTypeApi,
            IMapper mapper)
        {
            _env = env;
            _addressTypeApi = addressTypeApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AddressTypeViewModel> list = new List<AddressTypeViewModel>();
            var listResult = await _addressTypeApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<AddressTypeViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateAddressTypeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _addressTypeApi.Post(_mapper.Map<AddressTypeRequest>(item));
                if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            UpdateAddressTypeViewModel model = new UpdateAddressTypeViewModel();
            var updateResult = await _addressTypeApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateAddressTypeViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAddressTypeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _addressTypeApi.Put(item.Id, _mapper.Map<AddressTypeRequest>(item));
                if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            }
            else
                TempData["Message"] = "İşlem başarısız oldu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Activate(Guid id)
        {
            var activatedResut = await _addressTypeApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _addressTypeApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            AddressTypeViewModel model = new AddressTypeViewModel();
            var result = await _addressTypeApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<AddressTypeViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
