namespace TradeSimulator.Core.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StockPriceInfo
    {
        public int Id { get; set; }

        public string TypeOfStock { get; set; }

        public decimal PriceOfStock { get; set; }
    }
}
