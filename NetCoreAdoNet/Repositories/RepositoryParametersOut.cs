using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helpers;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text;

#region PROCEDURES
//create procedure SP_ALL_DEPARTAMENTOS
//as
//	select * from DEPT
//go
//alter procedure SP_EMPLEADOS_DPEPARTAMENTOS_OUT
//(@nombre nvarchar(50), @suma int out, @media int out, @personas int out)
//as
//	declare @iddept int 
//	select @iddept = DEPT_NO from DEPT where DNOMBRE=@nombre
//	select * from EMP where DEPT_NO = @iddept
//	select @suma = isnull(SUM(SALARIO), 0), @media = isnull(AVG(SALARIO), 0), @personas = COUNT(EMP_NO) from EMP where DEPT_NO = @iddept
//go
#endregion

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryParametersOut
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryParametersOut()
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();

            string connectionString = configuration.GetConnectionString("SqlLocal");
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = cn;
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

           List<string> departamentos = new List<string>();

            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return departamentos;
        }

        public async Task<EmpleadosParametersOut> GetEmpleadosModelAsync(string nombreDepartamento)
        {
            string sql = "SP_EMPLEADOS_DPEPARTAMENTOS_OUT";

            SqlParameter pamNombre = new SqlParameter("@nombre", nombreDepartamento);
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
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();
            EmpleadosParametersOut model = new EmpleadosParametersOut();

            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                model.Apellidos.Add(apellido);
            }

            await this.reader.CloseAsync();

            model.SumaSalarial = int.Parse(pamSuma.Value.ToString());
            model.MediaSalarial = int.Parse(pamMedia.Value.ToString());
            model.Personas = int.Parse(pamPersonas.Value.ToString());

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return model;
        }
    }
}