using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace keepr.Models
{

    public class UserLogin // HELPER MODEL
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
    public class UserRegistration // HELPER MODEL
    {

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public bool Active { get; set; } = true;
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        internal string Hash { get; set; }
        internal ClaimsPrincipal _principal { get; private set; }



        internal void SetClaims()
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, Id) //req.session.uid = id
            };
            var userIdentity = new ClaimsIdentity(claims, "login");
            _principal = new ClaimsPrincipal(userIdentity);
        }
    }
}