using BenchmarkDotNet.Running;

namespace UnitedModels.Client
{
    internal static class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run<ServiceTest>();
        }
    }
}