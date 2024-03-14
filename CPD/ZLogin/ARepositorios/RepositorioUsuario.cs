using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CPD.ZLogin.AModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;

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
                command.CommandText = "SELECT * FROM dbo.usuario WHERE nombre_usuario=@Nombre_usuario and contrasena=@Contrasena";
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
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from usuario where nombre_usuario=@nombre_usuario";
                command.Parameters.Add("@nombre_usuario", SqlDbType.NVarChar).Value = Nombre_usuario;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Nombre_usuario = reader[1].ToString(),
                            Contrasena = string.Empty,
                            Nombres = reader[3].ToString(),
                            Apellido_paterno = reader[4].ToString(),
                            Apellido_materno = reader[5].ToString(),
                            Correo = reader[6].ToString()
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
