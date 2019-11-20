using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DXApplication3.Common;

namespace DXApplication3.Modules
{
    public class NavigationService
    {
        public IEnumerable<NavigationMenuModel> GeDummyMenu()
        {
            var result = new List<NavigationMenuModel>();
            for (var i = 1; i < 5; i++)
            {
                var menuItem = ViewModelSource.Create<NavigationMenuModel>();
                menuItem.MenuTitle = $"RootMenu-{i}";
                menuItem.ParentNavigationItem = null;
                menuItem.IsSelected = false;

                if (i % 2 == 0)
                {
                    menuItem.Children = new ObservableCollection<NavigationMenuModel>(Enumerable.Range(i, 5).Select(x =>
                    {
                        var menuItemChild = ViewModelSource.Create<NavigationMenuModel>();
                        menuItemChild.MenuTitle = $"SubMenuMenu-{x}";
                        menuItemChild.ParentNavigationItem = menuItem;
                        menuItemChild.IsSelected = false;
                        return menuItemChild;
                    }).ToList());
                }

                result.Add(menuItem);
            }

            return result;
        }
    }
}