using System.ComponentModel.DataAnnotations;

namespace Tutorial.Enums
{
    public enum TypeEnum
    {
        [Display(Name = "Education type")]
        Education = 10,
        [Display(Name = "Research type")]
        Research = 11,
        [Display(Name = "Technology type")]
        Technology = 20,
        [Display(Name = "Science type")]
        Science = 21
    }
}
