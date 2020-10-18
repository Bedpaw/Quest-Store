using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Core.Entities;
using QuestStore.Core.Interfaces;

namespace QuestStore.API.Controllers
{
    public class QuestsController : GenericController<Quest>
    {
        public QuestsController(IRepository<Quest> repository) : base(repository)
        {
        }
    }
}
