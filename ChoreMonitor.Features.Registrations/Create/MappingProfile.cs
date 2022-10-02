using AutoMapper;
using ChoreMonitor.Entities;

namespace ChoreMonitor.Features.Registrations.Create
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Command, Registration>(MemberList.Source);
            CreateMap<Registration, Result>(MemberList.Source);
            CreateMap<User, Result.User>(MemberList.Source);
            CreateMap<Chore, Result.Chore>(MemberList.Source);
        }
    }
}