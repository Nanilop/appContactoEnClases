using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appContacto
{
    public partial class Form1 : Form
    {
        //Persona p;
        Contacto c;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //se pueden realizar mascked textbox? para una forma predeterminada
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            c= new Contacto();
            c.Nombre = txtNombre.Text;
            c.ApellidoPaterno = txtApellidoPaterno.Text;
            c.ApellidoMaterno = txtApellidoMaterno.Text;
            c.FechaNacimiento = dtpFechaNacimiento.Value;
            c.Telefono= txtTelefono.Text;
            c.Correo= txtCorreo.Text;
            int no = 0;
            if (!c.IsValidEmail()) { 
            adverCorreo.Visible = true;
                no++;
            }
            if (c.Edad<18) {
            adverEdad.Visible = true;
                no++;
            }
            if (no == 0) { 
                MessageBox.Show(c.RFC);
                no = 0;
            }
            /*p= new Persona();
            p.Nombre=txtNombre.Text;
            p.ApellidoPaterno=txtApellidoPaterno.Text;
            p.ApellidoMaterno=txtApellidoMaterno.Text;
            p.FechaNacimiento = dtpFechaNacimiento.Value;
            MessageBox.Show(p.ToString());*/
        }
       

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            adverCorreo.Visible = false;
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            adverEdad.Visible = false;
        }
    }
}
