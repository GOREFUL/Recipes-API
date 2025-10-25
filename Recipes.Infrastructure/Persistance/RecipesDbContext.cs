using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities.Business.Cooking;
using Recipes.Domain.Entities.Business.Cooking.Advanced;
using Recipes.Domain.Entities.Business.Cooking.Links;
using Recipes.Domain.Entities.Business.Enumerations;
using Recipes.Domain.Entities.Business.Social;
using Recipes.Domain.Entities.Governance.Enumeration;
using Recipes.Domain.Entities.Governance.Moderation;
using Recipes.Domain.Entities.Governance.Report;
using Recipes.Domain.Entities.UserContext;
using Recipes.Infrastructure.Persistance.Config.Business.Cooking;
using Recipes.Infrastructure.Persistance.Config.Business.Cooking.Advanced;
using Recipes.Infrastructure.Persistance.Config.Business.Cooking.Links;
using Recipes.Infrastructure.Persistance.Config.Business.Enumerations;
using Recipes.Infrastructure.Persistance.Config.Business.Social;
using Recipes.Infrastructure.Persistance.Config.Governance.Enumeration;
using Recipes.Infrastructure.Persistance.Config.Governance.Report;
using Recipes.Infrastructure.Persistance.Config.UserContext;
using System;
using System.Reflection.Emit;
using Recipes.Infrastructure.Persistance.Config.Governance.Report.Moderation;

namespace Recipes.Infrastructure.Persistance;
public class RecipesDbContext(DbContextOptions<RecipesDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    // --- Business.Cooking ---
    public DbSet<Dish> Dishes => Set<Dish>();
    public DbSet<DishInfo> DishInfos => Set<DishInfo>();
    public DbSet<IngredientUnit> IngredientUnits => Set<IngredientUnit>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<FavoriteDish> FavoriteDishes => Set<FavoriteDish>();

    // Advanced
    public DbSet<Macronutrients> Macronutrients => Set<Macronutrients>();
    public DbSet<Micronutrients> Micronutrients => Set<Micronutrients>();

    // --- Business.Enumerations ---
    public DbSet<Allergy> Allergies => Set<Allergy>();
    public DbSet<Cuisine> Cuisines => Set<Cuisine>();
    public DbSet<DishTag> DishTags => Set<DishTag>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Level> Levels => Set<Level>();
    public DbSet<MeasurementUnit> MeasurementUnits => Set<MeasurementUnit>();

    // --- Business.Social ---
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<MediaUnit> MediaUnits => Set<MediaUnit>();
    public DbSet<SocialData> SocialData => Set<SocialData>();

    // --- Governance.Enumeration ---
    public DbSet<ReportStatus> ReportStatuses => Set<ReportStatus>();
    public DbSet<PostReportClass> PostReportClasses => Set<PostReportClass>();
    public DbSet<DishReportClass> DishReportClasses => Set<DishReportClass>();
    public DbSet<CommentReportClass> CommentReportClasses => Set<CommentReportClass>();

    // --- Governance.Moderation ---
    public DbSet<PostReportData> PostReportData => Set<PostReportData>();
    public DbSet<DishReportData> DishReportData => Set<DishReportData>();
    public DbSet<CommentReportData> CommentReportData => Set<CommentReportData>();

    // --- Governance.Report ---
    public DbSet<PostReport> PostReports => Set<PostReport>();
    public DbSet<DishReport> DishReports => Set<DishReport>();
    public DbSet<CommentReport> CommentReports => Set<CommentReport>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // ===== Business.Cooking =====
        builder.ApplyConfiguration(new DishConfig());
        builder.ApplyConfiguration(new DishInfoConfig());
        builder.ApplyConfiguration(new ImageConfig());
        builder.ApplyConfiguration(new IngredientUnitConfig());
        builder.ApplyConfiguration(new PlanConfig());
        builder.ApplyConfiguration(new StepConfig());
        // Advanced
        builder.ApplyConfiguration(new MacronutrientsConfig());
        builder.ApplyConfiguration(new MicronutrientsConfig());
        // Links
        builder.ApplyConfiguration(new FavoriteDishConfig());

        // ===== Business.Enumerations =====
        builder.ApplyConfiguration(new AllergyConfig());
        builder.ApplyConfiguration(new CuisineConfig());
        builder.ApplyConfiguration(new DishTagConfig());
        builder.ApplyConfiguration(new IngredientConfig());
        builder.ApplyConfiguration(new LevelConfig());
        builder.ApplyConfiguration(new MeasurementUnitConfig());

        // ===== Business.Social =====
        builder.ApplyConfiguration(new CommentConfig());
        builder.ApplyConfiguration(new MediaUnitConfig());
        builder.ApplyConfiguration(new PostConfig());
        builder.ApplyConfiguration(new SocialDataConfig());

        // ===== Governance.Enumeration =====
        builder.ApplyConfiguration(new CommentReportClassConfig());
        builder.ApplyConfiguration(new DishReportClassConfig());
        builder.ApplyConfiguration(new PostReportClassConfig());
        builder.ApplyConfiguration(new ReportStatusConfig());

        // ===== Governance.Moderation =====
        builder.ApplyConfiguration(new CommentReportDataConfig());
        builder.ApplyConfiguration(new DishReportDataConfig());
        builder.ApplyConfiguration(new PostReportDataConfig());

        // ===== Governance.Report =====
        builder.ApplyConfiguration(new CommentReportConfig());
        builder.ApplyConfiguration(new DishReportConfig());
        builder.ApplyConfiguration(new PostReportConfig());

        // ===== ApplicationUser =====
        builder.ApplyConfiguration(new ApplicationUserConfig());

        builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsDeleted);

        foreach (var fk in builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade))
        {
            fk.DeleteBehavior = DeleteBehavior.NoAction;
        }
    }
}
