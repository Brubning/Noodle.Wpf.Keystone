using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Noodle.Wpf.Keystone.Models;
using Noodle.Wpf.Keystone.Services;
using Noodle.Wpf.Keystone.ViewModels;
using Noodle.Wpf.Keystone.Views.OpenSession;

namespace Noodle.Wpf.Keystone.Views.PropertySearch
{
    public class PropertySearchViewModel : ViewModelBase
    {
        public PropertySearchViewModel()
        {
        }

        public PropertySearchViewModel(
            SessionService sessionService,
            OpenSessionViewModel openSessionViewModel)
        {
            _sessionService = sessionService;
            //TODO Remove need for OpenSessionViewModel (Move session ID to session service?)
            _openSessionViewModel = openSessionViewModel;
            SearchCriteria = new AssetSearchCriteria();
            AssetSearchCommand = new RelayCommandAsync<object>(
                (param) => AssetSearch());
        }

        #region RelayCommands

        private RelayCommandAsync<object> _assetSearchCommand;

        public RelayCommandAsync<object> AssetSearchCommand
        {
            get { return _assetSearchCommand; }
            set
            {
                _assetSearchCommand = value;
                OnPropertyChanged();
            }
        }

        #endregion
        
        private readonly SessionService _sessionService;
        private readonly OpenSessionViewModel _openSessionViewModel;
        private ObservableCollection<Asset> _searchResults;
        private Asset _selectedResult;

        public AssetSearchCriteria SearchCriteria { get; }

        public ObservableCollection<Asset> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                OnPropertyChanged();
            }
        }

        public Asset SelectedResult
        {
            get { return _selectedResult; }
            set
            {
                _selectedResult = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Search for asset by UPRN
        /// </summary>
        /// <returns></returns>
        private async Task AssetSearch()
        {
            var result = await _sessionService.GetAsset(_openSessionViewModel.SessionId, SearchCriteria);
            SearchResults = new ObservableCollection<Asset>(result);
        }
    }
}
