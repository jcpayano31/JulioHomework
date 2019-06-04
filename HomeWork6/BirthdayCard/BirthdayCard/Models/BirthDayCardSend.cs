using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCard.Models
{
    public class BirthDayCardSend
    {
        [Required(ErrorMessage ="From User Required")]
        public string FromUser { get; set; }
        [Required(ErrorMessage ="To User Required")]
        public string ToUser { get; set; }
        [Required(ErrorMessage ="Menssage Required")]
        public string BCardMenssege { get; set; }
    }
}