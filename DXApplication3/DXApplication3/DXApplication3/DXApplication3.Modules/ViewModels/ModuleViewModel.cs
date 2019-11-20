using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DXApplication3.Common;

namespace DXApplication3.Modules.ViewModels
{
    public class ModuleViewModel : IDocumentModule, ISupportState<ModuleViewModel.Info>
    {
        protected ModuleViewModel()
        {
        }

        public virtual string Content { get; set; }

        public virtual ObservableCollection<NavigationMenuModel> MenuItems { get; set; } =
            new ObservableCollection<NavigationMenuModel>();

        public virtual NavigationMenuModel SelectedMenuItem { get; set; }
        public virtual string Caption { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual void OnSelectedMenuItemChanged(NavigationMenuModel oldValue)
        {
            ProcessIsSelected();
        }

        public static ModuleViewModel Create(string caption, string content, NavigationService navigationService)
        {
            return ViewModelSource.Create(() => new ModuleViewModel
            {
                Caption = caption,
                Content = content,
                MenuItems = new ObservableCollection<NavigationMenuModel>(navigationService.GeDummyMenu())
            });
        }

        private void ProcessIsSelected()
        {
            foreach (var moduleView in MenuItems)
            {
                if (moduleView == SelectedMenuItem)
                {
                    moduleView.IsSelected = true;
                }
                else
                {
                    moduleView.IsSelected = false;
                }

                foreach (var child in moduleView.Children)
                {
                    if (child == SelectedMenuItem)
                    {
                        child.IsSelected = true;
                        moduleView.IsSelected = true;
                    }
                    else
                    {
                        child.IsSelected = false;
                    }
                }
            }
        }

        #region Serialization

        [Serializable]
        public class Info
        {
            public string Content { get; set; }
            public string Caption { get; set; }
        }

        Info ISupportState<Info>.SaveState()
        {
            return new Info
            {
                Content = Content,
                Caption = Caption
            };
        }

        void ISupportState<Info>.RestoreState(Info state)
        {
            Content = state.Content;
            Caption = state.Caption;
        }

        #endregion
    }
}