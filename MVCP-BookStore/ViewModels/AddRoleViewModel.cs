using System.ComponentModel.DataAnnotations;

namespace MVCP_BookStore.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
