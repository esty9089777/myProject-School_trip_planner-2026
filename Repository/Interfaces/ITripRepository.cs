using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITripRepository:IRepository<Trip>
    {
        Task<List<Trip>> GetTripsByUserId(int userId);

    }
}
