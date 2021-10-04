using System;
using PortalCidadao.Shared.Extensions;

namespace PortalCidadao.Application.Model
{
    public class EnumModel
    {
        public EnumModel()
        {

        }

        public EnumModel(Enum enumItem)
        {
            Codigo = enumItem.GetEnumValue();
            Nome = enumItem.GetEnumName();
            Descricao = enumItem.GetEnumDescription();
        }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
