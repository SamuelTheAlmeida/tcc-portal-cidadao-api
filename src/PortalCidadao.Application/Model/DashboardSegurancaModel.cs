using System.Collections.Generic;

namespace PortalCidadao.Application.Model
{
    public class DashboardSegurancaModel
    {
        public IEnumerable<DashboardSegurancaItem> DashboardSeguranca { get; set; }
    }

    public class DashboardSegurancaItem
    {
        public string Horario { get; set; }
        public int Quantidade { get; set; }
    }
}
