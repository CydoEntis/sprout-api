using FluentValidation;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidatorFactory _validatorFactory;

        public ValidationService(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public async Task ValidateRequestAsync<T>(T request, CancellationToken cancellationToken)
        {
            var validator = _validatorFactory.GetValidator<T>();
            if (validator == null)
                throw new InvalidOperationException($"No validator found for {typeof(T).Name}");

            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }
    }
}