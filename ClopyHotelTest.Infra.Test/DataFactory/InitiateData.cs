using ClopyHotel.Domain.Models;
using ClopyHotel.Infra.Data;

namespace ClopyHotelTest.Infra.Test.DataFactory
{
    public static class InitiateData
    {
        public static ClopyHotelInMemoryEntities InitiateDataContext(ClopyHotelInMemoryEntities context)
        {
            for (var i = 1; i <= 10; i++)
            {
                var roomType = new RoomType() { RoomTypeId = i, RoomTypeName = i.ToString(), Active = true };
                var room = new Room() { RoomId = i, RoomName = "0"+i.ToString(), RoomTypeId = i, Description = "Room " + i.ToString()  };
                context.RoomTypes.Add(roomType);
                context.Rooms.Add(room);
            }
            context.SaveChanges();
            return context;
        }
    }
}
