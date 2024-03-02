using Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Photo
{
    public class PhotoDTO
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }

        #endregion


        #region Relations

        public MemberDTO MemberDTO { get; set; }

        #endregion
    }
}
