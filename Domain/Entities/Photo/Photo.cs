using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Photo
{
    public class Photo
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        #endregion

        #region Relations

        public User.User User { get; set; }

        #endregion
    }

}
