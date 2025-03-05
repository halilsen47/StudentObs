using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataTransferObject
{
    public abstract record StudentDtoForManupilation
    {
        [Required(ErrorMessage ="FirstName is a required field.")]
        [MaxLength(25,ErrorMessage ="FirstName lenght max be 25")]
        [MinLength(3,ErrorMessage ="FirstName lenght min be 3")]
        public string FirstName { get; init; }
        [Required(ErrorMessage ="LastName is a required field.")]
        public string LastName { get; init; }
        
        public DateTime BirthDate { get; init; }
        [MinLength(11,ErrorMessage ="Phone number must be 11 lenght")]
        [MaxLength(11)]
        public string PhoneNumber { get; init; }
        [Required(ErrorMessage ="Adress can not be a empty")]
        public string Adress { get; init; }
        [Required(ErrorMessage ="Email can not be a empty")]
        public string Email { get; init; }

    }
}
