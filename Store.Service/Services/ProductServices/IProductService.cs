using Store.Service.Services.ProductServices.Dtos;

namespace Store.Service.Services.ProductServices
{
    public interface IProductService
    {
        Task<ProductDetailsDto> GetProductByIdAsync(int? productId);
        Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();

    }
}
