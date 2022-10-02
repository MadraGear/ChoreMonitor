namespace ChoreMonitor.Features.Chores.Create
{
    using AutoMapper;
    using ChoreMonitor.Entities;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Command, Chore>(MemberList.Source);
            CreateMap<Chore, Result>(MemberList.Source);
        }
    }
}