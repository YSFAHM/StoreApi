using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using Store.Service.Services.ProductServices.Dtos;
using Store.Service.Services.ProductServices;
using Store.Service.HandleResponses;
using Store.Service.Services.CacheService;
using Store.Service.Services.BasketService.Dtos;
using Store.Service.Services.BasketService;
using Store.Repository.Basket;
using Store.Service.Services.TokenService;
using Store.Service.Services.UserService;

namespace Store.Web.Extensions
{
    public static class ApplicatioServiceExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(BasketProfile));
            services.AddAutoMapper(typeof(BasketItemDto));
            services.AddScoped<IBasketRepository,BasketRepository>();

            services.Configure<ApiBehaviorOptions>(options =>
            {

                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                .Where(model => model.Value?.Errors.Count > 0)
                                .SelectMany(model => model.Value.Errors)
                                .Select(error => error.ErrorMessage)
                                .ToList();
                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            //return services;
        }
    }
}
