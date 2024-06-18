using FluentValidation;
using Repository.Models;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validaciones
{

    public class ClienteValidator : AbstractValidator<ClienteModel>
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteValidator(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            RuleFor(cliente => cliente.Nombre)
                .NotEmpty().WithMessage("El Nombre es obligatorio.")
                .MinimumLength(3).WithMessage("El Nombre debe tener al menos 3 caracteres.");

            RuleFor(cliente => cliente.Apellido)
                .NotEmpty().WithMessage("El Apellido es obligatorio.")
                .MinimumLength(3).WithMessage("El Apellido debe tener al menos 3 caracteres.");

            RuleFor(cliente => cliente.Documento)
                .NotEmpty().WithMessage("El Documento es obligatorio.")
                .MinimumLength(7).WithMessage("El Documento debe tener al menos 7 caracteres.")
                .Must(BeUniqueDocument).WithMessage("El Documento ya está registrado.");

            RuleFor(cliente => cliente.Celular)
                .NotEmpty().WithMessage("El Celular es obligatorio.")
                .Length(10).WithMessage("El Celular debe tener 10 caracteres.")
                .Matches(@"^\d+$").WithMessage("El Celular debe ser numérico.");

            RuleFor(cliente => cliente.Mail)
                .NotEmpty().WithMessage("El Mail es obligatorio.")
                .EmailAddress().WithMessage("El Mail debe tener un formato válido.");
        }

        private bool BeUniqueDocument(string documento)
        {
            return !_clienteRepository.GetAllClientes().Any(c => c.Documento == documento);
        }
    }
}
