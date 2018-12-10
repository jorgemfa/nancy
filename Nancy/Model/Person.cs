using System;
using FluentValidation;

namespace NancyMS.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().Length(3,10);
            this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
            this.RuleFor(x => x.Age).GreaterThanOrEqualTo(18);
        }
    }
}
