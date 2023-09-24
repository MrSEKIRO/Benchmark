using BenchmarkDotNet.Running;

namespace Benchmark
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<MyMappers>();

			//MyMappers myMappers = new MyMappers();
			//myMappers.MappingUsingAutoMapper();
			//myMappers.MappingUsingMappster();
			//myMappers.MappingUsingExtensionMethods();
		}
	}
}