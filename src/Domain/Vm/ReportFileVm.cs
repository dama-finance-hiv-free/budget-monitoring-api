
namespace Dama.Fin.Domain.Vm
{
    public class ReportFileVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
