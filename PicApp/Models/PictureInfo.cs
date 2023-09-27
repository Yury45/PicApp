using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PicApp.Models
{
    public class PictureInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _fileName;
        private string _picturePath;
        private DateTime _creationDate;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string PicturePath
        {
            get { return _picturePath; }
            set
            {
                if (_picturePath != value)
                {
                    _picturePath = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                if (_creationDate != value)
                {
                    _creationDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public PictureInfo(string fileName, string picturePath, DateTime _creationDate)
        {
            _fileName = fileName;
            _picturePath = picturePath;
            this._creationDate = _creationDate;
        }
    }
}
