using SQLite;

namespace ListViewMAUI
{
    public class SQLiteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SQLiteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return _database.Table<Contact>().ToListAsync();
        }

        public Task<int> AddContactAsync(Contact item)
        {
            return _database.InsertAsync(item);
        }

        public Task<int> DeleteContactAsync(Contact item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<int> UpdateContactAsync(Contact item)
        {
            return _database.UpdateAsync(item);
        }
    }
}
