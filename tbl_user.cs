//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICECREAMPROJECT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tbl_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_user()
        {
            this.tbl_recipe = new HashSet<tbl_recipe>();
        }
    
        public int u_id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name Required!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string u_name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail Required!")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$")]
        public string u_email { get; set; }

        [Display(Name ="Image")]
        public string u_image { get; set; }

        
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string u_contact { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is Required!")]
        public string u_password { get; set; }
        public Nullable<int> u_subs { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required!")]
        [Compare("u_password")]
        public string u_cpassword { get; set; }
    
        public virtual TBL_MEMBERSHIP TBL_MEMBERSHIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_recipe> tbl_recipe { get; set; }
    }
}
