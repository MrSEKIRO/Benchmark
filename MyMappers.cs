using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark;
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Default)]
[RankColumn]
public class MyMappers
{
	public UserDto dto;
	private readonly AutoMapper.IMapper _autoMapper;
	private readonly MapsterMapper.IMapper _mapsterMapper;

	public MyMappers()
    {
		// configuration for Automapper
		var config = new MapperConfiguration(cfg => 
		{
			cfg.CreateMap<UserDto, InternalUser>();
			cfg.CreateMap<UserDto, PublicUser>();
		});
		_autoMapper = config.CreateMapper();

		dto = new UserDto()
        {
            Name = "Test",
            Age = 1,
            Balance = 2,
            Email = "someemail@gmail.com",
            Password = "password",
        };
    }

	[Benchmark]
	public void InternalMappingUsingAutoMapper()
	{
		var user = _autoMapper.Map<InternalUser>(dto);
	}

	[Benchmark]
	public void InternalMappingUsingMappster()
	{
		// even without configuration
		var user = dto.Adapt<InternalUser>();
	}

	[Benchmark]
	public void InternalMappingUsingExtensionMethods()
	{
		var user = dto.ToInternalUser();
	}

	[Benchmark]
    public void PublicMappingUsingAutoMapper()
    {
        var user = _autoMapper.Map<PublicUser>(dto);
    }

	[Benchmark]
	public void PublicMappingUsingMappster()
	{
		var user = dto.Adapt<PublicUser>();
	}

	[Benchmark]
	public void PublicMappingUsingExtensionMethods()
	{
		PublicUser user = dto.ToPublicUser();
	}
}
