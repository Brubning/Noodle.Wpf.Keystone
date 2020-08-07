
namespace Noodle.Wpf.Keystone.ViewModels
{
    public class Competency : ViewModelBase
    {
        private int _id;
        private string _description;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}
