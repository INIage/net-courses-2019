using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSimulator.AutoTrade.DbInit;
using TradeSimulator.Core.Models;
using TradeSimulator.Core.Repositories;

namespace TradeSimulator.AutoTrade.Repositories
{
    public class HistoryTableRepository : IHistoryTableRepository
    {
        private readonly TradeSimDbContext dbContext;

        public HistoryTableRepository(TradeSimDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(HistoryEntity entity)
        {
            dbContext.History.Add(entity);
        }

        public ICollection<HistoryEntity> GetHistory()
        {
            return dbContext.History.Select(s=>s).ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
