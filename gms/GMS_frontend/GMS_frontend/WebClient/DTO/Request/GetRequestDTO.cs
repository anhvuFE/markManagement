using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.Request
{
    public class GetRequestDTO
    {
        public int RequestId { get; set; }
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int GradeId { get; set; }
        public string? GradeName { get; set; }
        public int CourseId { get; set; }
        public string? CourseCode{ get; set; }
        public string? RequestContent { get; set; }
        public string? ResponeContent { get; set; }
        public int RequestStatusId { get; set; }
        public string? StatusName { get; set; }
    }
}
