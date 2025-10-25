namespace Recipes.Application.Posts.Dtos;
public class SocialDataDto(int Likes, int Dislikes)
{
    public int Likes { get; } = Likes;
    public int Dislikes { get; } = Dislikes;
}
