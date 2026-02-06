using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class CreateGameSessionModel
    {
        public string Title { get; set; }    
        public string Description { get; set; }
        public int GameCfgId { get; set; }
        public Guid MasterId { get; set; }
        public DateTime ScheduleDate { get; set; }

    }
}
