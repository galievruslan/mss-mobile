using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeProducts : SynchronizationCommand {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeProducts));

        private readonly Server _server;

        public SynchronizeProducts(Server server, ISession session)
            :base(session) {
            _server = server;
        }

        protected override bool Execute() {
            var products = new List<Product>();
            var productsUoms = new List<ProductsUnitOfMeasure>();
            var productsPrices = new List<ProductsPrice>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var productsDtos = _server.ProductService.GetProducts(pageNumber, itemsPerPage);
            while (productsDtos.Length > 0)
            {
                foreach (var productDto in productsDtos)
                {
                    var product = new Product
                    {
                        Id = productDto.Id,
                        Name = productDto.Name,
                    };
                    if (productDto.CategoryId != 0)
                        product.CategoryId = productDto.CategoryId;

                    products.Add(product);

                    foreach (var productUomDto in productDto.ProductUnitOfMeasures)
                    {
                        var productUom = new ProductsUnitOfMeasure
                        {
                            Id = productUomDto.Id,
                            ProductId = productDto.Id,
                            UnitOfMeasureId = productUomDto.UnitOfMeasureId,
                            Base = productUomDto.Base
                        };
                        productsUoms.Add(productUom);
                    }

                    foreach (var productPriceDto in productDto.ProductPrices)
                    {
                        var productPrice = new ProductsPrice
                        {
                            Id = productPriceDto.Id,
                            ProductId = productDto.Id,
                            PriceListId = productPriceDto.PriceListId,
                            Price = productPriceDto.Price
                        };
                        productsPrices.Add(productPrice);
                    }
                }

                SynchronizeEntity(products);
                SynchronizeEntity(productsUoms);
                SynchronizeEntity(productsPrices);
                products.Clear();
                productsUoms.Clear();
                productsPrices.Clear();

                pageNumber++;
                productsDtos = _server.ProductService.GetProducts(pageNumber, itemsPerPage);
            }
            return true;
        }
    }
}
