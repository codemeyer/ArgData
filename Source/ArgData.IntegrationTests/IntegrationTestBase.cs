using System.IO;
using System.Reflection;

namespace ArgData.IntegrationTests
{
    public class IntegrationTestBase
    {
        protected string GetExampleDataPath(string fileName)
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            return Path.Combine(assemblyDirectory,  string.Format(@"ExampleData\{0}", fileName));
        }
    }
}
