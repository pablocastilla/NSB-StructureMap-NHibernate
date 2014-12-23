using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class UnitTestDetector
    {
        static UnitTestDetector()
        {
            string testAssemblyName = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
            UnitTestDetector.IsInUnitTest = AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.FullName.StartsWith(testAssemblyName));
        }

        public static bool IsInUnitTest { get; private set; }
    }
}
