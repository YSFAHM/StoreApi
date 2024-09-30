using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductSpecification;
using Store.Service.Helper;
using Store.Service.Services.ProductServices.Dtos;


namespace Store.Service.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();
            IReadOnlyList<BrandTypeDetailsDto> mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);
            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsNoTrackingAsync();
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);
            return mappedProducts;
        }


        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();
            IReadOnlyList<BrandTypeDetailsDto> mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);
            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId is null) throw new Exception("Id Is Null");
            var specs = new ProductWithSpecification(productId);
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecifcationByIdAsync(specs);
            if (product is null) throw new Exception("Product Not Found");
            var mappedProduct = _mapper.Map<ProductDetailsDto>(product);
            return mappedProduct;
        }
        public async Task<PaginatedResult<ProductDetailsDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecification(input);
            
            var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecifcationAsync(specs);
            var countSpecs = new ProductWithCountSpecifiation(input);
            var count = await _unitOfWork.Repository<Product, int>().GetCountSpecificationAsync(countSpecs);
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);
            return new PaginatedResult<ProductDetailsDto>(input.PageIndex,input.PageSize,count,mappedProducts);
        }
    }
}
