using Meetups.Domain.Entities;
using Meetups.Domain.Repositories.Abstract;

namespace Meetups.Domain.Repositories.EntityFramework
{
    public class EFMeetupsRepository : IMeetupsRepository
    {
        private readonly AppDbContext context;
        public EFMeetupsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<Meetup> GetAll()
        {
            return context.Meetups.ToList();
        }

        public Meetup GetById(int id)
        {
            return context.Meetups.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Meetup meetup)
        {
            context.Meetups.Add(meetup);
            context.SaveChanges();
        }

        public void Update(Meetup request)
        {
            Meetup meetup = context.Meetups.Find(request.Id);
            meetup.Name = request.Name;
            meetup.Description = request.Description;
            meetup.Plan = request.Plan;
            meetup.Speeker = request.Speeker;
            meetup.Organizer = request.Organizer;
            meetup.Place = request.Place;
            meetup.Date = request.Date;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Meetups.Remove(new Meetup() { Id = id });
            context.SaveChanges();
        }
    }
}
