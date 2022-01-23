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
        private readonly IRecordTransactionUseCase recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productRepository = productRepository;
            this.recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int productId, int quantityToSell)
        {
            Product product = productRepository.GetProductById(productId);
            if (product == null)
            {
                return;
            }
            if (product.Quantity >= quantityToSell)
            {
                recordTransactionUseCase.Execute(cashierName, productId, product.Name, quantityToSell);
                product.Quantity -= quantityToSell;
                productRepository.UpdateProduct(product);
            }
        }
    }
}
