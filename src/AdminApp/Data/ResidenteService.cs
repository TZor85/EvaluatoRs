using AdminApp.Models.Residentes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Data
{
    public class ResidenteService
    {

        private static readonly List<Residente> Residentes = new List<Residente>
        {
            new Residente { Id=Guid.NewGuid().ToString(), FirstName = "Minerva", LastName = "Martinez Cano", YearResident = 2, Especialidad = 1},
            new Residente { Id=Guid.NewGuid().ToString(), FirstName = "Luis Angel", LastName = "Martinez González", YearResident = 1, Especialidad = 3},
            new Residente { Id=Guid.NewGuid().ToString(), FirstName = "Natividad", LastName = "Cázarez Santos", YearResident = 4, Especialidad = 7},
            new Residente { Id=Guid.NewGuid().ToString(), FirstName = "Maribel", LastName = "Picazo Reyes", YearResident = 1, Especialidad = 2},
        };

        public Task<List<Residente>> GetResidentesAsync()
        {
            return Task.FromResult(Residentes);
        }

        public Task<List<Residente>> AddResidentesAsync(Residente residente)
        {
            Residentes.Add(residente);

            return Task.FromResult(Residentes);
        }

    }

}
