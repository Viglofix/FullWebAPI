using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Helper;

namespace DataBase.Services
{
    public interface IMorenService
    {
         Task<List<AutoMapperMorenHeroes>> GetAll();
         Task<List<AutoMapperMorenLocations>> GetAllLocations();
         Task<AutoMapperMorenHeroes> GetSingle(int id);
         Task<dynamic> Create(AutoMapperMorenHeroes heroMapper);
         Task<dynamic> Put(AutoMapperMorenHeroes heroMapper, int id);
         Task<APIresponse> Delete(int id);
    }
}
