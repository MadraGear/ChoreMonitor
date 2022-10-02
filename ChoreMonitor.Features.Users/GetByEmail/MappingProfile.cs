namespace ChoreMonitor.Features.Users.GetByEmail
{
    using AutoMapper;
    using ChoreMonitor.Entities;
    
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<User, Result>();
    }
}