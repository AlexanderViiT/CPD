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
            _connectionString = "Server=(local); Database=CPD; Integrated Security=true; TrustServerCertificate=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}