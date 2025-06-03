using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record class EmployeeForUpdateDto : EmployeeForManipulationDto
    {
        public string Name { get; init; }
        [Required]
        [Range(18, 65)]

        public int Age { get; init; }

        public string Position { get; init; }
    }

}
