using Meetups.Domain.Entities;

namespace Meetups.Domain.Repositories.Abstract
{
    public interface IMeetupsRepository
    {
        List<Meetup> GetAll();
        Meetup GetById(int id);
        void Add(Meetup meetup);
        void Update(Meetup meetup);
        void Delete(int id);

    }
}
