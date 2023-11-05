using AutoMapper;
using DataBase.Helper;
using DataBase.Models;
using DataBase.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Dynamic;
using System.Reflection;
using DataBase.DynamicOperations;

namespace DataBase.Container
{
    public class MorenService : IMorenService
    {
        private readonly MorenDatabaseDbContext _dbMorenContext;
        private readonly IMapper _mapper;
        public MorenService(MorenDatabaseDbContext _dbMorenContext, IMapper _mapper)
        {
            this._dbMorenContext = _dbMorenContext;
            this._mapper = _mapper;
        }

        public async Task<dynamic> Create(AutoMapperMorenHeroes heroMapper)
        {
            APIresponse _response = new();
            dynamic objToDynamic = _response.ToDynamic();
            try
            {
                MorenModelHeroes model = this._mapper.Map<AutoMapperMorenHeroes, MorenModelHeroes>(heroMapper);

                // dynamic operations

                DynamicOperations.DynamicOperations.RemoveProperty(objToDynamic, "Result");
                DynamicOperations.DynamicOperations.RemoveProperty(objToDynamic, "ErrorMessage");

                await _dbMorenContext.AddAsync(model);
                await _dbMorenContext.SaveChangesAsync();
                var _serializeObjToSend = JsonConvert.SerializeObject(model);
                objToDynamic!.StringResult = _serializeObjToSend;
                objToDynamic.ResponseCode = 201;
            }
            catch(Exception ex)
            {
                _response.ResponseCode = 404;
                _response.ErrorMessage = ex.Message;
            }
            return objToDynamic;
        }

        public async Task<APIresponse> Delete(int id)
        {
                APIresponse _response = new();
               try
               {
                var async_DbContextToList = await this._dbMorenContext.morenherotable.ToListAsync();
                var findObj = async_DbContextToList.Find(obj => obj.Id_Hero == id);
                if (findObj is not null)
                {
                    _dbMorenContext.morenherotable.Remove(findObj);
                    await _dbMorenContext.SaveChangesAsync();

                    _response.ResponseCode = 201;
                    _response.Result = id;
                }
                else
                {
                    _response.ResponseCode = 404;
                    _response.Result = id;
                }
               }
               catch(Exception ex)
               {
                _response.ResponseCode = 400;
                _response.ErrorMessage = ex.Message;
               }
                return _response;
             } 
        public async Task<List<AutoMapperMorenHeroes>> GetAll()
        {
            List<AutoMapperMorenHeroes> _respone = new();
            var async_DbContextToList = await this._dbMorenContext.morenherotable.ToListAsync();

            if(async_DbContextToList is not null)
            {
                _respone = this._mapper.Map<List<MorenModelHeroes>, List<AutoMapperMorenHeroes>>(async_DbContextToList);
            }
            return _respone;
        }

        public async Task<List<AutoMapperMorenLocations>> GetAllLocations()
        {
            List<AutoMapperMorenLocations> _response = new();
            var async_DbContextToList = await _dbMorenContext.morenlocationtable.ToListAsync();
            if(async_DbContextToList is not null)
            {
                _response = this._mapper.Map<List<MorenModelLocations>, List<AutoMapperMorenLocations>>(async_DbContextToList);
            }
            return _response;
        }

        public async Task<AutoMapperMorenHeroes> GetSingle(int id)
        {
            AutoMapperMorenHeroes _response = new();
            var async_DbContextToList = await _dbMorenContext.morenherotable.FindAsync(id);
            if(async_DbContextToList is not null)
            {
                _response = this._mapper.Map<MorenModelHeroes, AutoMapperMorenHeroes>(async_DbContextToList);
            }
            return _response;
        }

        public async Task<dynamic> Put(AutoMapperMorenHeroes heroMapper, int id)
        {
            APIresponse _response = new();
            dynamic objToDynamic = _response.ToDynamic();
            try
            {
                var async_DbContextToList = await this._dbMorenContext.morenherotable.ToListAsync();
                var findObj = async_DbContextToList.Find(obj => obj.Id_Hero == id);
                if (findObj is not null)
                {
                    findObj.Name = heroMapper.Name;
                    findObj.IsActive = heroMapper.IsActive;
                    await this._dbMorenContext.SaveChangesAsync();

                    DynamicOperations.DynamicOperations.RemoveProperty(objToDynamic, "StringResult");
                    DynamicOperations.DynamicOperations.RemoveProperty(objToDynamic, "ErrorMessage");

                    objToDynamic.ResponseCode = 200;
                    objToDynamic.Result = id;
                }
                else
                {
                    _response.ResponseCode = 404;
                    _response.ErrorMessage = "Data not found";
                }
            }
            catch (Exception ex)
            {
                _response.ResponseCode = 400;
                _response.ErrorMessage = ex.Message;
            }
            return objToDynamic;
        }
    }
}
