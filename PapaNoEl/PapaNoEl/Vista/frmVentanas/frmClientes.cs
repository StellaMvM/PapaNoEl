﻿using PapaNoEl.Controlador;
using PapaNoEl.Modelo.Entidades;
using PapaNoEl.Vista.frmBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapaNoEl.Vista.frmVentanas
{
    public partial class frmClientes : frmGestionar
    {
        ClienteC _ClienteC = new ClienteC();
        Cliente _Cliente = new Cliente();
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" &&
                txtApellido.Text != "" &&
                txtCedula.Text != "" &&
                cmbTipoEmpresa.SelectedItem.ToString() != "")
            {
                Guardar();
                MessageBox.Show("Guardado");
                Close();
            }
            else
                MessageBox.Show("Faltan datos");


            //Modelo.Entidades.Cliente Cl = new Modelo.Entidades.Cliente();
            //Modelo.Datos.ClienteD Cli = new Modelo.Datos.ClienteD();
            //Cl.nombre = txtNombre.Text;
            //Cl.apellido = txtApellido.Text;
            //Cl.ci = txtCedula.Text;
            //Cl.tipoempresa = cmbTipoEmpresa.SelectedItem.ToString();
            //Cli.Adicionar(Cl);
        }
        public void Guardar()
        {
            _Cliente.nombre = txtNombre.Text;
            _Cliente.apellido = txtApellido.Text;
            _Cliente.ci = txtCedula.Text;
            _Cliente.tipoempresa = cmbTipoEmpresa.SelectedItem.ToString();
            _ClienteC.GuardarCambios(_Cliente);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            try
            {
                dgvCliente.DataSource = _ClienteC.MostrarDatos();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvCliente.DataSource = _ClienteC.MostrarDatos(txtBuscar.Text);
        }
    }
}
