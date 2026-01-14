using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = cn;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string sql = "select * from DEPT";

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            
            await this.cn.OpenAsync();
            
            this.reader = await this.com.ExecuteReaderAsync();

            List<Departamento> departamentos = new List<Departamento>();

            while (await this.reader.ReadAsync())
            {
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();

                departamentos.Add(departamento);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return departamentos;
        }

        public async Task AddDepartamentoAsync(Departamento departamento)
        {
            string sql = "insert into DEPT (DEPT_NO, DNOMBRE, LOC) VALUES (@idDepartamento, @nombre, @localidad)";
            SqlParameter idDepartamento = new SqlParameter("@idDepartamento", departamento.IdDepartamento);
            SqlParameter idDepartamento = new SqlParameter("@idDepartamento", departamento.IdDepartamento);
            SqlParameter idDepartamento = new SqlParameter("@idDepartamento", departamento.IdDepartamento);
        }
    }
}
