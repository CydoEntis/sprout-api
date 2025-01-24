namespace TaskGarden.Api.Dtos.TaskList;

public class NewTaskListRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
}