using System.Threading.Tasks;
using PlatformServices.Dtos;

namespace PlatformServices.SynDataServices.HTTP
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);


    }
}