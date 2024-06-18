using FluentValidation;
using Repository.Models;

namespace Services.Validaciones
{
    public class FacturaValidator : AbstractValidator<FacturaModel>
    {
        public FacturaValidator()
        {
            RuleFor(f => f.Nro_Factura)
                .Matches(@"^\d{3}-\d{3}-\d{6}$")
                .WithMessage("El Nro. Factura debe seguir el patrón 000-000-000000");

            RuleFor(f => f.Total)
                .NotEmpty().WithMessage("El campo Total es obligatorio.")
                .GreaterThan(0).WithMessage("El campo Total debe ser mayor a 0.");

            RuleFor(f => f.Total_iva5)
                .NotEmpty().WithMessage("El campo Total IVA 5% es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El campo Total IVA 5% debe ser mayor o igual a 0.");

            RuleFor(f => f.Total_iva10)
                .NotEmpty().WithMessage("El campo Total IVA 10% es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El campo Total IVA 10% debe ser mayor o igual a 0.");

            RuleFor(f => f.Total_iva)
                .NotEmpty().WithMessage("El campo Total IVA es obligatorio.")
                .GreaterThanOrEqualTo(0).WithMessage("El campo Total IVA debe ser mayor o igual a 0.");

            RuleFor(f => f.Total_letras)
                .NotEmpty().WithMessage("El campo Total en letras es obligatorio.")
                .MinimumLength(6).WithMessage("El campo Total en letras debe tener al menos 6 caracteres.");
        }
    }
}
