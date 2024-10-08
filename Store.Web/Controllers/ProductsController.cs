using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specification.ProductSpecification;
using Store.Service.Helper;
using Store.Service.Services.ProductServices;
using Store.Service.Services.ProductServices.Dtos;
using Store.Web.Helper;

namespace Store.Web.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) 
        { 
            _productService = productService;
        }

        [HttpGet]
        //[Route("api/methodName")]
        //[HttpGet("name")]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllBrands()
        {
            return Ok(await _productService.GetAllBrandsAsync());
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
        {
            return Ok(await _productService.GetAllTypesAsync());
        }

        [HttpGet]
        [Cache(30)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet]
        
        //check
        public async Task<ActionResult<PaginatedResult<ProductDetailsDto>>> GetAllProductsWithSpecification([FromQuery]ProductSpecification input)
        {
            return Ok(await _productService.GetAllProductsAsync(input));
        }

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int? id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));
        }
    }
}
