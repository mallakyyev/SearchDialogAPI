using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchDialogAPI.Models
{
    public class RGDialogsClients
    {
        public Guid IDUnique { get; set; }
        public Guid IDRGDialog { get; set; }
        public Guid IDClient { get; set; }
        public DateTime? DateEvent { get; set; }
    }
}
