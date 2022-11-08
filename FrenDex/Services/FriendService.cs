using FrenDex.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.Services
{
    public class FriendService : IFriendService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDbAsync()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FriendDB.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Friend>();
            }
        }

        public async Task<int> AddAsync(Friend friend)
        {
            await SetUpDbAsync();
            return await _dbConnection.InsertAsync(friend);
        }

        public async Task<int> DeleteAsync(Friend friend)
        {
            await SetUpDbAsync();
            return await _dbConnection.DeleteAsync(friend);
        }

        public async Task<List<Friend>> ListAsync()
        {
            await SetUpDbAsync();
            return await _dbConnection.Table<Friend>().ToListAsync();
        }

        public async Task<int> UpdateAsync(Friend friend)
        {
            await SetUpDbAsync();
            return await _dbConnection.UpdateAsync(friend);
        }
    }
}
