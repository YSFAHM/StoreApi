using Store.Data.Entities;
using Store.Repository.Specification.ProductSpecification;
using Store.Service.Helper;
using Store.Service.Services.ProductServices.Dtos;

namespace Store.Service.Services.ProductServices
{
    public interface IProductService
    {
        Task<ProductDetailsDto> GetProductByIdAsync(int? productId);
        Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync();
        Task<PaginatedResult<ProductDetailsDto>> GetAllProductsAsync(ProductSpecification specs);
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();

    }
}
