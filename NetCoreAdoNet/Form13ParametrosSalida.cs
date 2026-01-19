using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#region PROCEDURES
//create procedure SP_ALL_DEPARTAMENTOS
//as
//	select * from DEPT
//go
//create procedure SP_EMPLEADOS_DPEPARTAMENTOS_OUT
//(@nombre nvarchar(50), @suma int out, @media int out, @personas int out)
//as
//	declare @iddept int 
//	select @iddept = DEPT_NO from DEPT where DNOMBRE=@nombre
//	select * from EMP where DEPT_NO = @iddept
//	select @suma = SUM(SALARIO), @media = AVG(SALARIO), @personas = COUNT(EMP_NO) from EMP where DEPT_NO = @iddept
//go
#endregion

namespace NetCoreAdoNet
{
    public partial class Form13ParametrosSalida : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form13ParametrosSalida()
        {
            InitializeComponent();

            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = cn;

            this.LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            this.cmbDepartamentos.Items.Clear();

            while(await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                cmbDepartamentos.Items.Add(nombre);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
        }

        private async void btnMostrar_Click(object sender, EventArgs e)
        {
            string sql = "SP_EMPLEADOS_DPEPARTAMENTOS_OUT";
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();

            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            pamSuma.Value = 0;
            pamSuma.Direction = ParameterDirection.Output;
            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@media";
            pamMedia.Value = 0;
            pamMedia.Direction = ParameterDirection.Output;
            SqlParameter pamPersonas = new SqlParameter();
            pamPersonas.ParameterName = "@personas";
            pamPersonas.Value = 0;
            pamPersonas.Direction = ParameterDirection.Output;

            this.com.Parameters.Add(pamNombre);
            this.com.Parameters.Add(pamSuma);
            this.com.Parameters.Add(pamMedia);
            this.com.Parameters.Add(pamPersonas);
            this.com.CommandType= CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }

            await this.reader.CloseAsync();

            this.txtSuma.Text = pamSuma.Value.ToString();
            this.txtMedia.Text = pamMedia.Value.ToString();
            this.txtPersonas.Text = pamPersonas.Value.ToString();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }
    }
}