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
    public class TypeBuildingRepository:ITypeBuildingRepository
    {
        private WarContext warContext;

        public TypeBuildingRepository(WarContext warContext)
        {
            this.warContext = warContext;
        }

        public async Task<TypeBuilding> GetById(int code)
        {
            return await warContext.TypesBuildings.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task<List<TypeBuilding>> GetAll()
        {
            return await warContext.TypesBuildings.ToListAsync();
        }

        public async Task<int> Add(TypeBuilding typeBuilding)
        {
            warContext.TypesBuildings.Add(typeBuilding);
            return await warContext.SaveChangesAsync();
        }

        public async Task<int> Update(TypeBuilding typeBuilding)
        {
            var x = await warContext.TypesBuildings.Where(x => x.Code == typeBuilding.Code).FirstAsync();
            warContext.Entry(x).CurrentValues.SetValues(typeBuilding);
            return await warContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int code)
        {
            var x = warContext.TypesBuildings.Where(x => x.Code == code).FirstOrDefault();
            warContext.TypesBuildings.Remove(x);
            return await warContext.SaveChangesAsync();
        }
    }
}
