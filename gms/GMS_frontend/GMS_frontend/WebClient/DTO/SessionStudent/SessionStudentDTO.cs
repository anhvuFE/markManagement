using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.SessionStudent
{
    public class SessionStudentDTO
    {
        public int SessionId { get; set; }
        public int StudentId { get; set; }
    }

    public class GetStudentBySession
    {
        public int SessionId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
