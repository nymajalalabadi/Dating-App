﻿using Domain.DTOs.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public class MemberDTO
    {
        #region Properties

        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string? Mobile { get; set; }

        public string PhotoUrl { get; set; }

        public bool IsEmailActive { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string KnowAs { get; set; }

        public DateTime RegisterDate { get; set; }

        #endregion


        #region Relations

        public ICollection<PhotoDTO> Photos { get; set; }

        #endregion
    }
}
