using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet.Repositories
{
    public partial class Form08CrudDepartamentos : Form
    {
        RepositoryDepartamentos repo;

        public Form08CrudDepartamentos()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();

            foreach (Departamento departamento in departamentos) 
            {
                this.lstDepartamentos.Items.Add(departamento.IdDepartamento + " - " + departamento.Nombre + " - " + departamento.Localidad);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();

            departamento.IdDepartamento = int.Parse(this.txtId.Text);
            departamento.Nombre = this.txtNombre.Text;
            departamento.Localidad = this.txtLocalidad.Text;

            await this.repo.AddDepartamentoAsync(departamento);

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
