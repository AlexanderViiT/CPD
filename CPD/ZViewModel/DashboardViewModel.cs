using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPD.ZLogin.AModel;
using CPD.ZLogin.ARepositorios;
using CPD.ZLogin.AViewModel;
using WPF_LoginForm.Models;

namespace CPD.ZViewModel
{
    public class DashboardViewModel : ViewModelBase
    {

        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public DashboardViewModel()
        {
            userRepository = new RepositorioUsuario();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }
        private void LoadCurrentUserData()
        {
            var user = userRepository.getByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Nombre_usuario;
                CurrentUserAccount.DisplayName = $"Welcome {user.Nombres} {user.Apellido_paterno} {user.Apellido_materno};)";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }
    }


}
