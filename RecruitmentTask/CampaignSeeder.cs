using RecruitmentTask.Entities;
using RecruitmentTask.Models;

namespace RecruitmentTask
{
    public class CampaignSeeder
    {
        private readonly CampaignDbContext _dbContext;
        public CampaignSeeder(CampaignDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Campaigns.Any())
                {
                    var campaign = new Campaign()
                    {
                        BidAmount = 10,
                        CampaignFund = 50,
                        Keywords = "Offer, occasion, chance",
                        Name = "Example Campaign",
                        Radius = 10,
                        Status = Status.On,
                        Town = "Cracow"
                    };
                    _dbContext.Add(campaign);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.EmeraldAccounts.Any())
                {
                    var emeraldAccount = new EmeraldAccount();
                    _dbContext.Add(emeraldAccount);
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
