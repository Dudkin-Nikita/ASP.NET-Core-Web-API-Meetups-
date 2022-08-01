using Meetups.Domain.Repositories.Abstract;

namespace Meetups.Domain
{
    public class DataManager
    {
        public IMeetupsRepository Meetups { get; set; }
        public DataManager(IMeetupsRepository meetupsRepository)
        {
            Meetups = meetupsRepository;
        }
    }
}
