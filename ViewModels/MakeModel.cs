namespace Noodle.Wpf.Keystone.ViewModels
{
    public class MakeModel : ViewModelBase
    {
        private int _id;
        private int _equipmentTypeId;
        private string _make;
        private string _model;
        private string _reference;
        private string _subModel;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public int EquipmentTypeId
        {
            get { return _equipmentTypeId; }
            set
            {
                _equipmentTypeId = value;
                OnPropertyChanged();
            }
        }

        public string Make
        {
            get { return _make; }
            set
            {
                _make = value;
                OnPropertyChanged();
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public string Reference
        {
            get { return _reference; }
            set
            {
                _reference = value;
                OnPropertyChanged();
            }
        }

        public string SubModel
        {
            get { return _subModel; }
            set
            {
                _subModel = value;
                OnPropertyChanged();
            }
        }
    }
}
