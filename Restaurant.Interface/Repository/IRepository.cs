﻿using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Interface.Repository
{
    public interface IRepository<T> where T : Entity
    {
        bool Insert(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        T Find(int id);
        
    }
}
