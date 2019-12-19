using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }
        public int GestionTiempo { get; set; } = 0;
        public int CogePacientes { get; set; } = 0;
        public int Interes { get; set; } = 0;
        public int Bibliografia { get; set; } = 0;
        public int PreparaPacientes { get; set; } = 0;
        public int OrientaPaciente { get; set; } = 0;
        public int AplicaTratamiento { get; set; } = 0;
        public int EstableceDiagnostico { get; set; } = 0;
        public int ReevaluaPaciente { get; set; } = 0;
        public DateTime FechaEvaluacion { get; set; } = DateTime.Now;
        public int Adjunto { get; set; } = 0;

    }
}
