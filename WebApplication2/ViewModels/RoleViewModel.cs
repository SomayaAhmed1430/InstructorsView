using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class RoleViewModel
    {
        // for scaffolding View
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

    }
}
