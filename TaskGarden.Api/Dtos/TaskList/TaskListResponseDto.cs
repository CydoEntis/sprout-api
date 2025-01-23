namespace TaskGarden.Api.Dtos.TaskList;

public class TaskListResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<MemberResponseDto> Members { get; set; }
}