using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
namespace CPD.ZLogin.ARepositorios
{
    public abstract class RepositorioBase
    {
        private readonly string _connectionString;
        public RepositorioBase()
        {
            _connectionString = "Server=192.168.100.85; User Id=conexion; Password=conexion; Database=CPD; TrustServerCertificate=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}