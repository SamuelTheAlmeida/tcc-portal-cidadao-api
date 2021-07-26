using System.Collections.Generic;
using AutoMapper;
using PortalCidadao.Application.Model;
using PortalCidadao.Application.Repositories;
using PortalCidadao.Application.Services.Interfaces;
using PortalCidadao.Domain.Enums;

namespace PortalCidadao.Application.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IMapper _mapper;
        private readonly IPostagemRepository _repository;

        public PostagemService(IPostagemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BaseModel<IEnumerable<PostagemModel>> ListarTodos() =>
            new(true, EMensagens.RealizadaComSucesso, _mapper.Map<IEnumerable<PostagemModel>>(
                _repository.ListarTodos()));
    }
}
