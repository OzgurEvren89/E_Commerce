using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proje.Web.UI.APIs;
using Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proje.Web.UI.ViewComponents
{
    public class InstallmentRateViewComponent : ViewComponent
    {
        private readonly IInstallmentRateApi _installmentRatedApi;
        private readonly IPaymentGatewayApi _paymentGatewayApi;
        private readonly IProductApi _productApi;
        private readonly IMapper _mapper;

        public InstallmentRateViewComponent(IInstallmentRateApi installmentRatedApi, IPaymentGatewayApi paymentGatewayApi, IProductApi productApi, IMapper mapper)
        {
            _installmentRatedApi = installmentRatedApi;
            _paymentGatewayApi = paymentGatewayApi;
            _productApi = productApi;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            List<PaymentGatewayViewModel> list = new List<PaymentGatewayViewModel>();
            var listResult = await _paymentGatewayApi.GetActive();
            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
                list = _mapper.Map<List<PaymentGatewayViewModel>>(listResult.Content.ResultData);


            foreach (var item in list)
            {
                var installmentRateList= await _installmentRatedApi.GetActive();
                var rateList = _mapper.Map<List<InstallmentRateViewModel>>(installmentRateList.Content.ResultData);
                var resultList = rateList.Where(x => x.PaymentGatewayId == item.Id).ToList();
                item.InstallmentRates = resultList;
            }

           ProductViewModel product = new ProductViewModel();
            var proResult = await _productApi.Get(id);
            if (proResult.IsSuccessStatusCode && proResult.Content.IsSuccess)
                product = _mapper.Map<ProductViewModel>(proResult.Content.ResultData);

            //List<ProductPriceViewModel> pricelist = new List<ProductPriceViewModel>();
            //var priceResult = await _productPriceApi.GetActive();
            //if (priceResult.IsSuccessStatusCode && priceResult.Content.IsSuccess && priceResult.Content.ResultData.Any())
            //    pricelist = _mapper.Map<List<ProductPriceViewModel>>(priceResult.Content.ResultData);
            //var prices = pricelist.Where(x => x.ProductId == id).ToList();

            //product.ProductPrices = prices;


            return View(Tuple.Create<ProductViewModel, List<PaymentGatewayViewModel>>(product, list));
            
            
        }
    }
}
