using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GestorMovilChip.Clase
{
    public static class Seguridad
    {
        public static string CalcularHash(string texto)
        {
            if (texto == null)
                texto = "";

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                // Convierte a string ejemplo: "8c6976e5..."
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
