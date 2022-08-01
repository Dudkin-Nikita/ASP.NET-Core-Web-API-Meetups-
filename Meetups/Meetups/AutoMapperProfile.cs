using AutoMapper;
using Meetups.Domain.Entities;
using Meetups.Models.Dto;

namespace Meetups
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Meetup, GetMeetupDto>();
            CreateMap<AddMeetupDto, Meetup>();
            CreateMap<UpdateMeetupDto, Meetup>();
        }
    }
}
