using Microsoft.EntityFrameworkCore;
using OzelDersApp.Data.Abstract;
using OzelDersApp.Data.Concrete.EfCore.Context;
using OzelDersApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Data.Concrete.EfCore
{
    public class EfCoreAdvertRepository : EfCoreGenericRepository<Advert>, IAdvertRepository
    {
        public EfCoreAdvertRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }

        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task<Advert> GetAdvertFullDataAsync(int id)
        {
            var advert = await AppContext
                            .Adverts
                            .Where(b => b.Id == id)
                            .Include(t => t.Teacher)
                            .ThenInclude(bc => bc.TeacherBranches)
                            .ThenInclude(tb=> tb.Branch)
                            .Include(t => t.Teacher)
                            .ThenInclude(u=> u.User)
                            .ThenInclude(b => b.Image)
                            .FirstOrDefaultAsync();
            return advert;
        }

        public Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus)
        {
            var adverts = AppContext
                .Adverts
                .Where(t => t.IsApproved == approvedStatus)
                .Include(a => a.Teacher)
                .ThenInclude(u => u.User)
                .ThenInclude(i => i.Image)
                .Include(a => a.Teacher)
                .ThenInclude(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .AsQueryable();
            if (id != null)
            {
                adverts = adverts.Where(a => a.Teacher.User.Id == id);
            }
            return adverts.ToListAsync();
        }

        public async Task<List<Advert>> GetAdvertsHomeFullDataAsync(bool ApprovedStatus, string branchname = null)
        {
            var adverts = AppContext
                .Adverts
                .Where(t => t.IsApproved == ApprovedStatus)
                .Include(a => a.Teacher)
                .ThenInclude(u => u.User)
                .ThenInclude(i => i.Image)
                .Include(a => a.Teacher)
                .ThenInclude(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .AsQueryable();
            if (branchname != null)
            {
                adverts = adverts.Where(t => t.Branch.BranchName == branchname);
            }
            return await adverts.ToListAsync();
        }

        public Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus)
        {
            var adverts = AppContext
                       .Adverts
                       .Where(a => a.IsApproved == approvedStatus)
                       .Include(a => a.Teacher)
                       .ThenInclude(u => u.User)
                       .ThenInclude(i => i.Image)
                       .Include(a => a.Teacher)
                       .ThenInclude(t => t.TeacherBranches)
                       .ThenInclude(tb => tb.Branch)                      
                       .ToListAsync();
            return adverts;
        }

        public Task<int> GetByUrlAsync(string url)
        {
            var result = AppContext
                            .Adverts
                            .Where(b => b.Url == url)
                            .Select(b => b.Id)
                            .FirstOrDefaultAsync();
            return result;
        }
    }
}
