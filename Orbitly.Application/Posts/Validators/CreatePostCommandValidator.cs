using FluentValidation;
using Orbitly.Application.Posts.Commands;

namespace Orbitly.Application.Posts.Validators;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required")
            .MaximumLength(500)
            .WithMessage("Content must have at most 500 characters");
    }
}