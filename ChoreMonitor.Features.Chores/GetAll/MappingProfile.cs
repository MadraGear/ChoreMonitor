namespace ChoreMonitor.Features.Chores.GetAll
{
    using AutoMapper;
    using ChoreMonitor.Entities;
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<Chore, Result.Chore>();
    }
}