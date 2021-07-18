using ClopyHotel.Application.Interfaces;
using ClopyHotel.Application.Services;
using ClopyHotel.Domain.CommandHandlers;
using ClopyHotel.Domain.Commands;
using ClopyHotel.Domain.Core;
using ClopyHotel.Domain.Interfaces;
using ClopyHotel.Domain.Models;
using ClopyHotel.Infra.Bus;
using ClopyHotel.Infra.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using URF.Core.Abstractions;
using URF.Core.EF;

namespace ClopyHotel.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Domain layer 
            // services.AddScoped<IRequestHandler<CreateRoomCommand, bool>, CreateRoomCommandHandler>();
            services.AddScoped<IRequestHandler<CreateRoomCommand, Room>, CreateRoomCommandHandler>();
            services.AddScoped<IRequestHandler<CreateRoomTypeCommand, RoomType>, CreateRoomTypeCommandHandler>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Infra layer 
            services.AddScoped<DbContext, ClopyHotelEntities>(x => x.GetService<ClopyHotelEntities>())
                .AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            // Application layer 
            services.AddScoped<IRoomService, RoomService>();

        }
    }
}
