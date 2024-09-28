using app.Infrastructure;
using app.Repository;
using app.Tests.Test.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace app.Tests.Test.Repository
{
    public class TimeTrackerRepoRepositoryTest
    {
        private readonly TimeTrackerContext _context;

        public TimeTrackerRepoRepositoryTest()
        {
            
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            
            _context = new TimeTrackerContext(optionsBuilder.Options);
        }

        [Fact]
        private void Should_Create_Time_Tracking()
        {
            //Arrange
            var timeBank = MockTimebank.TimeBanks();
            
            var repo = new TimeTrackerRepoRepository(_context);

            //Act
            bool result = repo.AddTimeTracker(timeBank);


            //Assert
            Assert.True(result);           
        }
        
        [Fact]
        private void Should_NotCreate_Time_Tracking()
        {
            //Arrange
            var timeBank = MockTimebank.TimeBanks();

            _context.TimeBanks.Add(timeBank);
            _context.SaveChanges();
            
            var repo = new TimeTrackerRepoRepository(_context);

            //Act
            bool result = repo.AddTimeTracker(timeBank);

            //Assert
            Assert.False(result);           
        }
    }
}