using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReportData_AspNetUsers_ModeratorId",
                table: "CommentReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReportData_CommentReports_ReportId",
                table: "CommentReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReportData_ReportStatuses_StatusId",
                table: "CommentReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReports_AspNetUsers_UserId",
                table: "CommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReports_CommentReportClasses_ClassId",
                table: "CommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReports_Comments_CommentId",
                table: "CommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_AspNetUsers_CookId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoAllergies_Allergies_AllergyId",
                table: "DishInfoAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoAllergies_DishInfos_DishInfoId",
                table: "DishInfoAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoCuisines_Cuisines_CuisineId",
                table: "DishInfoCuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoCuisines_DishInfos_DishInfoId",
                table: "DishInfoCuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfos_Dishes_DishId",
                table: "DishInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoTags_DishInfos_DishInfoId",
                table: "DishInfoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoTags_DishTags_DishTagId",
                table: "DishInfoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReportData_AspNetUsers_ModeratorId",
                table: "DishReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReportData_DishReports_ReportId",
                table: "DishReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReportData_ReportStatuses_StatusId",
                table: "DishReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReports_AspNetUsers_UserId",
                table: "DishReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReports_DishReportClasses_ClassId",
                table: "DishReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReports_Dishes_DishId",
                table: "DishReports");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDishes_AspNetUsers_UserId",
                table: "FavoriteDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDishes_Dishes_DishId",
                table: "FavoriteDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_DishInfos_DishInfoId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_DishInfos_DishInfoId",
                table: "IngredientUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_MeasurementUnits_MeasurementUnitId",
                table: "IngredientUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Macronutrients_DishInfos_DishInfoId",
                table: "Macronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaUnits_Posts_PostId",
                table: "MediaUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Micronutrients_DishInfos_DishInfoId",
                table: "Micronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AspNetUsers_UserId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Dishes_DishId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReportData_AspNetUsers_ModeratorId",
                table: "PostReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReportData_PostReports_ReportId",
                table: "PostReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReportData_ReportStatuses_StatusId",
                table: "PostReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_AspNetUsers_UserId",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_PostReportClasses_ClassId",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_Posts_PostId",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Dishes_DishId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialData_Posts_PostId",
                table: "SocialData");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_DishInfos_DishInfoId",
                table: "Steps");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReportData_AspNetUsers_ModeratorId",
                table: "CommentReportData",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReportData_CommentReports_ReportId",
                table: "CommentReportData",
                column: "ReportId",
                principalTable: "CommentReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReportData_ReportStatuses_StatusId",
                table: "CommentReportData",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReports_AspNetUsers_UserId",
                table: "CommentReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReports_CommentReportClasses_ClassId",
                table: "CommentReports",
                column: "ClassId",
                principalTable: "CommentReportClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReports_Comments_CommentId",
                table: "CommentReports",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_AspNetUsers_CookId",
                table: "Dishes",
                column: "CookId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoAllergies_Allergies_AllergyId",
                table: "DishInfoAllergies",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoAllergies_DishInfos_DishInfoId",
                table: "DishInfoAllergies",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoCuisines_Cuisines_CuisineId",
                table: "DishInfoCuisines",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoCuisines_DishInfos_DishInfoId",
                table: "DishInfoCuisines",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfos_Dishes_DishId",
                table: "DishInfos",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoTags_DishInfos_DishInfoId",
                table: "DishInfoTags",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoTags_DishTags_DishTagId",
                table: "DishInfoTags",
                column: "DishTagId",
                principalTable: "DishTags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishReportData_AspNetUsers_ModeratorId",
                table: "DishReportData",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishReportData_DishReports_ReportId",
                table: "DishReportData",
                column: "ReportId",
                principalTable: "DishReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishReportData_ReportStatuses_StatusId",
                table: "DishReportData",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishReports_AspNetUsers_UserId",
                table: "DishReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishReports_DishReportClasses_ClassId",
                table: "DishReports",
                column: "ClassId",
                principalTable: "DishReportClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishReports_Dishes_DishId",
                table: "DishReports",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDishes_AspNetUsers_UserId",
                table: "FavoriteDishes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDishes_Dishes_DishId",
                table: "FavoriteDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_DishInfos_DishInfoId",
                table: "Images",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_DishInfos_DishInfoId",
                table: "IngredientUnits",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_MeasurementUnits_MeasurementUnitId",
                table: "IngredientUnits",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Macronutrients_DishInfos_DishInfoId",
                table: "Macronutrients",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaUnits_Posts_PostId",
                table: "MediaUnits",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Micronutrients_DishInfos_DishInfoId",
                table: "Micronutrients",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AspNetUsers_UserId",
                table: "Plans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Dishes_DishId",
                table: "Plans",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReportData_AspNetUsers_ModeratorId",
                table: "PostReportData",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReportData_PostReports_ReportId",
                table: "PostReportData",
                column: "ReportId",
                principalTable: "PostReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReportData_ReportStatuses_StatusId",
                table: "PostReportData",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_AspNetUsers_UserId",
                table: "PostReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_PostReportClasses_ClassId",
                table: "PostReports",
                column: "ClassId",
                principalTable: "PostReportClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_Posts_PostId",
                table: "PostReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Dishes_DishId",
                table: "Posts",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialData_Posts_PostId",
                table: "SocialData",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_DishInfos_DishInfoId",
                table: "Steps",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReportData_AspNetUsers_ModeratorId",
                table: "CommentReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReportData_CommentReports_ReportId",
                table: "CommentReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReportData_ReportStatuses_StatusId",
                table: "CommentReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReports_AspNetUsers_UserId",
                table: "CommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReports_CommentReportClasses_ClassId",
                table: "CommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReports_Comments_CommentId",
                table: "CommentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_AspNetUsers_CookId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoAllergies_Allergies_AllergyId",
                table: "DishInfoAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoAllergies_DishInfos_DishInfoId",
                table: "DishInfoAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoCuisines_Cuisines_CuisineId",
                table: "DishInfoCuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoCuisines_DishInfos_DishInfoId",
                table: "DishInfoCuisines");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfos_Dishes_DishId",
                table: "DishInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoTags_DishInfos_DishInfoId",
                table: "DishInfoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_DishInfoTags_DishTags_DishTagId",
                table: "DishInfoTags");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReportData_AspNetUsers_ModeratorId",
                table: "DishReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReportData_DishReports_ReportId",
                table: "DishReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReportData_ReportStatuses_StatusId",
                table: "DishReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReports_AspNetUsers_UserId",
                table: "DishReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReports_DishReportClasses_ClassId",
                table: "DishReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DishReports_Dishes_DishId",
                table: "DishReports");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDishes_AspNetUsers_UserId",
                table: "FavoriteDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteDishes_Dishes_DishId",
                table: "FavoriteDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_DishInfos_DishInfoId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_DishInfos_DishInfoId",
                table: "IngredientUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUnits_MeasurementUnits_MeasurementUnitId",
                table: "IngredientUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Macronutrients_DishInfos_DishInfoId",
                table: "Macronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaUnits_Posts_PostId",
                table: "MediaUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Micronutrients_DishInfos_DishInfoId",
                table: "Micronutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AspNetUsers_UserId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Dishes_DishId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReportData_AspNetUsers_ModeratorId",
                table: "PostReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReportData_PostReports_ReportId",
                table: "PostReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReportData_ReportStatuses_StatusId",
                table: "PostReportData");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_AspNetUsers_UserId",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_PostReportClasses_ClassId",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReports_Posts_PostId",
                table: "PostReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Dishes_DishId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialData_Posts_PostId",
                table: "SocialData");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_DishInfos_DishInfoId",
                table: "Steps");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReportData_AspNetUsers_ModeratorId",
                table: "CommentReportData",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReportData_CommentReports_ReportId",
                table: "CommentReportData",
                column: "ReportId",
                principalTable: "CommentReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReportData_ReportStatuses_StatusId",
                table: "CommentReportData",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReports_AspNetUsers_UserId",
                table: "CommentReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReports_CommentReportClasses_ClassId",
                table: "CommentReports",
                column: "ClassId",
                principalTable: "CommentReportClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReports_Comments_CommentId",
                table: "CommentReports",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_AspNetUsers_CookId",
                table: "Dishes",
                column: "CookId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoAllergies_Allergies_AllergyId",
                table: "DishInfoAllergies",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoAllergies_DishInfos_DishInfoId",
                table: "DishInfoAllergies",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoCuisines_Cuisines_CuisineId",
                table: "DishInfoCuisines",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoCuisines_DishInfos_DishInfoId",
                table: "DishInfoCuisines",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfos_Dishes_DishId",
                table: "DishInfos",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoTags_DishInfos_DishInfoId",
                table: "DishInfoTags",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishInfoTags_DishTags_DishTagId",
                table: "DishInfoTags",
                column: "DishTagId",
                principalTable: "DishTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishReportData_AspNetUsers_ModeratorId",
                table: "DishReportData",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishReportData_DishReports_ReportId",
                table: "DishReportData",
                column: "ReportId",
                principalTable: "DishReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishReportData_ReportStatuses_StatusId",
                table: "DishReportData",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishReports_AspNetUsers_UserId",
                table: "DishReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishReports_DishReportClasses_ClassId",
                table: "DishReports",
                column: "ClassId",
                principalTable: "DishReportClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishReports_Dishes_DishId",
                table: "DishReports",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDishes_AspNetUsers_UserId",
                table: "FavoriteDishes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteDishes_Dishes_DishId",
                table: "FavoriteDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_DishInfos_DishInfoId",
                table: "Images",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_DishInfos_DishInfoId",
                table: "IngredientUnits",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_Ingredients_IngredientId",
                table: "IngredientUnits",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUnits_MeasurementUnits_MeasurementUnitId",
                table: "IngredientUnits",
                column: "MeasurementUnitId",
                principalTable: "MeasurementUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Macronutrients_DishInfos_DishInfoId",
                table: "Macronutrients",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaUnits_Posts_PostId",
                table: "MediaUnits",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Micronutrients_DishInfos_DishInfoId",
                table: "Micronutrients",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AspNetUsers_UserId",
                table: "Plans",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Dishes_DishId",
                table: "Plans",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReportData_AspNetUsers_ModeratorId",
                table: "PostReportData",
                column: "ModeratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReportData_PostReports_ReportId",
                table: "PostReportData",
                column: "ReportId",
                principalTable: "PostReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReportData_ReportStatuses_StatusId",
                table: "PostReportData",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_AspNetUsers_UserId",
                table: "PostReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_PostReportClasses_ClassId",
                table: "PostReports",
                column: "ClassId",
                principalTable: "PostReportClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReports_Posts_PostId",
                table: "PostReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Dishes_DishId",
                table: "Posts",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialData_Posts_PostId",
                table: "SocialData",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_DishInfos_DishInfoId",
                table: "Steps",
                column: "DishInfoId",
                principalTable: "DishInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
