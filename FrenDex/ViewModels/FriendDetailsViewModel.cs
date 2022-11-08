using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrenDex.Models;
using FrenDex.Services;
using FrenDex.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.ViewModels
{
    [QueryProperty(nameof(Friend), "Friend")]
    public partial class FriendDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        public Friend friend = new();

        private readonly IFriendService _friendRepository;

        public FriendDetailsViewModel(IFriendService friendRepository)
        {
            _friendRepository = friendRepository;
        }

        [RelayCommand]
        public async void OnTapDeleteAsync(Friend friend)
        {
            if (friend is null)
                return;

            var confirmDelete = await Shell.Current.DisplayAlert($"Are you sure to delete {friend.Nickname}?", $"{friend.Nickname} will be deleted forever.", "Yes", "No");

            if (confirmDelete)
            {
                try
                {
                    var response = await _friendRepository.DeleteAsync(friend);

                    if (response == 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await Shell.Current.DisplayAlert("Oops!", "Unable to delete the friend.", "OK");
                }

                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void OnTapEditAsync(Friend friend)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add(nameof(Friend), friend);
            await Shell.Current.GoToAsync(nameof(AddUpdateFriendPage), navParam);
        }

    }
}
