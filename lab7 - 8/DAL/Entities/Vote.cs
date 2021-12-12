using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Vote : BaseEntity
    {
        public string VoteDescription { get; set; }
        public int VoteStatsId { get; set; }
        public int VoteChoose { get; set; }
        public int VoteStatus { get; set; }

        public virtual VoteStats VoteStats { get; set; }
    }
}
