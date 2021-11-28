using System.Collections.Generic;

namespace PortalCidadao.Application.Model
{
    public class DashboardAbertosModel
    {
        public IEnumerable<DashboardAbertosItem> Itens { get; set; }
        public int TotalAbertos{ get; set; }
    }

    public class DashboardAbertosItem
    {
        public string Mes { get; set; }
        public int QtdPostagens { get; set; }
    }
}
