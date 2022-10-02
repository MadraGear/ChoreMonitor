namespace ChoreMonitor.Features.Registrations.WeekDashboard
{
    using AutoMapper;
    using ChoreMonitor.Entities;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Registration, Result.Registration>()
                .ForMember(d => d.CookedOne, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(d => d.PerformedChore, opt => opt.MapFrom(src => src.Chore.Name));
        }        
    }
}