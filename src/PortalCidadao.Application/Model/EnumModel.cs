using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
