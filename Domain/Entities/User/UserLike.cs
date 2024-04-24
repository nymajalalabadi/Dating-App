using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.User
{
    public class UserLike
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public int SourceUserId { get; set; }

        public int LikedUserId { get; set; }

        #endregion

        #region Relations

        [ForeignKey(nameof(SourceUserId))]
        [InverseProperty("LikedByUsers")]
        public User SourceUser { get; set; }

        [ForeignKey(nameof(LikedUserId))]
        [InverseProperty("LikedUsers")]
        public User LikedUser { get; set; }

        #endregion

    }
}
