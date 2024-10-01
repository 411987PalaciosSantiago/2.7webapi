using _2._7Back.Data.Models;
using _2._7Back.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7Back.Service
{

    public interface IServiceServicio
    {
        Task<List<TServicio>> GetAll();

        Task<TServicio> GetById(int id);

        Task Update(TServicio servicio);

        void Delete(int id);

        void Add(TServicio servicio);
    }


    public class ServiceServicio : IServiceServicio
    {
        private readonly IServicioRepository _repository;

        public ServiceServicio(IServicioRepository repository)
        {
            _repository = repository;
        }

        public void Add(TServicio servicio)
        {
            _repository.Add(servicio);

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<TServicio> GetById(int id)
        {
            return  await _repository.GetById(id);
        }

        public async Task Update(TServicio servicio)
        {
            await _repository.Update(servicio);
        }
    }
}
