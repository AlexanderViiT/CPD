using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CPD.ZLogin.AModel
{
    public interface IUserRepository
    {
        bool AutenticacionUsuario(NetworkCredential credential);
        void Add(UserModel modeloUsuario);
        void Edit(UserModel modeloUsuario);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel getByUsername(string Nombre_usuario);
        UserModel getByPassword(string Contrasena);
        IEnumerable<UserModel> GetByAll();
    }
}
