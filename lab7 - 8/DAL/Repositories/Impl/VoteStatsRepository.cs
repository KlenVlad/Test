using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class VoteStatsRepository : BaseRepository<VoteStats>, IVoteStatsRepository
    {
        public VoteStatsRepository(VoteContext context) : base(context)
        {
        }
    }
}
