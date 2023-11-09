using Application.Interfaces;
using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;
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
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;
        public ProyectService(IFileDevelopers fileDevelopers)
        {
            _fileDevelopers = fileDevelopers;
            _mapperConfiguration = InitMapperConfigurator();
        }
        public void AddDeveloper(AddDevelopersToProyectCommand developer)
        {
            
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
