﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Domain.ErrorModel
{
    public sealed class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException()
         : base("Parameter ids is null")
        {
        }
    }
}
