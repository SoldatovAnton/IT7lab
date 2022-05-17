using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT7lab.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Введите имя:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите еmail:")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Некорректный еmail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите номер телефона (без символа +):")]
        [RegularExpression("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Некорректный телефон.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Придёшь на вечеринку или нет:")]
        public bool WillAttend { get; set; }

    }
}