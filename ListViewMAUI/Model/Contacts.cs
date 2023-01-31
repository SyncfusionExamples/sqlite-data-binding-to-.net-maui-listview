using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMAUI
{
    #region Contacts
    public class Contacts : INotifyPropertyChanged
    {
        #region Fields

        public int id;
        private string contactName;
        private string contactNumber;
        private string contactImage;

        #endregion

        [PrimaryKey, AutoIncrement]
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }
        public string ContactName
        {
            get { return this.contactName; }
            set
            {
                this.contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                this.contactNumber = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        [Display(AutoGenerateField = false)]
        public string ContactImage
        {
            get { return this.contactImage; }
            set
            {
                this.contactImage = value;
                this.RaisePropertyChanged("ContactImage");
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
    #endregion
}
