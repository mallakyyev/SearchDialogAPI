using SearchDialogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchDialogAPI.Services
{
    public class DialogsService : IDialogsService
    {
        /// <summary>
        /// Initializa all users and dialogs 
        /// </summary>
        /// <returns>List of all Dialogs and corresponding users </returns>
        private List<RGDialogsClients> Init()
        {
            List<RGDialogsClients> L1 = new List<RGDialogsClients>();


            var IDClient1 = new Guid("4b6a6b9a-2303-402a-9970-6e71f4a47151");
            var IDClient2 = new Guid("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820");
            var IDClient3 = new Guid("7de3299b-2796-4982-a85b-2d6d1326396e");
            var IDClient4 = new Guid("0a58955e-342f-4095-88c6-1109d0f70583");
            var IDClient5 = new Guid("50454d55-a73c-4cbc-be25-3c5729dcb82b");

            Guid IDRGDialog1 = new Guid("fcd6b112-1834-4420-bee6-70c9776f6378");




            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog1,
                IDClient = IDClient1
            });

            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog1,
                IDClient = IDClient2
            });


            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog1,
                IDClient = IDClient3
            });


            Guid IDRGDialog2 = new Guid("19f6f751-7f8d-41fa-8261-709028650592");

            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog2,
                IDClient = IDClient1
            });

            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog2,
                IDClient = IDClient2
            });

            Guid IDRGDialog3 = new Guid("83ebeb2b-c315-48a2-b6e5-f0324de57a9f");


            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog3,
                IDClient = IDClient3
            });

            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog3,
                IDClient = IDClient4
            });

            L1.Add(new RGDialogsClients
            {
                IDUnique = Guid.NewGuid(),
                IDRGDialog = IDRGDialog3,
                IDClient = IDClient5
            });

            return L1;


        }
        /// <summary>
        /// Returns DialogId from all dialogs that contains all(best match) users ids from "userIds"
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns>DialogId</returns>
        public Guid GetRGDialog(List<Guid> userIds)
        {
            //Get all dialogs from the Init() function
            List<RGDialogsClients> dialogs = Init();
            
            // Group all dialogs by Dialog Ids. For each dialog id store list of user ids that corresponds to this dialog id
            var results = dialogs.GroupBy(p =>  new { p.IDRGDialog })
                .Select(b => new ReturnModel
                {
                    DialogId = b.Key.IDRGDialog,
                    UserIds = b.Select(uid => uid.IDClient).ToList()
                });

            // try to find best match : Find dialogid that contains all of the users inside userIds and that have minimum extra users that is not in userIds
            int min = int.MaxValue;
            Guid bestDialog = new Guid();
            
            foreach(var item in results)
            {
                if(userIds.Except(item.UserIds).Count() == 0)
                {
                    int extraUsersCount = Math.Abs(item.UserIds.Distinct().Count() - userIds.Distinct().Count());
                    if (extraUsersCount < min)
                    {
                        min = extraUsersCount;
                        bestDialog = item.DialogId;
                    }
                }
            }
            
            return bestDialog;
        }
    }
}
