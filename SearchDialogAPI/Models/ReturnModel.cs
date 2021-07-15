using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchDialogAPI.Models
{
    public class ReturnModel
    {
        public Guid DialogId { get; set; }
        public List<Guid> UserIds { get; set; }
    }
}
