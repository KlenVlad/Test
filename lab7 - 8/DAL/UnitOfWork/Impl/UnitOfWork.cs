using DAL.EF;
using DAL.Repositories.Abstract;
using DAL.Repositories.Impl;
using DAL.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private VoteContext context;

        private VoteRepository voteRepository;
        private VoteStatsRepository voteStatsRepository;

        public UnitOfWork(VoteContext context)
        {
            this.context = context;
        }

        public IVoteRepository Votes
        {
            get
            {
                if (voteRepository == null)
                    voteRepository = new VoteRepository(context);
                return voteRepository;
            }
        }

        public IVoteStatsRepository VoteStats
        {
            get
            {
                if (voteStatsRepository == null)
                    voteStatsRepository = new VoteStatsRepository(context);
                return voteStatsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable realization

        private bool disposed = false;        

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
