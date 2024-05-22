using Repository.Models;
using Repository.Repository;

namespace Services
{
    public class FacturaService
    {
        public bool ValidateFactura(FacturaModel factura)
        {
            
            if (!ValidateNumeroFactura(factura.Nro_Factura))
                return false;

            
            if (factura.Total == 0 || factura.Total_iva5 == 0 || factura.Total_iva10 == 0 || factura.Total_iva == 0)
                return false;

            
            if (string.IsNullOrEmpty(factura.Total_letras) || factura.Total_letras.Length < 6)
                return false;

            return true;
        }

        private bool ValidateNumeroFactura(string numeroFactura)
        {
            
            if (string.IsNullOrEmpty(numeroFactura) || numeroFactura.Length != 15)
                return false;

            
            if (!char.IsDigit(numeroFactura[0]) || !char.IsDigit(numeroFactura[1]) || !char.IsDigit(numeroFactura[2]) ||
                numeroFactura[3] != '-' || !char.IsDigit(numeroFactura[4]) || !char.IsDigit(numeroFactura[5]) ||
                !char.IsDigit(numeroFactura[6]) || numeroFactura[7] != '-' || !char.IsDigit(numeroFactura[8]) ||
                !char.IsDigit(numeroFactura[9]) || !char.IsDigit(numeroFactura[10]) || !char.IsDigit(numeroFactura[11]) ||
                !char.IsDigit(numeroFactura[12]) || !char.IsDigit(numeroFactura[13]) || !char.IsDigit(numeroFactura[14]))
            {
                return false;
            }

            return true;
        }
    }
}
