﻿using System.Globalization;
using MSS.WinMobile.Infrastructure.Storage;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Model : IModel
    {
        public virtual int Id { get; protected set; }

        public override int GetHashCode()
        {
            return (GetType() + Id.ToString(CultureInfo.InvariantCulture)).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;

            var model = obj as Model;
            return model != null && model.Id == Id;
        }
    }
}
