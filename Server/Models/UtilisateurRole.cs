using System;
using Microsoft.AspNetCore.Identity;


namespace server.models;

    public class UtilisateurRole : IdentityUserRole<String>
    {
        public User User {get; set;}
        public Role Role {get; set;}
    }
