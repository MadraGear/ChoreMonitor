using AutoMapper;
using ChoreMonitor.Entities;

namespace ChoreMonitor.Features.Users.Create
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Command, User>(MemberList.Source);
            CreateMap<User, Result>(MemberList.Source);
        }
    }
}