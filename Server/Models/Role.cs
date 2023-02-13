using Microsoft.AspNetCore.Identity;

namespace server.models;
public class Role : IdentityRole<String>
{
    public ICollection<UtilisateurRole> UtilisateurRoles { get; set; }
    public Role()
    {
        this.UtilisateurRoles = new List<UtilisateurRole>();
    }

    public Role(string Name)
    {
        this.Id = Guid.NewGuid().ToString();
        this.UtilisateurRoles = new List<UtilisateurRole>();
        this.Name = Name;
        this.NormalizedName = Name.ToUpper();
    }
}