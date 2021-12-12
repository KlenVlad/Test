using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class VoteContext : DbContext
    {
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteStats> VoteStats { get; set; }

        public VoteContext() : base()
        {
        }
    }
}
