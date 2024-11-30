using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.Request
{
    public class ResultForUpdateRequestDTO
    {
        public bool IsSuccess { get; set; }
        public int newGrade {  get; set; }
        public string statusName { get; set; }
    }
}
