using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CPD.ZLogin.AModel;

namespace CPD.ZLogin.ARepositorios
{
    public class RepositorioUsuario : RepositorioBase, IUserRepository
    {
        public void Add(UserModel modeloUsuario)
        {
            throw new NotImplementedException();
        }

        public bool AutenticacionUsuario(NetworkCredential credential)
        {
            bool validUser;
            using (var connection=GetConnection())
            using (var command=new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM usuario WHERE nombre_usuario=@Nombre_usuario and contrasena=@Contrasena";
                command.Parameters.Add("@nombre_usuario", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@contrasena", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel modeloUsuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel getByPassword(string Contrasena)
        {
            throw new NotImplementedException();
        }

        public UserModel getByUsername(string Nombre_usuario)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
