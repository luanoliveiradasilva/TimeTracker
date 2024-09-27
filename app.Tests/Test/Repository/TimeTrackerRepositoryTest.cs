using app.Infrastructure;
using app.Models.Datas;
using app.Repository;
using app.Tests.Test.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace app.Tests.Test.Repository
{
    public class TimeTrackerRepositoryTest
    {
        private readonly TimeTrackerContext _context;

        public TimeTrackerRepositoryTest()
        {
            
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            
            _context = new TimeTrackerContext(optionsBuilder.Options);
        }

        [Fact]
        public void Should_Create_Time_Tracking()
        {
            //Arrange
            var timeBank = MockTimebank.TimeBanks();
            
            var repo = new TimeTrackerRepository(_context);

            //Act
            bool result = repo.AddTask(timeBank);


            //Assert
            Assert.True(result);           
        }
        
        [Fact]
        public void Should_NotCreate_Time_Tracking()
        {
            //Arrange
            var timeBank = MockTimebank.TimeBanks();

            _context.TimeBanks.Add(timeBank);
            _context.SaveChanges();
            
            var repo = new TimeTrackerRepository(_context);

            //Act
            bool result = repo.AddTask(timeBank);

            //Assert
            Assert.False(result);           
        }
    }
}