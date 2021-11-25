using System.Collections.Generic;

namespace PortalCidadao.Application.Model
{
    public class DashboardAtrasadosModel
    {
        public IEnumerable<DashboardAtrasadosItem> Itens { get; set; }
        public int TotalAtrasados { get; set; }
    }

    public class DashboardAtrasadosItem
    {
        public string Mes { get; set; }
        public int QtdPostagens { get; set; }
    }
}
