using AutoMapper;
using Proje.Common.DTOs.PhoneNumberType;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberTypeViewModels;
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
    public class PhoneNumberTypeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPhoneNumberTypeApi _phoneNumberTypeApi;
        private readonly IMapper _mapper;

        public PhoneNumberTypeController(
            IWebHostEnvironment env,
            IPhoneNumberTypeApi phoneNumberTypeApi,
            IMapper mapper)
        {
            _env = env;
            _phoneNumberTypeApi = phoneNumberTypeApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PhoneNumberTypeViewModel> list = new List<PhoneNumberTypeViewModel>();
            var listResult = await _phoneNumberTypeApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PhoneNumberTypeViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreatePhoneNumberTypeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _phoneNumberTypeApi.Post(_mapper.Map<PhoneNumberTypeRequest>(item));
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
            UpdatePhoneNumberTypeViewModel model = new UpdatePhoneNumberTypeViewModel();
            var updateResult = await _phoneNumberTypeApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdatePhoneNumberTypeViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePhoneNumberTypeViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _phoneNumberTypeApi.Put(item.Id, _mapper.Map<PhoneNumberTypeRequest>(item));
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
            var activatedResut = await _phoneNumberTypeApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _phoneNumberTypeApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            PhoneNumberTypeViewModel model = new PhoneNumberTypeViewModel();
            var result = await _phoneNumberTypeApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<PhoneNumberTypeViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
