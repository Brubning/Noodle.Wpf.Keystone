using System;
using System.Threading.Tasks;
using System.Windows;
using Noodle.Wpf.Keystone.Services;
using Noodle.Wpf.Keystone.ViewModels;

namespace Noodle.Wpf.Keystone.Views.OpenSession
{
    /// <summary>
    /// Controls opening a session to Keystone.
    /// </summary>
    public class OpenSessionViewModel : ViewModelBase
    {
        public OpenSessionViewModel()
        {
        }

        public OpenSessionViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;
            SessionId = Guid.Empty;

            HideOpenSessionCommand = new RelayCommand<object>(
                (param) => HideOpenSession()
                );
            OpenSessionCommand = new RelayCommandAsync<Guid>(
                (param) => OpenSession(),
                (param) => param == Guid.Empty);
        }

        #region Relay Commands

        private RelayCommand<object> _hideOpenSessionCommand;
        private RelayCommandAsync<Guid> _openSessionCommand;

        public RelayCommand<object> HideOpenSessionCommand
        {
            get { return _hideOpenSessionCommand; }
            set
            {
                _hideOpenSessionCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommandAsync<Guid> OpenSessionCommand
        {
            get { return _openSessionCommand; }
            set
            {
                _openSessionCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Properties

        private readonly SessionService _sessionService;
        //TODO Convert to a UserCredentials view model which can be bound to the relaycommand as command parameter
        private bool _isVisible = true;
        private string _username;
        private string _password;
        private string _database;
        private Guid _sessionId;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Visibility));
            }
        }

        public bool IsSessionOpen
        {
            get { return SessionId != Guid.Empty; }
        }

        public Visibility Visibility
        {
            get
            {
                return IsVisible
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Database
        {
            get { return _database; }
            set
            {
                _database = value;
                OnPropertyChanged();
            }
        }

        public Guid SessionId
        {
            get { return _sessionId; }
            set
            {
                _sessionId = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSessionOpen));
            }
        }

        #endregion

        /// <summary>
        /// Set the visibility property to hide the OpenSession user control
        /// </summary>
        private void HideOpenSession()
        {
            if (IsVisible)
                IsVisible = false;
        }

        /// <summary>
        /// Open a session using the bound credentials
        /// </summary>
        /// <returns></returns>
        private async Task OpenSession()
        {
            if (!CanOpen())
                return;

            SessionId = await _sessionService.OpenKeystoneSession(_username, _password, _database);
            IsVisible = false;
        }

        /// <summary>
        /// Check whether everything is ready to open a session
        /// </summary>
        /// <returns></returns>
        private bool CanOpen()
        {
            return !(string.IsNullOrEmpty(Username) ||
                    string.IsNullOrEmpty(Password) ||
                    string.IsNullOrEmpty(Database));
        }
    }
}
