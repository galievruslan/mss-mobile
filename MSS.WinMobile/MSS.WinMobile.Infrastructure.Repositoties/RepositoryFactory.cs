using System;
using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties {
    public class RepositoryFactory : IRepositoryFactory {

        private readonly Dictionary<Type, object> _registredSpecTranslators;
        private readonly IStorage _storage;
        public RepositoryFactory(IStorage storage) {
            _storage = storage;
            _registredSpecTranslators = new Dictionary<Type, object>();  
        }

        public RepositoryFactory RegisterSpecificationTranslator<TModel>(
            ISpecificationTranslator<TModel> specificationTranslator) where TModel : IModel {
            if (_registredSpecTranslators.ContainsKey(typeof (TModel))) {
                _registredSpecTranslators[typeof (TModel)] = specificationTranslator;
            }
            else {
                _registredSpecTranslators.Add(typeof(TModel), specificationTranslator);
            }
            return this;
        }

        public IStorageRepository<TModel> CreateRepository<TModel>()
            where TModel : IModel {

            var specificationTranslator =
                _registredSpecTranslators[typeof (TModel)] as ISpecificationTranslator<TModel>;

            if (typeof (TModel) == typeof (Category)) {
                return
                    (IStorageRepository<TModel>)
                    new CategoryStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<Category>);
            }
            if (typeof(TModel) == typeof(Customer)) {
                return
                    (IStorageRepository<TModel>)
                    new CustomerStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<Customer>,
                                                   this);
            }
            if (typeof(TModel) == typeof(OrderItem)) {
                return
                    (IStorageRepository<TModel>)
                    new OrderItemStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<OrderItem>);
            }
            if (typeof(TModel) == typeof(Order)) {
                return
                    (IStorageRepository<TModel>)
                    new OrderStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<Order>, this);
            }
            if (typeof(TModel) == typeof(PriceList)) {
                return
                    (IStorageRepository<TModel>)
                    new PriceListStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<PriceList>, this);
            }
            if (typeof(TModel) == typeof(Product)) {
                return
                    (IStorageRepository<TModel>)
                    new ProductStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<Product>);
            }
            if (typeof(TModel) == typeof(ProductsPrice)) {
                return
                    (IStorageRepository<TModel>)
                    new ProductsPriceStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<ProductsPrice>);
            }
            if (typeof(TModel) == typeof(ProductsUnitOfMeasure)) {
                return
                    (IStorageRepository<TModel>)
                    new ProductsUnitOfMeasureStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<ProductsUnitOfMeasure>);
            }
            if (typeof(TModel) == typeof(RoutePoint)) {
                return
                    (IStorageRepository<TModel>)
                    new RoutePointStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<RoutePoint>);
            }
            if (typeof(TModel) == typeof(RoutePointTemplate)) {
                return
                    (IStorageRepository<TModel>)
                    new RoutePointTemplateStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<RoutePointTemplate>);
            }
            if (typeof(TModel) == typeof(Route)) {
                return
                    (IStorageRepository<TModel>)
                    new RouteStorageRepository(_storage,
                                               specificationTranslator as
                                               ISpecificationTranslator<Route>, this);
            }
            if (typeof(TModel) == typeof(RouteTemplate)) {
                return
                    (IStorageRepository<TModel>)
                    new RouteTemplateStorageRepository(_storage,
                                                       specificationTranslator as
                                                       ISpecificationTranslator<RouteTemplate>, this);
            }
            if (typeof(TModel) == typeof(ShippingAddress)) {
                return
                    (IStorageRepository<TModel>)
                    new ShippingAddressStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<ShippingAddress>);
            }
            if (typeof(TModel) == typeof(Status)) {
                return
                    (IStorageRepository<TModel>)
                    new StatusStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<Status>);
            }
            if (typeof(TModel) == typeof(UnitOfMeasure)) {
                return
                    (IStorageRepository<TModel>)
                    new UnitOfMeasureStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<UnitOfMeasure>);
            }
            if (typeof(TModel) == typeof(Warehouse)) {
                return
                    (IStorageRepository<TModel>)
                    new WarehouseStorageRepository(_storage,
                                                   specificationTranslator as
                                                   ISpecificationTranslator<Warehouse>);
            }

            throw new RepositoryForTypeNotFoundException(typeof(TModel));
        }
    }

    public class RepositoryForTypeNotFoundException : Exception {
        public RepositoryForTypeNotFoundException(Type type)
            : base(string.Format("Repository for type \"{0}\" not found", type)) {}
    }
}
