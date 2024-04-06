using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos.UserDto
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string UserName { get; set; }


        [DisplayName("E-posta Adresi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(7, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Email { get; set; }


        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Password { get; set; }



        [DisplayName("Telefon Numarası ")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(13, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(13, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string PhoneNumber { get; set; }



        [DisplayName("Fotoğraf")]
        [Required(ErrorMessage = " Lütfen bir {0} seçiniz .")]
        [DataType(DataType.Upload)]
        public IFormFile Picture { get; set; }


    }
}
