using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Noodle.Wpf.Keystone.Services;
using Noodle.Wpf.Keystone.ViewModels;
using Noodle.Wpf.Keystone.Views.OpenSession;
using Noodle.Wpf.Keystone.Views.PropertySearch;

namespace Noodle.Wpf.Keystone
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(SessionService sessionService)
        {
            _sessionService = sessionService;
            OpenSessionViewModel = new OpenSessionViewModel(_sessionService);
            PropertySearchViewModel = new PropertySearchViewModel(_sessionService, OpenSessionViewModel);

            OpenSessionCommand = new RelayCommand<Guid>(
                (param) => ShowOpenSession(),
                (param) => param == Guid.Empty);
            CloseSessionCommand = new RelayCommand<Guid>(
                CloseSession,
                (param) => param != Guid.Empty);
            LoadConfigurationCommand = new RelayCommandAsync<object>(
                (param) => LoadConfiguration(),
                (param) => OpenSessionViewModel.IsSessionOpen);
            ShowAssetSearchCommand = new RelayCommand<object>(
                (param) => ShowAssetSearch());
            HideAssetSearchCommand = new RelayCommand<object>(
                (param) => HideAssetSearch());
            SelectAssetCommand = new RelayCommand<Models.Asset>(
                SetSelectedAsset,
                (param) => param != null);
            AddCompletedVisitCommand = new RelayCommandAsync<object>(
                (param) => AddCompletedVisit());
            AddCertificateCommand = new RelayCommandAsync<object>(
                (param) => AddCertificate());
        }

        #region Relay Commands

        private RelayCommand<Guid> _openSessionCommand;
        private RelayCommand<Guid> _closeSessionCommand;
        private RelayCommandAsync<object> _loadConfigurationCommand;
        private RelayCommand<object> _showAssetSearchCommand;
        private RelayCommand<object> _hideAssetSearchCommand;
        private RelayCommand<Models.Asset> _selectAssetCommand;
        private RelayCommandAsync<object> _addCompletedVisitCommand;
        private RelayCommandAsync<object> _addCertificateCommand;

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

        public RelayCommandAsync<object> LoadConfigurationCommand
        {
            get { return _loadConfigurationCommand; }
            set
            {
                _loadConfigurationCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> ShowAssetSearchCommand
        {
            get { return _showAssetSearchCommand; }
            set
            {
                _showAssetSearchCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> HideAssetSearchCommand
        {
            get { return _hideAssetSearchCommand; }
            set
            {
                _hideAssetSearchCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Models.Asset> SelectAssetCommand
        {
            get { return _selectAssetCommand; }
            set
            {
                _selectAssetCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommandAsync<object> AddCompletedVisitCommand
        {
            get { return _addCompletedVisitCommand; }
            set
            {
                _addCompletedVisitCommand = value;
                OnPropertyChanged();
            }
        }

        public RelayCommandAsync<object> AddCertificateCommand
        {
            get { return _addCertificateCommand; }
            set
            {
                _addCertificateCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private Visibility _assetSearchVisibility = Visibility.Collapsed;
        private Models.Asset _currentAsset;

        private readonly SessionService _sessionService;
        private ObservableCollection<Competency> _competencys;
        private ObservableCollection<Contact> _contacts;
        private Contact _selectedContact;
        private ObservableCollection<EquipmentType> _equipmentTypes;
        private ObservableCollection<MakeModel> _makeModels;
        private ObservableCollection<ServiceType> _serviceTypes;
        private ServiceType _selectedServiceType;
        private DateTime? _serviceDue;
        private DateTime? _serviceActual;
        private string _serviceOutcome = "Complete";
        private string _serviceComments;
        private Models.Visit _completedVisit;
        private string _certificatePath = @"\\KEYSTONE-DOC\Store\Keystone\Gas\CP12\LGSR Certificates\CP12-B217000770001-190219.pdf";

        public Visibility AssetSearchVisibility
        {
            get { return _assetSearchVisibility; }
            set
            {
                _assetSearchVisibility = value;
                OnPropertyChanged();
            }
        }

        public Models.Asset CurrentAsset
        {
            get { return _currentAsset; }
            set
            {
                _currentAsset = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Competency> Competencys
        {
            get { return _competencys; }
            set
            {
                _competencys = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value; 
                OnPropertyChanged();
            }
        }

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EquipmentType> EquipmentTypes
        {
            get { return _equipmentTypes; }
            set
            {
                _equipmentTypes = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MakeModel> MakeModels
        {
            get { return _makeModels; }
            set
            {
                _makeModels = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ServiceType> ServiceTypes
        {
            get { return _serviceTypes; }
            set
            {
                _serviceTypes = value; 
                OnPropertyChanged();
            }
        }

        public ServiceType SelectedServiceType
        {
            get { return _selectedServiceType; }
            set
            {
                _selectedServiceType = value;
                OnPropertyChanged();
            }
        }

        public DateTime? ServiceDue
        {
            get { return _serviceDue; }
            set
            {
                _serviceDue = value;
                OnPropertyChanged();
            }
        }

        public DateTime? ServiceActual
        {
            get { return _serviceActual; }
            set
            {
                _serviceActual = value;
                OnPropertyChanged();
            }
        }

        public string ServiceOutcome
        {
            get { return _serviceOutcome; }
            set
            {
                _serviceOutcome = value;
                OnPropertyChanged();
            }
        }

        public string ServiceComments
        {
            get { return _serviceComments; }
            set
            {
                _serviceComments = value;
                OnPropertyChanged();
            }
        }

        public Models.Visit CompletedVisit
        {
            get { return _completedVisit; }
            set
            {
                _completedVisit = value;
                OnPropertyChanged();
            }
        }

        public string CertificatePath
        {
            get { return _certificatePath; }
            set
            {
                _certificatePath = value;
                OnPropertyChanged();
            }
        }

        private OpenSessionViewModel _openSessionViewModel;
        private PropertySearchViewModel _propertySearchViewModel;

        public OpenSessionViewModel OpenSessionViewModel
        {
            get { return _openSessionViewModel; }
            set
            {
                _openSessionViewModel = value;
                OnPropertyChanged();
            }
        }

        public PropertySearchViewModel PropertySearchViewModel
        {
            get { return _propertySearchViewModel; }
            set
            {
                _propertySearchViewModel = value;
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
        /// Load all configuration items
        /// </summary>
        /// <returns></returns>
        private async Task LoadConfiguration()
        {
            await GetCompetencys();
            await GetContacts();
            //await GetEquipmentTypes();
            //await GetMakeModels();
            await GetServiceTypes();
        }

        /// <summary>
        /// Get list of competency from Keystone
        /// </summary>
        /// <returns></returns>
        private async Task GetCompetencys()
        {
            var result = await _sessionService.GetCompetencys(OpenSessionViewModel.SessionId);

            Competencys = new ObservableCollection<Competency>(result.OrderBy(x => x.Description));
        }

        /// <summary>
        /// Get list of contacts from Keystone
        /// </summary>
        /// <returns></returns>
        private async Task GetContacts()
        {
            var result = await _sessionService.GetContacts(OpenSessionViewModel.SessionId);

            Contacts = new ObservableCollection<Contact>(result.OrderBy(x => x.Name));
        }

        /// <summary>
        /// Get list of EquipmentTypes from Keystone
        /// </summary>
        /// <returns></returns>
        private async Task GetEquipmentTypes()
        {
            var result = await _sessionService.GetEquipmentTypes(OpenSessionViewModel.SessionId);

            EquipmentTypes = new ObservableCollection<EquipmentType>(result.OrderBy(x => x.Description));
        }

        /// <summary>
        /// Get list of make model from Keystone
        /// </summary>
        /// <returns></returns>
        private async Task GetMakeModels()
        {
            var result = await _sessionService.GetMakeModels(OpenSessionViewModel.SessionId);

            MakeModels = new ObservableCollection<MakeModel>(
                result
                    .OrderBy(x => x.Make)
                    .ThenBy(x => x.Model)
                    .ThenBy(x => x.SubModel));
        }

        /// <summary>
        /// Get list of service types from Keystone
        /// </summary>
        /// <returns></returns>
        private async Task GetServiceTypes()
        {
            var result = await _sessionService.GetServiceTypes(OpenSessionViewModel.SessionId);

            ServiceTypes = new ObservableCollection<ServiceType>(result.OrderBy(x => x.Description));
        }

        /// <summary>
        /// Show the asset search overlay
        /// </summary>
        private void ShowAssetSearch()
        {
            AssetSearchVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Hide the asset search overlay
        /// </summary>
        private void HideAssetSearch()
        {
            AssetSearchVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Set the selected asset and hide the search
        /// </summary>
        /// <param name="selectedAsset"></param>
        private void SetSelectedAsset(Models.Asset selectedAsset)
        {
            CurrentAsset = selectedAsset;
            HideAssetSearch();
        }

        /// <summary>
        /// Add a completed visit
        /// </summary>
        /// <returns></returns>
        private async Task AddCompletedVisit()
        {
            var visit = new Models.Visit
            {
                Uprn = CurrentAsset.Uprn,
                ServiceType = SelectedServiceType?.Description,
                Organisation = SelectedContact.Name,
                Due = ServiceDue,
                Actual = ServiceActual,
                Outcome = ServiceOutcome,
                Comments = ServiceComments
            };

            CompletedVisit = await _sessionService.AddCompletedVisit(OpenSessionViewModel.SessionId, visit);
        }

        /// <summary>
        /// Add certificate to existing visit
        /// </summary>
        /// <returns></returns>
        private async Task AddCertificate()
        {
            if (CompletedVisit == null || CompletedVisit.VisitId == 0)
                return;

            await _sessionService.AddCertificateToVisit(
                OpenSessionViewModel.SessionId,
                CertificatePath,
                CompletedVisit);
        }
    }
}
