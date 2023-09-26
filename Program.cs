using BenchmarkDotNet.Running;

namespace Benchmark
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Run benchmark
			//BenchmarkRunner.Run<MyMappers>();

			// Test mappings is done
			MyMappers myMappers = new MyMappers();
			myMappers.InternalMappingUsingAutoMapper();
			myMappers.InternalMappingUsingMappster();
			myMappers.InternalMappingUsingExtensionMethods();

			var interalUser = new InternalUser();
			interalUser.Balance = 2;
		}
	}
}