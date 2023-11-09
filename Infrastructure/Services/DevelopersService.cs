using Application.Interfaces;
using Application.Proyects.Command;
using AutoMapper;
using Database;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class DevelopersService : IDevelopersService
    {
        private readonly IFileDevelopers _fileDevelopers;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        public DevelopersService(IFileDevelopers fileDevelopers)
        {
            _fileDevelopers = fileDevelopers;
            _mapperConfiguration = InitMapperConfigurator();
            _mapper = _mapperConfiguration.CreateMapper();
        }

        public void AddDeveloper(AddDevelopersToProyectCommand developer)
        {
            Developer newDeveloper = _mapper.Map<Developer>(developer);
            _fileDevelopers.AddDeveloper(newDeveloper);
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
