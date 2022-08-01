using AutoMapper;
using Meetups.Domain.Entities;
using Meetups.Domain.Repositories.Abstract;
using Meetups.Models;
using Meetups.Models.Dto;

namespace Meetups.Domain.Repositories.EntityFramework
{
    public class EFMeetupsRepository : IMeetupsRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public EFMeetupsRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetMeetupDto>>> GetAll()
        {
            ServiceResponse<List<GetMeetupDto>> serviceResponse = new ServiceResponse<List<GetMeetupDto>>();
            serviceResponse.Data = context.Meetups.Select(m => mapper.Map<GetMeetupDto>(m)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMeetupDto>> GetById(int id)
        {
            ServiceResponse<GetMeetupDto> serviceResponse = new ServiceResponse<GetMeetupDto>();
            serviceResponse.Data = mapper.Map<GetMeetupDto>(context.Meetups.FirstOrDefault(m => m.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMeetupDto>>> Add(AddMeetupDto newMeetup)
        {
            ServiceResponse<List<GetMeetupDto>> serviceResponse = new ServiceResponse<List<GetMeetupDto>>();
            Meetup meetup = mapper.Map<Meetup>(newMeetup);
            context.Meetups.Add(meetup);
            context.SaveChanges();
            serviceResponse.Data = context.Meetups.Select(c => mapper.Map<GetMeetupDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMeetupDto>> Update(UpdateMeetupDto updatedMeetup)
        {
            ServiceResponse<GetMeetupDto> serviceResponse = new ServiceResponse<GetMeetupDto>();

            Meetup meetup = context.Meetups.FirstOrDefault(m => m.Id == updatedMeetup.Id);
            if (meetup != null)
            {
                mapper.Map(updatedMeetup, meetup);
                context.SaveChanges();
                serviceResponse.Data = mapper.Map<GetMeetupDto>(meetup);
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetMeetupDto>>> Delete(int id)
        {
            ServiceResponse<List<GetMeetupDto>> serviceResponse = new ServiceResponse<List<GetMeetupDto>>();
            Meetup meetup = context.Meetups.FirstOrDefault(m => m.Id == id);
            if (meetup != null)
            {
                context.Meetups.Remove(meetup);
                context.SaveChanges();
                serviceResponse.Data = context.Meetups.Select(c => mapper.Map<GetMeetupDto>(c)).ToList();
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found";
            }

            return serviceResponse;
        }
    }
}
