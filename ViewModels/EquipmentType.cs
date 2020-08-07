
namespace Noodle.Wpf.Keystone.ViewModels
{
    public class EquipmentType : ViewModelBase
    {
        private int _id;
        private int? _competencyId;
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

        public int? CompetencyId
        {
            get { return _competencyId; }
            set
            {
                _competencyId = value;
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
