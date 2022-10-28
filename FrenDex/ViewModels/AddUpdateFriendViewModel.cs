using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FrenDex.Models;
using FrenDex.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.ViewModels
{
    [QueryProperty(nameof(Friend), "Friend")]
    public partial class AddUpdateFriendViewModel : ObservableObject
    {
        [ObservableProperty]
        public Friend friend = new();

        private readonly IFriendRepository _friendRepository;

        public AddUpdateFriendViewModel(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        [RelayCommand]
        public async void AddUpdateFriendAsync()
        {
            int response = -1;

            try
            {
                if (Friend.Id > 0)
                    response = await _friendRepository.UpdateAsync(Friend);

                else
                {
                    response = await _friendRepository.AddAsync(new Friend
                    {
                        Nickname = Friend.Nickname,
                        FirstName = Friend.FirstName,
                        LastName = Friend.LastName,
                        Likes = Friend.Likes,
                        Dislikes = Friend.Dislikes,
                        Favorites = Friend.Favorites,
                        Hates = Friend.Hates,
                        Allergies = Friend.Allergies
                    });
                }

                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Success!", "Successfully saved.", "OK");
                    await Shell.Current.GoToAsync("../..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Oops!", "Something went wrong while saving.", "OK");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Oops!", "Error performing action.", "OK");
            }

            
        }
    }
}
