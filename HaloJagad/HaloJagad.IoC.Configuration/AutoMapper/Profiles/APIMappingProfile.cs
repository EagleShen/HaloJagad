using AutoMapper;

using DC = HaloJagad.API.DataContracts;
using S = HaloJagad.Services.Model;

namespace HaloJagad.IoC.Configuration.AutoMapper.Profiles
{
	public class APIMappingProfile : Profile
	{
		public APIMappingProfile()
		{
			CreateMap<DC.User, S.User>().ReverseMap();
			CreateMap<DC.Address, S.Address>().ReverseMap();
		}
	}
}
