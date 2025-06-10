using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmployeeForCreationDto  : EmployeeForManipulationDto {

        public string Name { get; init; }
        [Required(ErrorMessage = "aaaa")]
        [Range(18, 65)]

        public int Age { get; init; }

        public string Position { get; init; }
    }

}
