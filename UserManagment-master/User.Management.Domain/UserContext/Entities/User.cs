using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Shared;

namespace UserManagement.Domain.UserContext.Entities
{
    public class User:BaseEntity
    {
        public User(string name, string documentNumber, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            DocumentNumber = documentNumber;
            Email = email;
            Password = password;
            Active = true;
        }

        public User(Guid id, string name, string documentNumber, string email, string password, bool active)
        {
            Id = id;
            Name = name;
            DocumentNumber = documentNumber;
            Email = email;
            Password = password;
            Active = active;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public ValidationResult Validate() => new UserValidator().Validate(this);

        public void Update(string name, string documentNumber, string email, string password)
        {
            Name = name;
            DocumentNumber = documentNumber;
            Email= email;
            Password = password;
        }

        public override void Inactivate()
        {
            this.Active = false;
        }

        public override void Activate()
        {
            this.Active = true;
        }

    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Propriedade [NAME] não pode ser nulo.")
                .NotEmpty()
                .WithMessage("Propriedade [NAME] não pode ser vazio.");

            RuleFor(x => x.DocumentNumber)
               .NotNull()
               .WithMessage("Propriedade [DocumentNumber] não pode ser nulo.")
               .NotEmpty()
               .WithMessage("Propriedade [DocumentNumber] não pode ser vazio.")
               .MinimumLength(11)
               .WithMessage("Propriedade [Password] deve ter no minimo 11 caracteres");

            RuleFor(x => x.Email)
               .NotNull()
               .WithMessage("Propriedade [Email] não pode ser nulo.")
               .NotEmpty()
               .WithMessage("Propriedade [Email] não pode ser vazio.")
               .EmailAddress()
               .WithMessage("Propriedade [Email] não é valida");

            RuleFor(x => x.Password)
               .NotNull()
               .WithMessage("Propriedade [Password] não pode ser nulo.")
               .NotEmpty()
               .WithMessage("Propriedade [Password] não pode ser vazio.")
               .MinimumLength(8)
               .WithMessage("Propriedade [Password] deve ter no minimo 8 caracteres");
               


        } 
    }
}
