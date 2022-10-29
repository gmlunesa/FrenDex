using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrenDex.Models;
using FrenDex.Repositories;
using FrenDex.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.ViewModels
{
    public partial class FriendListViewModel : ObservableObject
    {
        public ObservableCollection<Friend> Friends { get; set; } = new();
        public static List<Friend> FriendsSearchable { get; set; } = new();

        private readonly IFriendRepository _friendRepository;

        public FriendListViewModel(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        [RelayCommand]
        public async void GetFriendListAsync()
        {
            Friends.Clear();

            try
            {
                // Retrieve list from DB
                var friendsList = await _friendRepository.ListAsync();
                if (friendsList is null)
                    return;

                // Order alphabetically
                friendsList.OrderBy(friend => friend.FullName).ToList();

                // Add to our ViewModel
                foreach (var friend in friendsList)
                    Friends.Add(friend);

                // Update our searchable list
                FriendsSearchable.Clear();
                FriendsSearchable.AddRange(friendsList);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Oops!", "Unable to load the friends list.", "OK");
            }
        }

        #region Navigation Commands
        [RelayCommand]
        public async void GoToAddUpdateFriendAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddUpdateFriendPage));
        }

        [RelayCommand]
        public async Task GoToDetailsAsync(Friend friend)
        {
            if (friend is null)
                return;

            var navDict = new Dictionary<string, object>();
            navDict.Add(nameof(Friend), friend);

            await Shell.Current.GoToAsync(nameof(FriendDetailsPage), navDict);
        }

        #endregion
    }
}
