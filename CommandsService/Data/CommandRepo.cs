using System.Collections.Generic;
using System.Linq;
using CommandService.Models;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;
        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(int platformId, Command command)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePlatfrom(Platform plat)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new System.NotImplementedException();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId)
                .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExists(int platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}