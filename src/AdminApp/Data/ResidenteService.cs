using AdminApp.Models.Residentes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdminApp.Models;

namespace AdminApp.Data
{
    public class ResidenteService
    {

        private static readonly List<Evaluacion> ListEvaluaciones = new List<Evaluacion>
        {
            new Evaluacion { Id = 1, GestionTiempo = 1, CogePacientes = 2, Interes = 3, Bibliografia = 4, PreparaPacientes = 5, OrientaPaciente = 6, AplicaTratamiento = 7, EstableceDiagnostico = 8, ReevaluaPaciente = 9, Adjunto = 1, FechaEvaluacion = new DateTime(2019,12,16)},
            new Evaluacion { Id = 2, GestionTiempo = 10, CogePacientes = 1, Interes = 2, Bibliografia = 3, PreparaPacientes = 4, OrientaPaciente = 5, AplicaTratamiento = 6, EstableceDiagnostico = 7, ReevaluaPaciente = 8, Adjunto = 1, FechaEvaluacion = new DateTime(2019,12,17)},
            new Evaluacion { Id = 3, GestionTiempo = 9, CogePacientes = 0, Interes = 1, Bibliografia = 2, PreparaPacientes = 3, OrientaPaciente = 4, AplicaTratamiento = 5, EstableceDiagnostico = 6, ReevaluaPaciente = 7, Adjunto = 1, FechaEvaluacion = new DateTime(2019,12,18)}
        };


        private static readonly List<Residente> Residentes = new List<Residente>
        {
            new Residente { Id=1, FirstName = "Minerva", LastName = "Martinez Cano", YearResident = 2, Especialidad = 1, Evaluaciones = ListEvaluaciones },
            new Residente { Id=2, FirstName = "Luis Angel", LastName = "Martinez González", YearResident = 1, Especialidad = 3, Evaluaciones = ListEvaluaciones },
            new Residente { Id=3, FirstName = "Natividad", LastName = "Cázarez Santos", YearResident = 4, Especialidad = 7, Evaluaciones = ListEvaluaciones },
            new Residente { Id=4, FirstName = "Maribel", LastName = "Picazo Reyes", YearResident = 1, Especialidad = 2, Evaluaciones = ListEvaluaciones },
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
