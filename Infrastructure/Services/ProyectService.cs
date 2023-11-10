using Application.Developers.Queries.Response;
using Application.Interfaces;
using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
using AutoMapper;
using Database;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            _mapper = _mapperConfiguration.CreateMapper();
            _configuration = configuration;
        }

        public IActionResult DeleteProyect(int proyectId)
        {
            return _fileProyects.DeleteProyect(proyectId);
        }

        public GetProyectResponse GetProyectById(int proyectId)
        {
            Proyect proyect = _fileProyects.GetProyectById(proyectId);
            return _mapper.Map<GetProyectResponse>(proyect);
            
        }

        private int GetDevelopmentCost(List<Developer> developers, int effortInDays)
        {
            int result = -1;
            if (developers is not null)
            {
                developers.ForEach(developer =>
                {
                    result += developer.CostByDay * effortInDays;
                });
            }
            return result;
        }

        private MapperConfiguration InitMapperConfigurator()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Developer, DeveloperDTO>()
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToUnixTimeMilliseconds()))
                    ;

                cfg.CreateMap<Proyect, GetProyectResponse>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                    .ForMember(dest => dest.addedDate, opt => opt.MapFrom(src => src.addedDate.ToUnixTimeMilliseconds()))
                    .ForMember(dest => dest.effortRequireInDays, opt => opt.MapFrom(src => src.EffortRequiredInDays))
                    .ForMember(dest => dest.developmentCost, opt => opt.MapFrom(src => GetDevelopmentCost(_fileDevelopers.GetDevelopersByProyectId(src.Id), src.EffortRequiredInDays)))
                    .ForMember(dest => dest.Developers, opt => opt.MapFrom(src => _fileDevelopers.GetDevelopersByProyectId(src.Id)))
                    ;

            });
        }
    }
}
