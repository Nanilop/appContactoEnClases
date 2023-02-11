using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appContacto
{
    internal class Persona
	{	//estas propiedades lo ideal es minimo ponerlo en singular y en minusculas al principio, también si se puede ponerlo en ingles
		protected string nombre;
		protected string apellidoPaterno;
		protected string apellidoMaterno;
		protected DateTime? fechaNacimiento;//con ? lo ponemos nulleable, tambien se hace en el método de acceso
		//para seleccionar varias lineas es shift+Alt
		//si Ctrl+d te copia y pega la linea o lo seleccionado
			
		public DateTime? FechaNacimiento
		{
			get { return fechaNacimiento; }
			set { fechaNacimiento = value; }
		}


		public string ApellidoMaterno
		{
			get { return apellidoMaterno; }
			set { apellidoMaterno = value; }
		}


		public string ApellidoPaterno
		{
			get { return apellidoPaterno; }
			set { apellidoPaterno = value; }
		}


		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public string RFC {
			get {
                string resultado = "";
                resultado = apellidoPaterno.Substring(0, 1);
                for (int i = 1; i < apellidoPaterno.Length; i++)
                {
                    string vocal = apellidoPaterno.Substring(i, 1);
                    if (vocal == "a" | vocal == "á")
                    {
                        resultado += "A";
                        i = apellidoPaterno.Length + 1;
                    }
                    else if (vocal == "e" | vocal == "é")
                    {
                        resultado += "E";
                        i = apellidoPaterno.Length + 1;
                    }
                    else if (vocal == "i" | vocal == "í")
                    {
                        resultado += "I";
                        i = apellidoPaterno.Length + 1;
                    }
                    else if (vocal == "o" | vocal == "ó")
                    {
                        resultado += "O";
                        i = apellidoPaterno.Length + 1;
                    }
                    else if (vocal == "ú" | vocal == "u" | vocal == "ü")
                    {
                        resultado += "U";
                        i = apellidoPaterno.Length + 1;
                    }
                }
                if (String.IsNullOrWhiteSpace(apellidoMaterno) | String.IsNullOrEmpty(apellidoMaterno))
                {
                    resultado += "X";
                }
                else
                {
                    resultado += apellidoMaterno.Substring(0, 1);
                }

                resultado += nombre.Substring(0, 1);
                resultado += fechaNacimiento.Value.Year.ToString().Substring(2, 2);
                if (fechaNacimiento.Value.Month < 10)
                {
                    resultado += "0";
                    resultado += fechaNacimiento.Value.Month.ToString();
                }
                else
                {
                    resultado += fechaNacimiento.Value.Month.ToString();
                }
                if (fechaNacimiento.Value.Day < 10)
                {
                    resultado += "0";
                    resultado += fechaNacimiento.Value.Day.ToString();
                }
                else { resultado += fechaNacimiento.Value.Day.ToString(); }


                return resultado;
            }
		}
		public int Edad
		{
			get {
				//return DateTime.Parse((DateTime.Today - fechaNacimiento.Value)+"").Year;
				//return Convert.ToDateTime((DateTime.Today - fechaNacimiento).Value).Year;
				return (DateTime.Today.Year - fechaNacimiento.Value.Year);
            }
		}
		public Persona() {
			nombre = "";
			apellidoMaterno = "";
			apellidoPaterno = "";
			fechaNacimiento= null;
		}
        public Persona(string nombre,string apellidoPaterno,string apellidoMaterno,DateTime? fechaNacimiento) {
            this.nombre=nombre;
			this.apellidoPaterno= apellidoPaterno;
			this.apellidoMaterno = apellidoMaterno;
			this.fechaNacimiento = fechaNacimiento;


        }
        //lo correcto es que sea una propiedad especial, tipo readonly, lectura, porque te devulve las propiedades de la clase
        //no un método
        public override string ToString()
        {
			return nombre + " " + apellidoPaterno + " " + apellidoMaterno +" "+fechaNacimiento.Value.ToString("d");
        }


    }
}
