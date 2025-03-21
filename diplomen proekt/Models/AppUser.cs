using Microsoft.AspNetCore.Identity;

namespace diplomen_proekt.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            MyRatedPizza=new List<Rating>();
        }
        public virtual ICollection<Rating> MyRatedPizza { get; set; }
    }



  
}
