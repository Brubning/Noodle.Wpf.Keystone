using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Noodle.Wpf.Keystone.Services;
using Noodle.Wpf.Keystone.Views.OpenSession;

namespace Noodle.Wpf.Keystone
{
    public class MainWindowViewModel : ViewModels.ViewModelBase
    {
        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;
            OpenSessionViewModel = new OpenSessionViewModel(_sessionService);

            OpenSessionCommand = new RelayCommand<Guid>(
                (param) => ShowOpenSession(),
                (param) => param == Guid.Empty);
            CloseSessionCommand = new RelayCommand<Guid>(
                CloseSession,
                (param) => param != Guid.Empty);
            GetServiceTypesCommand = new RelayCommandAsync<object>(
                (param) => GetServiceTypes(),
                (param) => OpenSessionViewModel.IsSessionOpen);
        }

        #region Relay Commands

        private RelayCommand<Guid> _openSessionCommand;
        private RelayCommand<Guid> _closeSessionCommand;
        private RelayCommandAsync<object> _getServiceTypesCommand;

        public RelayCommand<Guid> OpenSessionCommand
        {
            get { return _openSessionCommand; }
            set
            {
                _openSessionCommand = value; 
                OnPropertyChanged();
            }
        }

        public RelayCommand<Guid> CloseSessionCommand
        {
            get { return _closeSessionCommand; }
            set
            {
                _closeSessionCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommandAsync<object> GetServiceTypesCommand
        {
            get { return _getServiceTypesCommand; }
            set
            {
                _getServiceTypesCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion
        
        private readonly SessionService _sessionService;
        private ObservableCollection<object> _serviceTypes;

        public ObservableCollection<object> ServiceTypes
        {
            get { return _serviceTypes; }
            set
            {
                _serviceTypes = value; 
                OnPropertyChanged();
            }
        }

        private OpenSessionViewModel _openSessionViewModel;

        public OpenSessionViewModel OpenSessionViewModel
        {
            get { return _openSessionViewModel; }
            set
            {
                _openSessionViewModel = value;
                OnPropertyChanged();
            }
        }

        /*
         * Show the Open Session overlay
         */
        private void ShowOpenSession()
        {
            OpenSessionViewModel.IsVisible = true;
        }

        /// <summary>
        /// Close an API session
        /// </summary>
        /// <param name="sessionId"></param>
        private async void CloseSession(Guid sessionId)
        {
            if (sessionId == Guid.Empty)
                return;

            await _sessionService.CloseKeystoneSession(OpenSessionViewModel.SessionId);
            OpenSessionViewModel.SessionId = Guid.Empty;
        }

        /// <summary>
        /// Get list of service types from Keystone
        /// </summary>
        /// <returns></returns>
        private async Task GetServiceTypes()
        {
            var result = await _sessionService.GetEntity(OpenSessionViewModel.SessionId);

            ServiceTypes = new ObservableCollection<object>(result);
        }
    }
}
