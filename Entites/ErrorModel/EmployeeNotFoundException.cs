﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Domain.ErrorModel
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid employeeId)
         : base($"Employee with id: {employeeId} doesn't exist in the database.")
        {
        }
    }
}
