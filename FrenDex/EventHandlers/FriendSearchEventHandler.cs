using FrenDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.EventHandlers
{
    public class FriendSearchEventHandler : SearchHandler
    {
        public IList<Friend> Friends { get; set; }
        public string NavigationRoute { get; set; }
        public Type NavigationType { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
                ItemsSource = null;

            else
                ItemsSource = Friends.Where(friend => friend.FullName.ToLower().Contains(newValue.ToLower()) || friend.Nickname.ToLower().Contains(newValue.ToLower())).ToList();
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            var navParam = new Dictionary<string, object>();
            navParam.Add(nameof(Friend), item);

            if(!string.IsNullOrEmpty(NavigationRoute))
                await Shell.Current.GoToAsync(NavigationRoute, navParam);
        }
    }
}
