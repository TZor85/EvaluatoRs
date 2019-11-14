﻿using IdentityServerAspNetIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Data.Residentes
{
    public interface IResidentesService
    {
        List<ResidenteModel> GetResidentes();

    }
}
