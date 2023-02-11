using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appContacto
{
    internal class Contacto:Persona
    {
		private string telefono;
		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}


		public string Telefono
		{
			get { return telefono; }
			set {
				
				telefono = value.Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("_", "").Substring(0,10);  }
		}
		public Contacto():base() {
			telefono = string.Empty;
			correo = string.Empty;

        }
        public Contacto( string nombre,string apellidoPaterno, string apellidoMaterno,DateTime? fechaNacimiento, string telefono, string correo) : base(nombre,apellidoPaterno,apellidoMaterno,fechaNacimiento)
        {
            this.telefono = telefono;
           this.correo =correo;

        }
        public override string ToString()
        {
            return base.ToString()+" "+telefono+" "+correo;
        }
        public bool IsValidEmail()
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            try
            {
                // Normalize the domain
                correo = Regex.Replace(correo, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(correo,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}
