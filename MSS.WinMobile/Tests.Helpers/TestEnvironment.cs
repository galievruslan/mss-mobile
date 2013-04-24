using System;
using System.IO;
using System.Reflection;

namespace Tests.Helpers
{
    public static class TestEnvironment
    {
        public static string GetApplicationDirectory()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (directoryName != null)
            {
                return directoryName.Replace("file:\\", "");
            }
            
            throw new Exception("Executing assembly directory not found!");
        }
    }
}
