using Core.IRepositories_Data;
using Core.Model;
using Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices_Bll
{
    public interface IAddressService
    {
        Task<int> AddAddress(AddressResource address);
        Task<List<AddressResource>> GetPlaces();
        Task<List<AddressResource>> GetTenPlaces(Location location);
    }
}
