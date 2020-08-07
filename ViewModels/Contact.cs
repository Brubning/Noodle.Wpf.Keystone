
using System;

namespace Noodle.Wpf.Keystone.ViewModels
{
    public class Contact : ViewModelBase
    {
        private int _id;
        private string _jobTitle;
        private string _name;
        private string _address1;
        private string _address2;
        private string _address3;
        private string _address4;
        private string _postcode;
        private string _email1;
        private string _email2;
        private string _telephone1;
        private string _ext1;
        private string _telephone2;
        private string _ext2;
        private string _notes;
        private int? _parentId;
        private string _description;
        private string _companyRegistration;
        private string _url;
        private string _title;
        private bool _isPrimary;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Address1
        {
            get { return _address1; }
            set
            {
                _address1 = value;
                OnPropertyChanged();
            }
        }

        public string Address2
        {
            get { return _address2; }
            set
            {
                _address2 = value;
                OnPropertyChanged();
            }
        }

        public string Address3
        {
            get { return _address3; }
            set
            {
                _address3 = value;
                OnPropertyChanged();
            }
        }

        public string Address4
        {
            get { return _address4; }
            set
            {
                _address4 = value;
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

        public string Email1
        {
            get { return _email1; }
            set
            {
                _email1 = value;
                OnPropertyChanged();
            }
        }

        public string Email2
        {
            get { return _email2; }
            set
            {
                _email2 = value;
                OnPropertyChanged();
            }
        }

        public string Telephone1
        {
            get { return _telephone1; }
            set
            {
                _telephone1 = value;
                OnPropertyChanged();
            }
        }

        public string Ext1
        {
            get { return _ext1; }
            set
            {
                _ext1 = value;
                OnPropertyChanged();
            }
        }

        public string Telephone2
        {
            get { return _telephone2; }
            set
            {
                _telephone2 = value;
                OnPropertyChanged();
            }
        }

        public string Ext2
        {
            get { return _ext2; }
            set
            {
                _ext2 = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
        
        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                _parentId = value;
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

        public string CompanyRegistration
        {
            get { return _companyRegistration; }
            set
            {
                _companyRegistration = value;
                OnPropertyChanged();
            }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool IsPrimary
        {
            get { return _isPrimary; }
            set
            {
                _isPrimary = value;
                OnPropertyChanged();
            }
        }
    }
}
