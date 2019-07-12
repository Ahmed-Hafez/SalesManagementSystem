using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace SalesManagment
{
    public class MenuItemViewModel
    {
        #region Public Properties

        /// <summary>
        /// The header of the menu item
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// The color of for ground brush
        /// </summary>
        public Brush ForgroundBrush { get; set; } = Brushes.Black;

        /// <summary>
        /// The menu items falling under this menu item
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        /// <summary>
        /// The command of this menu item
        /// </summary>
        public ICommand Command { get; set; }

        #endregion
    }
}
