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
    public class EfCoreImageRepository : EfCoreGenericRepository<Image>, IImageRepository
    {
        public EfCoreImageRepository(OzelDersContext _appContext) : base(_appContext)
        {
        }

        OzelDersContext AppContext
        {
            get { return _dbContext as OzelDersContext; }
        }

    }
}
