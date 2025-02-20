using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dama.Fin.API.Models
{
    public class ActivityQueryParameters
    {
        [BindRequired]
        public string Branch { get; set; }
        [BindRequired]
        public string Region { get; set; }
        [BindRequired]
        public string ActivityType { get; set; }
    }
}
