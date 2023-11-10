using Application.Interfaces;
using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
using AutoMapper;
using Database;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProyectService : IProyectService
    {
        private readonly IFileDevelopers _fileDevelopers;
        private readonly IFileProyects _fileProyects;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public ProyectService(IFileDevelopers fileDevelopers, IFileProyects fileProyects, IConfiguration configuration)
        {
            _fileDevelopers = fileDevelopers;
            _fileProyects = fileProyects;
            _mapperConfiguration = InitMapperConfigurator();
            _configuration = configuration;
        }
        public void AddDeveloper(AddDevelopersToProyectCommand developer)
        {
            
        }

        public List<Proyect> GetAll()
        {
            return _fileProyects.ReadAll();
        }

        private MapperConfiguration InitMapperConfigurator()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddDevelopersToProyectCommand, Developer>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Developer.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Developer.Name))
                    .ForMember(dest => dest.ProyectId, opt => opt.MapFrom(src => src.Developer.ProyectId))
                    .ForMember(dest => dest.addedDate, opt => opt.MapFrom(src => src.Developer.AddedDate))
                    .ForMember(dest => dest.costByDay, opt => opt.MapFrom(src => src.Developer.costByDay));
            });
        }
    }
}
