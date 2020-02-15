using System;
using System.Windows.Input;

namespace SalesManagment
{
    public class CategoryRowViewerViewModel : BaseRowViewerViewModel
    {
        #region Public Events

        /// <summary>
        /// Fires when editing action is canceled
        /// </summary>
        public event Action<BaseRowViewerViewModel> Cancel;

        #endregion

        #region Private Members

        /// <summary>
        /// Determine whether the row viewer data can be edited or not
        /// </summary>
        private bool mIsEditable = false;

        #endregion

        #region Public Properties

        #region Category Data

        /// <summary>
        /// The ID of the category
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Name of the category
        /// </summary>
        public string Name { get; set; }

        #endregion

        /// <summary>
        /// Determine whether the row viewer data can be edited or not
        /// </summary>
        public bool IsEditable
        {
            get => mIsEditable;
            set
            {
                mIsEditable = value;
                if (mIsEditable == true)
                    EditedName = Name;
            }
        }

        /// <summary>
        /// The Text printed in Name Textbox
        /// </summary>
        public string EditedName { get; set; }

        #region Public Commands

        /// <summary>
        /// The command used to cancel editing operation
        /// </summary>
        public ICommand CancelCommand { get; set; }

        public override ICommand DeleteCommand { get; set; }
        public override ICommand EditCommand { get; set; }
        public override ICommand PrintCommand { get; set; }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initialize new instance from <see cref="CategoryRowViewerViewModel"/> class
        /// </summary>
        public CategoryRowViewerViewModel()
        {
            CancelCommand = new RelayCommand(() => CancelEditing());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Notifing the list which containing this item that editing action was canceled
        /// </summary>
        private void CancelEditing()
        {
            Cancel?.Invoke(this);
        }

        #endregion
    }
}
