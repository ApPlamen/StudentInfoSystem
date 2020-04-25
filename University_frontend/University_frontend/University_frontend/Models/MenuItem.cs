namespace University_frontend.Models
{
    using System;
    using University_frontend.Enums;
    using Xamarin.Forms;

    public class MainMenuItem: BindableObject
    {
        private string menuText;
        private MenuItemType menuItemType;
        private Type viewModelToLoad;

        public MenuItemType MenuItemType
        {
            get
            {
                return menuItemType;
            }
            set
            {
                menuItemType = value;
                OnPropertyChanged();
            }
        }

        public string MenuText
        {
            get
            {
                return menuText;
            }
            set
            {
                menuText = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelToLoad
        {
            get
            {
                return viewModelToLoad;
            }
            set
            {
                viewModelToLoad = value;
                OnPropertyChanged();
            }
        }
    }
}
