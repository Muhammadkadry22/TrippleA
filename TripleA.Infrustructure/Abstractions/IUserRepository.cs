﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities.Identity;
using TripleA.Infrustructure.InfrastructureBases;

namespace TripleA.Infrustructure.Abstractions
{
    public interface IUserRepository   : IGenericRepository<User>
    {
    }
}
