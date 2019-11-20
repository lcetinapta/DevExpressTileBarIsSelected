using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication3.Common
{
    public class NavigationMenuModel
    {
        public virtual bool HasChildren => Children.Any();
        public virtual bool IsSelected { get; set; }
        public virtual string MenuTitle { get; set; }
        public virtual NavigationMenuModel ParentNavigationItem { get; set; }

        public ObservableCollection<NavigationMenuModel> Children { get; set; } = new ObservableCollection<NavigationMenuModel>();
    }
}
