using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.Grade
{
    public class CreateGradeDTO
    {
        public int GradeTypeId { get; set; }
        public int NumberOfGrade { get; set; }
        public int WeightPerGrade { get; set; }
    }
}
