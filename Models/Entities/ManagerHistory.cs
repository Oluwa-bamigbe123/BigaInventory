using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalBetBiga.Models.Entities
{
    public class ManagerHistory : BaseEntity
    {
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }
        public string AgentName { get; set; }
        public string AgentAddress { get; set; }
    }
}
