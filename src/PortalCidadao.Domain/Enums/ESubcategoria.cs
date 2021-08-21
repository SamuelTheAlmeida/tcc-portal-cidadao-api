using System.ComponentModel;

namespace PortalCidadao.Domain.Enums
{
    public enum ESubcategoria
    {
        [Description("Reclamação")]
        Reclamacao = 1,
        [Description("Elogio")]
        Elogio = 2,
        [Description("Sugestão")]
        Sugestao = 3
    }
}
