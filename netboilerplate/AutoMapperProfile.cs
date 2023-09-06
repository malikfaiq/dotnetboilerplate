using System;
namespace netboilerplate
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Character, GetCharacterDto>()
                .ForMember(dest =>
            dest.Backpack, opt => opt.MapFrom(src => new AddBackpackDto { Description = src.Backpack.Description }));
            CreateMap<AddCharacterDto, Character>().ForMember(dest =>
			dest.Backpack, opt=>opt.MapFrom(src=> new AddBackpackDto { Description = src.Backpack.Description}));
			CreateMap<UpdateCharacterDto, Character>();

            CreateMap<AddBackpackDto, Backpack>();
        }
    }
}

