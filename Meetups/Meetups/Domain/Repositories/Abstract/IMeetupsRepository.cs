using Meetups.Domain.Entities;
using Meetups.Models;
using Meetups.Models.Dto;

namespace Meetups.Domain.Repositories.Abstract
{
    public interface IMeetupsRepository
    {
        Task<ServiceResponse<List<GetMeetupDto>>> GetAll();
        Task<ServiceResponse<GetMeetupDto>> GetById(int id);
        Task<ServiceResponse<List<GetMeetupDto>>> Add(AddMeetupDto newMeetup);
        Task<ServiceResponse<GetMeetupDto>> Update(UpdateMeetupDto updatedMeetup);
        Task<ServiceResponse<List<GetMeetupDto>>> Delete(int id);

    }
}
