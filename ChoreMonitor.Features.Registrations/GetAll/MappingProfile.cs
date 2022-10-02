namespace ChoreMonitor.Features.Registrations.GetAll
{
    using AutoMapper;
    using ChoreMonitor.Entities;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, Result.User>();
            CreateMap<Chore, Result.Chore>();
            CreateMap<Registration, Result.Registration>()
                .ForMember(d => d.CookedOne, opt => opt.MapFrom(src => src.User))
                .ForMember(d => d.PerformedChore, opt => opt.MapFrom(src => src.Chore));
        }        
    }
}