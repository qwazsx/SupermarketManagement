using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productId, int quantityToSell)
        {
            Product product = productRepository.GetProductById(productId);
            if (product == null)
            {
                return;
            }
            if (product.Quantity >= quantityToSell)
            {
                product.Quantity -= quantityToSell;
                productRepository.UpdateProduct(product);
            }
        }
    }
}
