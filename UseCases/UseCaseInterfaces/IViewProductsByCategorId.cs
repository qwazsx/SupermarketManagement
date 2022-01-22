using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewProductsByCategorId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}