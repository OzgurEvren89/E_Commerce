using AutoMapper;
using Proje.Common.DTOs.MemberAddress;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.MemberAddressViewModels;
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
    public class MemberAddressController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMemberAddressApi _memberAddressApi;
        private readonly IMapper _mapper;

        public MemberAddressController(
            IWebHostEnvironment env,
            IMemberAddressApi memberAddressApi,
            IMapper mapper)
        {
            _env = env;
            _memberAddressApi = memberAddressApi;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<MemberAddressViewModel> list = new List<MemberAddressViewModel>();
            var listResult = await _memberAddressApi.List();

            if (listResult.IsSuccessStatusCode &&
                listResult.Content.IsSuccess &&
                listResult.Content.ResultData.Any())
                list = _mapper.Map<List<MemberAddressViewModel>>(listResult.Content.ResultData);

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateMemberAddressViewModel item)
        {
            if (ModelState.IsValid)
            {
                var insertResult = await _memberAddressApi.Post(_mapper.Map<MemberAddressRequest>(item));
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
            UpdateMemberAddressViewModel model = new UpdateMemberAddressViewModel();
            var updateResult = await _memberAddressApi.Get(id);
            if (updateResult.IsSuccessStatusCode && updateResult.Content.IsSuccess && updateResult.Content.ResultData != null)
                model = _mapper.Map<UpdateMemberAddressViewModel>(updateResult.Content.ResultData);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMemberAddressViewModel item)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _memberAddressApi.Put(item.Id, _mapper.Map<MemberAddressRequest>(item));
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
            var activatedResut = await _memberAddressApi.Activate(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedResut = await _memberAddressApi.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            MemberAddressViewModel model = new MemberAddressViewModel();
            var result = await _memberAddressApi.Get(id);
            if (result.IsSuccessStatusCode && result.Content.IsSuccess && result.Content.ResultData != null)
                model = _mapper.Map<MemberAddressViewModel>(result.Content.ResultData);
            return View(model);
        }
    }
}
