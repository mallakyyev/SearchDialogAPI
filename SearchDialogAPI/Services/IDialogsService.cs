using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchDialogAPI.Models;

namespace SearchDialogAPI.Services
{
    public interface IDialogsService
    {
        public Guid GetRGDialog(List<Guid> userIds);
    }
}
