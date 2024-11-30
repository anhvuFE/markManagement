using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.GradeType
{
    public class GetGradeTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int GradedByRoleId { get; set; }
        public string GradedByRoleName { get; set; }

        public string ComparisonType { get; set; }

        public int ComparisonValue { get; set; }
    }
}
