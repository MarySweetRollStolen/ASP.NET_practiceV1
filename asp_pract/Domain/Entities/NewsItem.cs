using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_pract.Domain.Entities
{
    public class NewsItem : EntityBase
    {
        [Required(ErrorMessage = "Введіть заголовок новини")]
        [Display(Name = "Заголовок новини")]
        [Remote(action: "CheckTitle", controller: "News", ErrorMessage="Новина з такою назвою вже існує!")]
        public override string Title { get; set; }

        [Display(Name = "Підзаголовок")]
        public override string Subtitle { get; set; }

        [Display(Name = "Текст новини")]
        public override string Text { get; set; }

        public bool UprovedByAdmin { get; set; }

        [Display(Name = "Повідомлення для адміна")]
        public string MessageForAdmin { get; set; }

        [Display(Name = "Пошта для фідбеку про рецензію новини")]
        public string UserAdress { get; set; }


    }
}
