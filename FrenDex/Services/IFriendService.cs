using FrenDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.Services
{
    public interface IFriendService
    {
        Task<int> AddAsync(Friend friend);
        Task<int> DeleteAsync(Friend friend);
        Task<List<Friend>> ListAsync();
        Task<int> UpdateAsync(Friend friend);
    }
}
