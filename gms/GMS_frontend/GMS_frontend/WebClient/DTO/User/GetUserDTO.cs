using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.DTO.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public int? RoleId { get; set; }


        public bool isAdmin(int? roleId)
        {
            if (roleId == null || roleId != 1)
            {
                return false;
            }
            else { return true; }
        }

        public bool isKhaoThi(int? roleId)
        {
            if (roleId == null || roleId != 2)
            {
                return false;
            }
            else { return true; }
        }
        public bool isTeacher(int? roleId)
        {
            if (roleId == null || roleId != 3)
            {
                return false;
            }
            else { return true; }
        }


        public bool isStudent(int? roleId)
        {
            if (roleId == null || roleId != 4)
            {
                return false;
            }
            else { return true; }
        }
    }
}
