using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShareApi.Models
{
    public class User
    {
        #region props
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public  string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Share> Shares { get; set; }
        #endregion

        public User()
        {

        }

        public User(string firstName, string lastname, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Email = email;
        }
    }
}
