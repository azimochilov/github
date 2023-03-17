using GitHub.Domain.Commons;
namespace GitHub.Domain.Entities;
public class UserFollowers : Auditable
{
    public long FollowerId { get; set; }
    public User Follower { get; set; }
    public long FollowedByMeId { get; set; }
    public User FollowedByMe { get; set; }
}
