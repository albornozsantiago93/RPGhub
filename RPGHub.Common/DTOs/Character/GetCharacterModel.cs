using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class GetCharacterModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public string? Stats { get; set; }
        public string? Inventory { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? GameSessionId { get; set; }
    }
}
