using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet.Repositories
{
    public partial class Form14Settings : Form
    {
        public Form14Settings()
        {
            InitializeComponent();
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("SqlLocal");
            string imagen1 = configuration.GetSection("Imagenes:imagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imagen2").Value;
            string colorLetra = configuration.GetSection("Colores:letra").Value;
            string colorFondo = configuration.GetSection("Colores:fondo").Value;

            this.lblConexion.Text = connectionString;
            this.pictureBox1.Load(imagen1);
            this.pictureBox2.Load(imagen2);
            this.btnLeer.ForeColor = Color.FromName(colorLetra);
            this.BackColor = Color.FromName(colorFondo);
        }

        private void btnHelper_Click(object sender, EventArgs e)
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();

            string connectionString = configuration.GetConnectionString("SqlLocal");
            string imagen1 = configuration.GetSection("Imagenes:imagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imagen2").Value;
            string colorLetra = configuration.GetSection("Colores:letra").Value;
            string colorFondo = configuration.GetSection("Colores:fondo").Value;

            this.lblConexion.Text = connectionString;
            this.pictureBox1.Load(imagen1);
            this.pictureBox2.Load(imagen2);
            this.btnLeer.ForeColor = Color.FromName(colorLetra);
            this.BackColor = Color.FromName(colorFondo);
        }
    }
}