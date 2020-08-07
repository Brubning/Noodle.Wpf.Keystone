
namespace Noodle.Wpf.Keystone.ViewModels
{
    public class ServiceType : ViewModelBase
    {
        // TODO KAPI is configured to publish ServiceTypeId
        private int _id;
        private string _description;
        private int _interval;
        private int _duration;
        private double _cost;
        private int _intervalType;
        private string _documentPrefix;

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

        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                OnPropertyChanged();
            }
        }

        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        public double Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged();
            }
        }

        public int IntervalType
        {
            get { return _intervalType; }
            set
            {
                _intervalType = value;
                OnPropertyChanged();
            }
        }

        public string DocumentPrefix
        {
            get { return _documentPrefix; }
            set
            {
                _documentPrefix = value;
                OnPropertyChanged();
            }
        }
    }
}
