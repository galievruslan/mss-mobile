using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Local.Data;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fullFilePath = string.Format(@"{0}\{1}",
            //                                    Path.GetDirectoryName(
            //                                        Assembly.GetExecutingAssembly()
            //                                              .GetName()
            //                                              .CodeBase),
            //                                    storageName);

            ISession session = new Session("testStorage.sdf");
            
        }
    }
}
