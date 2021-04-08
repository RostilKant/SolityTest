﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(x => x.LastName)
                .ToListAsync();
    }
}