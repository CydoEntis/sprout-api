namespace TaskGarden.Api.Dtos.Category;

public class CategoryWithCountResponseDto : CategoryResponseDto
{
    public int TaskListCount { get; set; }
}