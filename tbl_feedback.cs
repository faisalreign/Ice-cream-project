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


    public partial class tbl_feedback
    {
        public int f_id { get; set; }

        [Display(Name = "Comment")]
        public string f_text { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail Required!")]
        public string f_email { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name Required!")]
        public string f_name { get; set; }

        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact Required!")]
        public string f_contact { get; set; }
    }
}
