﻿using Microsoft.EntityFrameworkCore;
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
    public class EfCoreBranchRepository : EfCoreGenericRepository<Branch>, IBranchRepository
    {
        public EfCoreBranchRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }

        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

        public async Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus)
        {
            return await AppContext
                .Branches
                .Where(b => b.IsApproved == ApprovedStatus)
                .Include(s => s.TeacherBranches)
                .ThenInclude(s => s.Teacher)
                .ThenInclude(s => s.User)
                .ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus)
        {
            return await AppContext
                 .Branches
                 .Where(c => c.IsApproved == ApprovedStatus)
                 .ToListAsync();
        }

        public async Task<List<Branch>> GetBranchesByTeacherAsync(int id)
        {
            List<Branch> branches = await AppContext
                .Branches
                .Where(b => b.IsApproved == true)
                .Include(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Teacher)
                .Where(tb => tb.TeacherBranches.Any(x => x.TeacherId == id))
                .ToListAsync();
            return branches;
        }

        public async Task<Branch> GetBranchFullDataAsync(int id)
        {
            return await AppContext
                .Branches
                .Where(b => b.Id == id)
                .Include(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Teacher)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetBranchNameByUrlAsync(string url)
        {
            Branch branch = await AppContext.Branches.Where(b => b.Url == url).FirstOrDefaultAsync();
            return branch.BranchName;
        }
    }
}
