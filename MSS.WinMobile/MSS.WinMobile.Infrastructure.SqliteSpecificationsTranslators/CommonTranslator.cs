using System;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class CommonTranslator<TModel> : ISpecificationTranslator<TModel> where TModel : IModel {
        public virtual string Translate(ISpecification<TModel> specification) {
            if (specification is WithIdSpec<TModel>) {
                return string.Format("Id = {0}", (specification as WithIdSpec<TModel>).Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }

    public class TranslatorNotFoundExceprion : Exception {
        public TranslatorNotFoundExceprion(Type type)
            : base(string.Format("Translator for \"{0}\" not found", type)) {}
    }
}
