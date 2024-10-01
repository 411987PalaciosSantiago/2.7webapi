using _2._7Back.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7Back.Repository
{
    public interface IServicioRepository
    {
        Task<List<TServicio>>  GetAll();

        Task<TServicio> GetById(int id);

        Task Update(TServicio servicio);

        Task Delete(int id);

        void Add(TServicio servicio);



    }
    public class ServcioRepository : IServicioRepository
    {

        private readonly TurnosdbContext _turnosdbContext;

        public ServcioRepository(TurnosdbContext turnosdbContext)
        {
            _turnosdbContext = turnosdbContext;
        }

        public void Add(TServicio servicio)
        {
            _turnosdbContext.Add(servicio);

            _turnosdbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            //var devuelto = _turnosdbContext.TServicios.Find(id);
            //if (devuelto != null)
            //{
            //    devuelto.isActive = false;
            //    _turnosdbContext.TServicios.Update(devuelto);
            //    _turnosdbContext.SaveChanges();
            //}

            var devuelto = await _turnosdbContext.TServicios.FindAsync(id);
            if (devuelto != null)
            {
                _turnosdbContext.Remove(devuelto);
                _turnosdbContext.SaveChanges();
            }
            
           
        }

        public async Task<List<TServicio>> GetAll() //si recibe parametro se cammbia la condicion del is active
        {
            return await _turnosdbContext.TServicios.ToListAsync();


            //_turnosdbContext.TServicios.Where(p => p.isActivo == true).ToList(); 
        }

        public async Task<TServicio> GetById(int id)
        {
            return await _turnosdbContext.TServicios.FindAsync(id);
        }

        public async Task Update(TServicio servicio)
        {
            var servicioExisting = await  _turnosdbContext.TServicios.FindAsync(servicio.Id);
           
            if(servicioExisting == null)
            {
                return;
            }
            _turnosdbContext.Entry(servicioExisting).CurrentValues.SetValues(servicio);

            await _turnosdbContext.SaveChangesAsync();


            ////
            ///
            //_turnosdbContext.Update(servicio);
            //_turnosdbContext.SaveChanges(); 
        }
    }
}
