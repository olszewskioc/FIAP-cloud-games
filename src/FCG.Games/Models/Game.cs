using FCG.Core.Entities;
using FCG.Core.Entities.Base;
using FluentValidation;

namespace FCG.Games.Models
{
    public class Game : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PublisherName { get; set; } // Entidade futura
        public DateOnly ReleaseDate { get; set; }
        public decimal Price { get; set; }

        // EF Relation
        protected Game() { }

        public class RegistrarClienteValidation : AbstractValidator<Game>
        {
            public RegistrarClienteValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Invalid id");

                RuleFor(c => c.Description);

                RuleFor(c => c.PublisherName);

                RuleFor(c => c.ReleaseDate);

                RuleFor(c => c.Price);
            }

            protected static bool TerCpfValido(Cpf cpf)
            {
                return Cpf.Validar(cpf.Numero);
            }

            protected static bool TerEmailValido(Email email)
            {
                return Email.Validar(email.Endereco);
            }
        }
    }
}
