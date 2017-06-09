﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Dispose();

        void Commit();
    }
}
