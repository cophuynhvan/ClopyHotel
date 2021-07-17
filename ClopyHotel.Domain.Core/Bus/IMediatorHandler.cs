using System.Threading.Tasks;

namespace ClopyHotel.Domain.Core
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
