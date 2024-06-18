using FluentValidation;
using Repository.Models;
using Services.Validaciones;

namespace Services
{
    public class FacturaService
    {
        private readonly IValidator<FacturaModel> _validator;

        public FacturaService(IValidator<FacturaModel> validator)
        {
            _validator = validator;
        }

        public bool ValidateFactura(FacturaModel factura, out List<string> errors)
        {
            var validationResult = _validator.Validate(factura);
            if (!validationResult.IsValid)
            {
                errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return false;
            }

            errors = null;
            return true;
        }
    }
}
