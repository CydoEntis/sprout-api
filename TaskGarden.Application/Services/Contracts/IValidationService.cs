namespace TaskGarden.Application.Services.Contracts;

public interface IValidationService
{
    Task ValidateRequestAsync<T>(T request, CancellationToken cancellationToken);
}