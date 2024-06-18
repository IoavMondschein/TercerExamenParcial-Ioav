using FluentValidation;
using FluentValidation.Results;
using Repository.Models;
using Repository.Repository;

namespace Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly IValidator<ClienteModel> _clienteValidator;

        public ClienteService(ClienteRepository clienteRepository, IValidator<ClienteModel> clienteValidator)
        {
            _clienteRepository = clienteRepository;
            _clienteValidator = clienteValidator;
        }

        public async Task<ValidationResult> CreateClienteAsync(ClienteModel cliente)
        {
            ValidationResult result = _clienteValidator.Validate(cliente);

            if (!result.IsValid)
            {
                return result;
            }

            _clienteRepository.AddCliente(cliente);
            return result;
        }

        public IEnumerable<ClienteModel> GetAllClientesActivos()
        {
            return _clienteRepository.GetAllClientes().Where(c => c.Estado);
        }
    }
}
