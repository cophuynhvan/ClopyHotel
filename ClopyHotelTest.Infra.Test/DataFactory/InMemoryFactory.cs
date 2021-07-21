using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClopyHotel.Infra.Data;
using Microsoft.EntityFrameworkCore;


namespace ClopyHotelTest.Infra.Test.DataFactory
{
    public class InMemoryFactory
    {
        public static ClopyHotelInMemoryEntities CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ClopyHotelInMemoryEntities>()
                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
                 .Options;
            var dbContext = new ClopyHotelInMemoryEntities(options);
            return dbContext;
        }
    }
}
