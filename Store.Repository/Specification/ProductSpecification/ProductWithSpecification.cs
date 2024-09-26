using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecification
{
    public class ProductWithSpecification : BaseSpecification<Product>
    {
        public ProductWithSpecification(ProductSpecification specs) 
            : base(p => (!specs.BrandId.HasValue || p.BrandId == specs.BrandId.Value) &&
                        (!specs.TypeId.HasValue || p.BrandId == specs.TypeId.Value) && (string.IsNullOrEmpty(specs.Search) || p.Name.Trim().ToLower().Contains(specs.Search))
            )
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
            //check
            AddOrderBy(p => p.Id);

            ApplyPagiantion(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
            if (!string.IsNullOrEmpty(specs.Sort))
            {
                switch (specs.Sort)
                {
                    case "Asc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "Desc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    default:
                        AddOrderBy(p => p.Id);
                        break;
                }
            }
        }
        public ProductWithSpecification(int? id)
            : base(p => p.Id == id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);

        }


    }
}
