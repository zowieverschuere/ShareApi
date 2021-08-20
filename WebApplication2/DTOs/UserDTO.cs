using ShareApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.DTOs
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string  Password { get; set; }

        public List<Share> Shares { get; set; }

        public UserDTO()
        {

        }

       

    }
}
