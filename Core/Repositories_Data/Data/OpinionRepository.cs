using Core.IRepositories_Data;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Data.Data
{
    public class OpinionRepository:IOpinionRepository
    {
        private WarContext warContext;

        public OpinionRepository(WarContext warContext)
        {
            this.warContext = warContext;
        }

        public async Task<Opinion> GetById(int code)
        {
            return await warContext.Opinions.Where(x => x.Code == code).Include(o=> o.Adress).FirstOrDefaultAsync();
        }

        public async Task<List<Opinion>> GetAll()
        {
            return await warContext.Opinions.Include(o => o.Adress).ToListAsync();
        }

        public async Task<int> Add(Opinion opinion)
        {
            warContext.Opinions.Add(opinion);
            return await warContext.SaveChangesAsync();
        }

        public async Task<int> Update(Opinion opinion)
        {
            var x = await warContext.Opinions.Where(x => x.Code == opinion.Code).FirstAsync();
            warContext.Entry(x).CurrentValues.SetValues(opinion);
            return await warContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int code)
        {
            var x = warContext.Opinions.Where(x => x.Code == code).FirstOrDefault();
            warContext.Opinions.Remove(x);
            return await warContext.SaveChangesAsync();
        }
    }
}
