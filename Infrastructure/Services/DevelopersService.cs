using Application.Interfaces;
using Application.Proyects.Command;
using AutoMapper;
using Database;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class DevelopersService : IDevelopersService
    {
        private readonly IFileDevelopers _fileDevelopers;
        private readonly IFileProyects _fileProyect;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DevelopersService(IFileDevelopers fileDevelopers, IFileProyects fileProyect, IConfiguration configuration)
        {
            _fileDevelopers = fileDevelopers;
            _fileProyect = fileProyect;
            _mapperConfiguration = InitMapperConfigurator();
            _mapper = _mapperConfiguration.CreateMapper();
            _configuration = configuration;
        }

        public IActionResult AddDeveloper(AddDevelopersToProyectCommand request)
        {
            List<Proyect> proyectList = _fileProyect.ReadAll();

            if (proyectList is not null)
            {
                if (proyectList.Exists(p => p.Id == request.ProyectId) && proyectList.FirstOrDefault(p => p.Id == request.ProyectId).IsActive)
                {
                    Developer newDeveloper = _mapper.Map<Developer>(request);
                    _fileDevelopers.AddDeveloper(newDeveloper);
                    return new ObjectResult($"Created Succesfully ") { StatusCode = StatusCodes.Status201Created };
                }
            }
            return new ObjectResult($"Bad request ") { StatusCode = StatusCodes.Status400BadRequest };
        }

        private MapperConfiguration InitMapperConfigurator()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddDevelopersToProyectCommand, Developer>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Developer.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Developer.Name))
                    .ForMember(dest => dest.ProyectId, opt => opt.MapFrom(src => src.ProyectId))
                    .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.Developer.AddedDate)))
                    .ForMember(dest => dest.CostByDay, opt => opt.MapFrom(src => src.Developer.costByDay));
            });
        }
    }
}
