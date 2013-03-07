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

                if (products.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var product in products)
                        {
                            if (Product.GetById(product.Id) != null)
                                product.Update();
                            else
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
                        foreach (var unitOfMeasure in productsUoms)
                        {
                            if (ProductsUnitOfMeasure.GetById(unitOfMeasure.Id) != null)
                                unitOfMeasure.Update();
                            else
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
                        foreach (var productsPrice in productsPrices)
                        {
                            if (ProductsPrice.GetById(productsPrice.Id) != null)
                                productsPrice.Update();
                            else
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
