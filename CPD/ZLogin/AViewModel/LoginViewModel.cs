using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Net;
using System.Security.RightsManagement;
using System.Windows.Input;
using CPD.ZLogin.ARepositorios;
using CPD.ZLogin.AModel;
using System.Security.Principal;

namespace CPD.ZLogin.AViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        //Campos
        private string _nombre_usuario;
        private SecureString _contrasena;
        private string _mensajeError;
        private bool _vistaActivada = true;
        private IUserRepository userRepository;

        public string Nombre_usuario
        {
            get
            {
                return _nombre_usuario;
            }
            set
            {
                _nombre_usuario = value;
                OnPropertyChanged(nameof(Nombre_usuario));
            }
        }
        public SecureString Contrasena
        {
            get
            {
                return _contrasena;
            }
            set
            {
                _contrasena = value;
                OnPropertyChanged(nameof(Contrasena));
            }
        }
        public string MensajeError
        {
            get
            {
                return _mensajeError;
            }
            set
            {
                _mensajeError = value;
                OnPropertyChanged(nameof(MensajeError));
            }
        }
        public bool VistaActivada
        {
            get
            {
                return _vistaActivada;
            }
            set
            {
                _vistaActivada = value;
                OnPropertyChanged(nameof(VistaActivada));
            }
        }

        //Comandos
        public ICommand LoginCommand { get; }
        public ICommand RecuperarContrasenaCommand { get; } 
        public ICommand MostrarContrasenaCommand { get; }
        public ICommand RecordarContrasenaCommand { get; }

        public LoginViewModel()
        {
            userRepository = new RepositorioUsuario();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecuperarContrasenaCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validarDatos;
            if (string.IsNullOrEmpty(Nombre_usuario) || Nombre_usuario.Length < 2 ||
                Contrasena == null || Contrasena.Length < 2)
                validarDatos = false;
            else
                validarDatos = true;
            return validarDatos;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var usuarioValido = userRepository.AutenticacionUsuario(new NetworkCredential(Nombre_usuario,Contrasena));
            if (usuarioValido)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Nombre_usuario), null);
                VistaActivada = false;
                MensajeError = "Credenciales correctas";
            }
            else
            {
                MensajeError = "Nombre de Usuario o Contraseña Incorrecta";
            }
        }
        private void ExecuteRecoverPassCommand(string usuario, string correo)
        {
            throw new NotImplementedException();
        }
 
    }
}
