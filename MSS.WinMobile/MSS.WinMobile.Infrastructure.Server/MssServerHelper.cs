using System;
using System.Collections.Generic;
using System.Text;
using Mss.WinMobile.Domain.Model;

namespace MSS.WinMobile.Infrastructure.Server
{
    public static class MssServerHelper
    {
        public static string GetControllerName(Type type)
        {
            string controllerName = string.Empty;
            if (type.Equals(typeof(Manager)))
            {
                controllerName = "managers";
            }
            else 
            {
                throw new ControllerForTypeNotFoundException(type);
            }

            return controllerName;
        }

        public class ControllerForTypeNotFoundException : Exception
        {
            public ControllerForTypeNotFoundException(Type type)
                : base(string.Format(@"Controller for type ""{0}"" not found", type)) { }
        }
    }
}
