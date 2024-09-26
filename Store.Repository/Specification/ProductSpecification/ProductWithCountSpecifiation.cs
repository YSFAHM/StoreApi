using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specification.ProductSpecification
{
    public class ProductWithCountSpecifiation : BaseSpecification<Product>
    {
        public ProductWithCountSpecifiation(ProductSpecification specs)
            : base(p => (!specs.BrandId.HasValue || p.BrandId == specs.BrandId.Value) &&
                        (!specs.TypeId.HasValue || p.BrandId == specs.TypeId.Value)
            && (string.IsNullOrEmpty(specs.Search) || p.Name.Trim().ToLower().Contains(specs.Search))
            )
        {

        }
    }
}
