using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using WebClient.DTO;
using WebClient.DTO.User;

namespace TimetableSystem.Services
{
    public class AuthenticationHelper
    {
        public static GetUserDTO GetAuthenticatedUser(HttpContext httpContext)
        {
            string userJson = httpContext.Session.GetString("currentUser");
            if (string.IsNullOrEmpty(userJson))
            {
                return null;
            }

            GetUserDTO user = JsonSerializer.Deserialize<GetUserDTO>(userJson);
            return user;
        }
        public static bool IsAdmin(GetUserDTO u)
        {
            int adminRole = 1;
            return u != null && u.RoleId == adminRole;
        }

        public static bool IsKhaoThi(GetUserDTO u)
        {
            int teacherRole = 2;
            return u != null && u.RoleId == teacherRole;
        }

        public static bool IsTeacher(GetUserDTO u)
        {
            int adminRole = 3;
            return u != null && u.RoleId == adminRole;
        }

        public static bool IsStudent(GetUserDTO u)
        {
            int adminRole = 4;
            return u != null && u.RoleId == adminRole;
        }
    }
}
