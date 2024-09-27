using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specification.ProductSpecification;
using Store.Service.Services.Helper;
using Store.Service.Services.ProductServices;
using Store.Service.Services.ProductServices.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
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
