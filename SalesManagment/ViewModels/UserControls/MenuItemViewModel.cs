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
        /// The color of foreground brush in ARGB fromat in (hex)
        /// For example (FFFF0000) represents Red
        /// </summary>
        public string ForgroundBrushARGB { get; set; } = "FF000000";

        /// <summary>
        /// The menu items falling under the menu item
        /// </summary>
        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }

        /// <summary>
        /// The command used to add some action
        /// </summary>
        public ICommand Command { get; set; }

        /// <summary>
        /// The command parameter
        /// </summary>
        public object CommandParameter { get; set; }

        #endregion
    }
}
