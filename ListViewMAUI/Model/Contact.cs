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
    #region Contact
    public class Contact : INotifyPropertyChanged
    {
        #region Fields

        public int id;
        private string name;
        private string number;
        private string image;

        #endregion

        [PrimaryKey, AutoIncrement]
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Number
        {
            get { return number; }
            set
            {
                this.number = value;
                RaisePropertyChanged("Number");
            }
        }

        [Display(AutoGenerateField = false)]
        public string Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
                this.RaisePropertyChanged("Image");
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
