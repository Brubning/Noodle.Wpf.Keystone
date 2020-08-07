
namespace Noodle.Wpf.Keystone.ViewModels
{
    public class AssetSearchCriteria : ViewModelBase
    {
        private string _uprn;
        private string _address;
        private string _postcode;

        public string Uprn
        {
            get { return _uprn; }
            set
            {
                _uprn = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                OnPropertyChanged();
            }
        }
    }
}
