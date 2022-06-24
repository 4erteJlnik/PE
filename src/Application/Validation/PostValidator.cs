using System;
using FluentValidation;
using Web1.Domain;
namespace Web1
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(60);
            RuleFor(x=>x.Description).NotEmpty().MaximumLength(1000);
            
            
        }
    }
}