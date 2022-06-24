using System;
using FluentValidation;
using Web1.Domain;
namespace Web1
{
    public class CommentsValidator : AbstractValidator<Comments>
    {
        public CommentsValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().MaximumLength(1000);
        }
    }
}