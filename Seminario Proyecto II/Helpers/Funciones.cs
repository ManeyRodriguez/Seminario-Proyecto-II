using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Seminario_Proyecto_II.Helpers
{
    public static class Funciones
    {
        
        private static bool IsValidEmail(string email)
        {
            try
            {
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return emailRegex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GenerarPin()
        {
            Random random = new Random();
            return random.Next(100000, 1000000).ToString(); // Generates a number between 100000 and 999999.
        }

        public static bool IsValidDocID(string docID)
        {
            try
            {
                var docIDRegex = new Regex(@"^[0-9]{11,20}$");
                return docIDRegex.IsMatch(docID);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public class EstadoItem
        {
            public string Texto { get; set; }
            public bool Valor { get; set; }

            public override string ToString()
            {
                return Texto; // Lo que se mostrará en el ComboBox
            }
        }

    }
}
