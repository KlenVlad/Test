using DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IVoteRepository Votes { get; }
        IVoteStatsRepository VoteStats { get; }        

        void Save();
    }
}
