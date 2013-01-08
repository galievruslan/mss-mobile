﻿using MSS.WinMobile.Infrastructure.Data.Repositories.Specifications;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Repositories.Specifications
{
    public abstract class Converter<T> {
        protected Specification<T> Specification; 

        protected Converter(Specification<T> specification) {
            Specification = specification;
        }

        public abstract string Convert();
    }
}