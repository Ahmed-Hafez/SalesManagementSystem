using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagment
{
    /// <summary>
    /// Interaction logic for ButtonList.xaml
    /// </summary>
    public partial class ButtonList : UserControl, INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// Initailizes a new instance from the <see cref="ButtonList"/> user control
        /// </summary>
        public ButtonList()
        {
            InitializeComponent();
        }

        #endregion

        #region Public events

        /// <summary>
        /// Fires when a property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Private members

        /// <summary>
        /// Inform if the list is opened or not
        /// </summary>
        private bool IsOpen;

        #endregion

        #region Public properties

        /// <summary>
        /// The Height which is used to animate the ButtonList user control
        /// in opening and closing
        /// </summary>
        public double AnimatedHeight { get; set; } = 53;

        #endregion

        #region Dependency properties

        #region Public properties of dependency properties


        /// <summary>
        /// The title which will be put on the main button of the list
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        /// <summary>
        /// The number of buttons on the <see cref="ButtonList"/> user control
        /// </summary>
        public int NumberOfButtons
        {
            get { return (int)GetValue(NumberOfButtonsProperty); }
            set
            {
                SetValue(NumberOfButtonsProperty, value);
                OpenAction();
            }
        }

        /// <summary>
        /// The commands for the generated buttons
        /// </summary>
        public RelayCommand[] ButtonsCommands
        {
            get { return (RelayCommand[])GetValue(ButtonsCommandsProperty); }
            set
            {
                SetValue(ButtonsCommandsProperty, value);
                OpenAction();
            }
        }

        /// <summary>
        /// The names of buttons which will be generated
        /// </summary>
        public string[] ButtonsNames
        {
            get { return (string[])GetValue(ButtonsNamesProperty); }
            set
            {
                SetValue(ButtonsNamesProperty, value);
                OpenAction();
            }
        }

        #endregion

        #region The actual properties

        /// <summary>
        /// The number of buttons on the <see cref="ButtonList"/> user control
        /// </summary>
        public static readonly DependencyProperty NumberOfButtonsProperty =
            DependencyProperty.Register("NumberOfButtons", typeof(int), typeof(ButtonList));

        /// <summary>
        /// The commands for the generated buttons
        /// </summary>
        public static readonly DependencyProperty ButtonsCommandsProperty =
            DependencyProperty.Register("ButtonsCommands", typeof(RelayCommand[]), typeof(ButtonList));

        /// <summary>
        /// The names of buttons which will be generated
        /// </summary>
        public static readonly DependencyProperty ButtonsNamesProperty =
            DependencyProperty.Register("ButtonsNames", typeof(string[]), typeof(ButtonList));

        /// <summary>
        /// The title which will be put on the main button of the list
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ButtonList));

        #endregion

        #endregion

        #region Routed events

        // TODO Create a BaseRoutedEvent and comment those routed events

        /// <summary>
        /// The routed event which is used to open the <see cref="ButtonList"/>
        /// </summary>
        public event RoutedEventHandler Open
        {
            add
            {
                this.AddHandler(OpenEvent, value);
            }

            remove
            {
                this.RemoveHandler(OpenEvent, value);
            }
        }

        /// <summary>
        /// The routed event which is used to close the <see cref="ButtonList"/>
        /// </summary>
        public event RoutedEventHandler Close
        {
            add
            {
                this.AddHandler(CloseEvent, value);
            }

            remove
            {
                this.RemoveHandler(CloseEvent, value);
            }
        }

        /// <summary>
        /// The routed event which is used to open the <see cref="ButtonList"/>
        /// </summary>
        public static readonly RoutedEvent OpenEvent =
            EventManager.RegisterRoutedEvent("Open", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonList));

        /// <summary>
        /// The routed event which is used to close the <see cref="ButtonList"/>
        /// </summary>
        public static readonly RoutedEvent CloseEvent =
            EventManager.RegisterRoutedEvent("Close", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonList));

        // TODO ---------------------------------------------------------

        #endregion

        #region Methods

        /// <summary>
        /// Provides an action when opening the <see cref="ButtonList"/> user control
        /// </summary>
        private void OpenAction()
        {
            AnimatedHeight = 53 + NumberOfButtons * 51.5;

            PropertyChanged(this, new PropertyChangedEventArgs(nameof(AnimatedHeight)));

            ButtonListContent.Children.Clear();

            for (int i = 0; i < NumberOfButtons; i++)
            {
                var button = new Button();
                button.Style = FindResource("ListButton") as Style;
                if (ButtonsCommands != null)
                {
                    if (i < ButtonsCommands.Length)
                        button.Command = ButtonsCommands[i];
                }
                if(ButtonsNames != null)
                {
                    if (i < ButtonsNames.Length)
                        button.Content = ButtonsNames[i];
                }
                ButtonListContent.Children.Add(button);
            }
        }

        /// <summary>
        /// Handles the MouseDown event
        /// </summary>
        private void MainButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // If the list is opend, Close it ...
            if (IsOpen)
            {
                IsOpen = false;
                RaiseEvent(new RoutedEventArgs(CloseEvent));
                AnimatedHeight = 53; // The Height after closing
            }
            else // Otherwise, Open it
            {
                IsOpen = true;
                OpenAction();
                RaiseEvent(new RoutedEventArgs(OpenEvent));
            }
        }
        
        #endregion
    }
}
