using DoktorSelector.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoktorSelector.DB
{
    public interface IDataAccessProvider
    {
        void AddDoktorItemRecord(DoktorItem doktor);
        void UpdateDoktorItemRecord(DoktorItem doktor);
        void DeleteDoktorItemRecord(int id);
        DoktorItem GetDoktorItemSingleRecord(int id);
        List<DoktorItem> GetDoktorItemRecords(string specialty);
        // Task<List<DoktorItem>> GetDoktorItemRecordsAsync(string specialty, string hospital);
    }
}
