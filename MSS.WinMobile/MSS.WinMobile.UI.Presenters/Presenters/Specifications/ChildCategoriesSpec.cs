using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specifications {
    public class ChildCategoriesSpec : ISpecification<Category> {
        public Category Category { get; protected set; }
        public ChildCategoriesSpec(Category parentCategory) {
            Category = parentCategory;
        }
    }
}
