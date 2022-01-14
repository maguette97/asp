using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisor.Models
{
    public partial class TypeBienViewModel
    {
        [Key]
        public int IdTypeBien { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(4, ErrorMessage = "Taille maximale 4")]
        [Display(Name = "Code type bien")]
        public string CodeTypeBien { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(80, ErrorMessage = "Taille maximale 80")]
        [Display(Name = "Type bien")]
        public string LibelleTypeBien { get; set; }
    }
    public class BienViewModel
    {
    }
}