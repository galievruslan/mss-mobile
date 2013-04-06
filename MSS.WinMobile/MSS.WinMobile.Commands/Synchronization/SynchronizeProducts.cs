using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeProducts : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeProducts));

        private readonly Server _server;

        public SynchronizeProducts(Server server)
        {
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
                    var product = productDto.CategoryId == 0 ? new Product(productDto.Id, productDto.Name) : new Product(productDto.Id, productDto.Name, productDto.CategoryId);
                    products.Add(product);

                    foreach (var productUomDto in productDto.ProductUnitOfMeasures)
                    {
                        var productUom = new ProductsUnitOfMeasure(productUomDto.Id, productDto.Id,
                                                                   productUomDto.UnitOfMeasureId, productUomDto.Base);
                        productsUoms.Add(productUom);
                    }

                    foreach (var productPriceDto in productDto.ProductPrices)
                    {
                        var productPrice = new ProductsPrice(productPriceDto.Id, productDto.Id,
                                                             productPriceDto.PriceListId, productPriceDto.Price);
                        productsPrices.Add(productPrice);
                    }
                }

                if (products.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var product in products) {
                            product.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                if (productsUoms.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var unitOfMeasure in productsUoms) {
                            unitOfMeasure.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                if (productsPrices.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var productsPrice in productsPrices) {
                            productsPrice.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

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
