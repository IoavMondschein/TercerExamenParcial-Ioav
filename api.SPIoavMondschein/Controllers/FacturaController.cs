using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Repository;
using Services;
using System;
using System.Collections.Generic;

namespace api.SPIoavMondschein.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaRepository _facturaRepository;
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaRepository facturaRepository, FacturaService facturaService)
        {
            _facturaRepository = facturaRepository;
            _facturaService = facturaService;
        }

        [HttpPost("CrearFactura")]
        public IActionResult PostFactura([FromBody] FacturaModel factura)
        {
            if (!_facturaService.ValidateFactura(factura))
                return BadRequest("Los datos de la factura no son válidos.");

            _facturaRepository.AddFactura(factura);
            return Ok("Factura agregada correctamente.");
        }

        [HttpGet("ObtenerFacturas")]
        public IActionResult GetAllFacturas()
        {
            var facturas = _facturaRepository.GetAllFacturas();
            return Ok(facturas);
        }

        [HttpGet("ObtenerFacturaPorId/{id}")]
        public IActionResult GetFacturaById(int id)
        {
            var factura = _facturaRepository.GetFacturaById(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura);
        }

        [HttpPut("Actualizar/{id}")]
        public IActionResult PutFactura(int id, [FromBody] FacturaModel factura)
        {
            var existingFactura = _facturaRepository.GetFacturaById(id);
            if (existingFactura == null)
            {
                return NotFound();
            }

            factura.Id = id;
            _facturaRepository.UpdateFactura(factura);
            return Ok("Factura actualizada correctamente.");
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult DeleteFactura(int id)
        {
            var factura = _facturaRepository.GetFacturaById(id);
            if (factura == null)
            {
                return NotFound();
            }

            _facturaRepository.DeleteFactura(id);
            return Ok("Factura eliminada correctamente.");
        }
    }
}
