using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IProductApi _productApi;
        private readonly IUserApi _userApi;
        private readonly IProductImageApi _productimageApi;
        private readonly IMapper _mapper;

        public HomeController(IWebHostEnvironment env, IProductApi productApi, IUserApi userApi, IProductImageApi productimageApi, IMapper mapper)
        {
            _env = env;
            _productApi = productApi;
            _userApi = userApi;
            _productimageApi = productimageApi;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

    
    }
}
