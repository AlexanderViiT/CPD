using System;
using FontAwesome.Sharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPD.ZLogin.AModel;
using CPD.ZLogin.ARepositorios;
using CPD.ZLogin.AViewModel;
using WPF_LoginForm.Models;
using System.Windows.Input;

namespace CPD.ZViewModel
{
    public class DashboardViewModel : ViewModelBase
    {

        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

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

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set 
            { 
            _currentChildView = value;
            OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }

        public DashboardViewModel()
        {
            userRepository = new RepositorioUsuario();
            CurrentUserAccount = new UserAccountModel();

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            {
                var user = userRepository.getByUsername(Thread.CurrentPrincipal.Identity.Name);
                if (user != null)
                {
                    CurrentUserAccount.Username = user.Nombre_usuario;
                    CurrentUserAccount.DisplayName = $"{user.Nombres} {user.Apellido_paterno} {user.Apellido_materno};)";
                    CurrentUserAccount.ProfilePicture = null;
                }
                else
                {
                    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                    //Hide child views.
                }
            }
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Inicio";
            Icon = IconChar.Home;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customer";
            Icon = IconChar.UserGroup;
        }
    }
}


