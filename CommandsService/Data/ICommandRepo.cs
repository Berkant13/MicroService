using System.Collections.Generic;
using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        // Platforms
        bool saveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatfrom(Platform plat);
        bool PlatformExists(int platformId);

        // Commands
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);
        
    }
}