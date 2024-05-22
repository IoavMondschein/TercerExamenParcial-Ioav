using Repository.Models;
using Repository.Repository;

namespace Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool ValidateCliente(ClienteModel cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido) || string.IsNullOrEmpty(cliente.Documento))
                return false;

            if (cliente.Nombre.Length < 3 || cliente.Apellido.Length < 3 || cliente.Documento.Length < 3)
                return false;

            if (!int.TryParse(cliente.Celular, out _) || cliente.Celular.Length != 10)
                return false;

            return true;
        }
    }
}
