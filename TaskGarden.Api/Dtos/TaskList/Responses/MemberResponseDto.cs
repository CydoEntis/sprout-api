namespace TaskGarden.Api.Dtos;

public class MemberResponseDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
}

// public class TaskListOverview
// {
//     public int Id { get; set; }
//     public string Description { get; set; }
//     public DateTime CreatedAt { get; set; }
//     public DateTime UpdatedAt { get; set; }
//     public List<Members> Members { get; set; }
//     public int TotalTasksCount { get; set; }
//     public int CompletedTasksCount { get; set; }
//     public double TaskCompletionPercentage { get; set; }
//     
// }
//
// public class Members
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
// }