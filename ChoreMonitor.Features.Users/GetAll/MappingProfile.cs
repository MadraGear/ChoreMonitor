namespace ChoreMonitor.Features.Users.GetAll
{
    using AutoMapper;
    using ChoreMonitor.Entities;
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<User, Result.User>();
    }
}