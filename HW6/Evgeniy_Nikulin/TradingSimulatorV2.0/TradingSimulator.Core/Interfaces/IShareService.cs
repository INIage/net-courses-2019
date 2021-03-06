namespace TradingSimulator.Core.Interfaces
{
    using System.Collections.Generic;
    using Dto;
    public interface IShareService
    {
        List<Share> GetShareList(string OwnerId);
        Share GetShareByIndex(int ownerId, int index);
        string AddShare(string shareName, string price, string quantity, string ownerId);
        string ChangeShare(string shareId, string newName, string newPrice, string ownerId);
    }
}