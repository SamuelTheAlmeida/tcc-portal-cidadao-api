﻿using System;
using PortalCidadao.Domain.Models;

namespace PortalCidadao.Application.Model
{
    public class ComentarioModel
    {
        public int Id { get; set; }
		public string Descricao { get; set; }
		public DateTime DataCadastro { get; set; } = DateTime.Now;
		public int UsuarioId {get; set;}
		public int PostagemId {get; set;}
        public string NomeUsuario { get; set; }

    }
}
