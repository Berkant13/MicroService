using System.Collections.Generic;
using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        bool saveChanges();
        IEnumerable<Platform> GetAllPlatforms();
    }
}