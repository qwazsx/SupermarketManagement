﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewProductsByCategorId : IViewProductsByCategorId
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByCategorId(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return productRepository.GetProductsByCategorId(categoryId);
        }
    }
}
