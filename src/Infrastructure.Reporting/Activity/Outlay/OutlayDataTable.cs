using System.Data;

namespace Dama.Fin.Infrastructure.Reporting.Activity.Outlay
{
    public class OutlayDataTable
    {
        public DataTable weekTable { get; set; }
        public DataTable monthTable { get; set; }
        public DataTable compTable { get; set; }
        public DataTable yearTable { get; set; }
    }
}
