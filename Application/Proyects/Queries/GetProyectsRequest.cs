using Application.Common.Base;
using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Proyects.Queries.Response;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Application.Developers.Queries
{


    public class GetProyectsRequest : IRequest<GetProyectResponse>
    {
        public int ProyectId { get; set; }
    }
    public class GetProyectsRequestHandler : IRequestHandler<GetProyectsRequest, GetProyectResponse>
    {

        private readonly IProyectService _service;

        public GetProyectsRequestHandler(IProyectService proyectService)
        {
            _service = proyectService;
        }

        public async Task<GetProyectResponse> Handle(GetProyectsRequest request, CancellationToken cancellationToken)
        {
            GetProyectResponse proyectResponse = _service.GetProyectById(request.ProyectId);            
            return await Task.FromResult(proyectResponse);
        }
    }
    
}
