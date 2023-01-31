using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ListViewMAUI
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Contacts> contactsInfo;
        private Contacts selectedContact;

        #endregion

        #region Properties
        public Contacts SelectedItem
        {
            get 
            {
                return selectedContact;
            }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public ObservableCollection<Contacts> ContactsInfo
        {
            get
            {
                return contactsInfo;
            }
            set
            {
                contactsInfo = value;
                OnPropertyChanged("ContactsInfo");
            }
        }

        public Command CreateContactsCommand { get; set; }
        public Command<object> EditContactsCommand { get; set; }
        public Command SaveItemCommand { get; set; }
        public Command DeleteItemCommand { get; set; }
        public Command AddItemCommand { get; set; }

        #endregion

        #region Constructor
        public ContactsViewModel()
        {
            GenerateContacts();
            CreateContactsCommand = new Command(OnCreateContacts);
            EditContactsCommand = new Command<object>(OnEditContacts);
            SaveItemCommand = new Command(OnSaveItem);
            DeleteItemCommand = new Command(OnDeleteItem);
            AddItemCommand = new Command(OnAddNewItem);
        }
        #endregion

        #region Methods

        private void GenerateContacts()
        {
            ContactsInfo = new ObservableCollection<Contacts>();
            ContactsInfo = new ContactsInfoRepository().GetContactDetails(20);

            foreach (Contacts contact in ContactsInfo)
                App.Database.AddContactAsync(contact);
        }

        private async void OnAddNewItem()
        {
            await App.Database.AddContactAsync(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnDeleteItem()
        {
            await App.Database.DeleteContactAsync(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnSaveItem()
        {
            await App.Database.UpdateContactAsync(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void OnEditContacts(object obj)
        {
            SelectedItem = (obj as Syncfusion.Maui.ListView.ItemTappedEventArgs).DataItem as Contacts;
            var editPage = new Views.EditPage();
            editPage.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }

        private void OnCreateContacts()
        {
            SelectedItem = new Contacts() { ContactName = "", ContactNumber = "" };
            var editPage = new Views.EditPage();
            editPage.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }
        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
