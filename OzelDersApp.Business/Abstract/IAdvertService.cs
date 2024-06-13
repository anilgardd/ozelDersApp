using OzelDersApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Business.Abstract
{
    public interface IAdvertService
    {
        Task CreateAsync(Advert advert);
        Task<Advert> GetByIdAsync(int id);
        Task<List<Advert>> GetAllAsync();
        void Update(Advert advert);
        void Delete(Advert advert);
        Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus);
        Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus);
        Task<Advert> GetAdvertFullDataAsync(int id);
        Task<int> GetByUrlAsync(string url);

        Task<List<Advert>> GetAdvertsHomeFullDataAsync(bool ApprovedStatus, string branchname = null);


    }
}
