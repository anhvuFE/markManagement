using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.Grade
{
    public class GetGradeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int GradeTypeId { get; set; }
        public string GradeTypeName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public string Completed { get; set; }
        public decimal PercentCompleted { get; set; }
    }
}
