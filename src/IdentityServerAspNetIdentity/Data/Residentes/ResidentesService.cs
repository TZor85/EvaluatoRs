using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Models;

namespace IdentityServerAspNetIdentity.Data.Residentes
{
    public class ResidentesService //: IResidentesService
    {
        private ApplicationDbContext _context;

        public ResidentesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ResidenteModel> GetResidentes()
        {
            return _context.Residentes.ToList();
        }
    }
}
