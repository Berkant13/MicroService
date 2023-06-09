using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformServices.Data;
using PlatformServices.Dtos;
using PlatformServices.Models;
using PlatformServices.SynDataServices.HTTP;

namespace PlatformServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController:ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo repository,IMapper mapper,ICommandDataClient commandDataClient)
        {
            _repository=repository;
            _mapper=mapper;
            _commandDataClient=commandDataClient;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatform()
        {
            Console.WriteLine("-----> Getting Platforms");
            var platformList=_repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformList));
        }
        [HttpGet("{id}",Name="GetById")]
        public ActionResult<PlatformReadDto> GetById(int id)
        {
            Console.WriteLine("----->Getting Platform");
            var platform=_repository.GetPlatformById(id);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
                Console.WriteLine("----->Adding Platform");

                var platformModel=_mapper.Map<Platform>(platformCreateDto);
                _repository.CreatePlatform(platformModel);
                _repository.SaveChanges();
                var platformReadDto=_mapper.Map<PlatformReadDto>(platformModel);
                try{
                    await _commandDataClient.SendPlatformToCommand(platformReadDto);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               return CreatedAtRoute(nameof(GetById),new{Id=platformReadDto.Id},platformReadDto);   
   
        }
    }
}