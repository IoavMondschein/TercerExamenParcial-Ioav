using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repository;
using Services;
using FluentValidation.Results;

namespace api.SPIoavMondschein.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteRepository clienteRepository, ClienteService clienteService)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpPost("CrearCliente")]
        public async Task<IActionResult> PostCliente([FromBody] ClienteModel cliente)
        {
            ValidationResult validationResult = await _clienteService.CreateClienteAsync(cliente);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok("Cliente agregado correctamente.");
        }

        [HttpGet("ObtenerClientes")]
        public IActionResult GetAllClientes()
        {
            var clientes = _clienteService.GetAllClientesActivos();
            return Ok(clientes);
        }

        [HttpGet("ObtenerClientePorId/{id}")]
        public IActionResult GetClienteById(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            return Ok(cliente);
        }

        [HttpPut("ActualizarCliente/{id}")]
        public IActionResult PutCliente(int id, [FromBody] ClienteModel cliente)
        {
            var existingCliente = _clienteRepository.GetClienteById(id);
            if (existingCliente == null)
                return NotFound("Cliente no encontrado.");

            ValidationResult validationResult = _clienteService.CreateClienteAsync(cliente).Result;

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            existingCliente.Nombre = cliente.Nombre;
            existingCliente.Apellido = cliente.Apellido;
            existingCliente.Documento = cliente.Documento;
            existingCliente.Direccion = cliente.Direccion;
            existingCliente.Mail = cliente.Mail;
            existingCliente.Celular = cliente.Celular;
            existingCliente.Estado = cliente.Estado;

            _clienteRepository.UpdateCliente(existingCliente);

            return Ok("Cliente actualizado correctamente.");
        }

        [HttpDelete("EliminarCliente/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var existingCliente = _clienteRepository.GetClienteById(id);
            if (existingCliente == null)
                return NotFound("Cliente no encontrado.");

            _clienteRepository.DeleteCliente(id);

            return Ok("Cliente eliminado correctamente.");
        }
    }
}
