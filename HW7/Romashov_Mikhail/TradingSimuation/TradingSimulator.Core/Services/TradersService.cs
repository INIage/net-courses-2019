﻿using System;
using System.Collections.Generic;
using System.Text;
using TradingSimulator.Core.Dto;
using TradingSimulator.Core.Interfaces;
using TradingSimulator.Core.Models;
using TradingSimulator.Core.Repositories;

namespace TradingSimulator.Core.Services
{
    public class TradersService : ITraderService
    {
        private readonly ITraderTableRepository traderTableRepository;
        public TradersService(ITraderTableRepository traderTableRepository)
        {
            this.traderTableRepository = traderTableRepository;
        }

        public int RegisterNewTrader(TraderInfo trader)
        {
            var entityToAdd = new TraderEntityDB()
            {
                CreatedAt = DateTime.Now,
                Name = trader.Name,
                Surname = trader.Surname,
                PhoneNumber = trader.PhoneNumber,
                Balance = trader.Balance
            };

            if (traderTableRepository.Contains(entityToAdd))
            {
                throw new ArgumentException($"This trader {entityToAdd.Name} {entityToAdd.Surname} has been registered.");
            }
            traderTableRepository.Add(entityToAdd);

            traderTableRepository.SaveChanges();

            return entityToAdd.Id;
        }
        public TraderEntityDB GetTraderById(int traderID)
        {
            if (!traderTableRepository.ContainsById(traderID))
            {
                throw new ArgumentException($"Can`t get trader by this Id = {traderID}.");
            }
            return traderTableRepository.GetById(traderID);
        }
        public TraderEntityDB GetTraderByName(string traderName)
        {
            if (!traderTableRepository.ContainsByName(traderName))
            {
                throw new ArgumentException($"Can`t get trader by this Name = {traderName}.");
            }
            return traderTableRepository.GetByName(traderName);
        }

        public bool ContainsByName(string traderName)
        {
            return traderTableRepository.ContainsByName(traderName);
        }
        public decimal GetBalanceById(int traderId)
        {
            var item = this.GetTraderById(traderId);
            return item.Balance;
        }

        public List<int> GetList()
        {
            return traderTableRepository.GetListTradersId();
        }

        public int GetCountIds()
        {
            return traderTableRepository.CountIds();
        }

        public List<string> GetListOfTraders(int maxCount)
        {
            var traders = traderTableRepository.GetListOfTraders();
            List<string> retVal = new List<string>();

            foreach (var item in traders)
            {
                if (retVal.Count == maxCount)
                    break;
                retVal.Add(string.Concat(item.Name + " " + item.Surname));
            }
            return retVal;
        }
    }
}
