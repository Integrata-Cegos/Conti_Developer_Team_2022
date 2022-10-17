using AutoMapper;
using Database.Models;
using Employees;

namespace WebAPI.REST;

public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
        CreateMap<Employee, User>();
    }
}
