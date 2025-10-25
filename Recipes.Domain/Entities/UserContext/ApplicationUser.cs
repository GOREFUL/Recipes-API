using Microsoft.AspNetCore.Identity;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Cooking.Links;
using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Entities.Governance.Moderation;
using Recipes.Domain.Entities.Governance.Report;

namespace Recipes.Domain.Entities.UserContext;
public class ApplicationUser : IdentityUser<Guid>
{
    public string DisplayName { get; set; } = default!;
    public string? AvatarUrl { get; set; }
    public string? Bio { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;

    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<Plan> Plans { get; set; } = new List<Plan>();
    public ICollection<FavoriteDish> FavoriteDishes { get; set; } = new List<FavoriteDish>();
    public ICollection<DishReport> DishReports { get; set; } = new List<DishReport>();
    public ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();
    public ICollection<CommentReport> CommentReports { get; set; } = new List<CommentReport>();
    public ICollection<DishReportData> ModeratedDishReports { get; set; } = new List<DishReportData>();
    public ICollection<PostReportData> ModeratedPostReports { get; set; } = new List<PostReportData>();
    public ICollection<CommentReportData> ModeratedCommentReports { get; set; } = new List<CommentReportData>();
}
