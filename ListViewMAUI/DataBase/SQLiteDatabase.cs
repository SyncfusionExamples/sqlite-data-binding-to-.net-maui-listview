using SQLite;

namespace ListViewMAUI
{
    public class SQLiteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SQLiteDatabase()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<Contact>();
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _database.Table<Contact>().ToListAsync();
        }

        public async Task<Contact> GetContactAsync(Contact item)
        {
            return await _database.Table<Contact>().Where(i => i.ID == item.ID).FirstOrDefaultAsync();
        }
        
        public async Task<int> AddContactAsync(Contact item)
        {
            return await  _database.InsertAsync(item);
        }

        public Task<int> DeleteContactAsync(Contact item)
        {            
            return _database.DeleteAsync(item);
        }

        public Task<int> UpdateContactAsync(Contact item)
        {
            if (item.ID != 0)
                return _database.UpdateAsync(item);
            else
                return _database.InsertAsync(item);
        }
    }
}
