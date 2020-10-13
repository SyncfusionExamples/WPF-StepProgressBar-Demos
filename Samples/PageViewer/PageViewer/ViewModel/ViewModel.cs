namespace PageViewer
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Represents the view model class.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private ICommand nextCommand;
        private ICommand previousCommand;
        private int selectedIndex;
        private TimeSpan animationDuration = new TimeSpan(0, 0, 0, 0, 500);
        private ObservableCollection<string> stepViewItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.StepViewItems = new ObservableCollection<string>();
            this.PopulateData();
        }

        /// <summary>
        /// Represents the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the selected index for step progress bar.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                this.selectedIndex = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.SelectedIndex)));
            }
        }

        /// <summary>
        /// Gets or sets the animation duration for step progress bar.
        /// </summary>
        public TimeSpan AnimationDuration
        {
            get
            {
                return this.animationDuration;
            }

            set
            {
                this.animationDuration = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.AnimationDuration)));
            }
        }

        /// <summary>
        /// Gets or sets the step view collections.
        /// </summary>
        public ObservableCollection<string> StepViewItems
        {
            get
            {
                return this.stepViewItems;
            }

            set
            {
                this.stepViewItems = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(this.StepViewItems)));
            }
        }

        /// <summary>
        ///  Gets the command for go back page .
        /// </summary>
        public ICommand PreviousCommand
        {
            get
            {
                return this.previousCommand ?? (this.previousCommand = new CommandHandler(param => this.ExecutePreviousForm(param), this.CanExecute()));
            }
        }

        /// <summary>
        /// Gets the command for go forward page.
        /// </summary>
        public ICommand NextCommand
        {
            get
            {
                return this.nextCommand ?? (this.nextCommand = new CommandHandler(param => this.ExecuteCurrentForm(param), this.CanExecute()));
            }
        }

        /// <summary>
        /// Represents the property changed.
        /// </summary>
        /// <param name="e">event args.</param>
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, e);
        }

        private void PopulateData()
        {
            this.StepViewItems.Add("StudentInfo");
            this.StepViewItems.Add("AcademicInfo");
            this.StepViewItems.Add("PaymentInfo");
        }

        private void ExecutePreviousForm(object param)
        {
            this.SelectedIndex--;
            var values = (object[])param;
            Frame frame = (Frame)values[0];
            Button prevButton = (Button)values[1];
            Button nextButton = (Button)values[2];

            // Hides the prev button when it is frist page.
            this.ToggleButtonVisibility(nextButton, prevButton);

            if (frame.NavigationService.CanGoBack)
            {
                frame.NavigationService.GoBack();
            }
        }

        private void ExecuteCurrentForm(object param)
        {
            var values = (object[])param;
            Frame frame = (Frame)values[0];
            Button prevButton = (Button)values[1];
            Button nextButton = (Button)values[2];

            // if the selected index is 2 and calling next button which redirects to first page
            if (this.selectedIndex == 2)
            {
                if (frame.NavigationService.CanGoBack)
                {
                    frame.GoBack();
                }

                if (frame.NavigationService.CanGoBack)
                {
                    frame.GoBack();
                }

                this.SelectedIndex = 0;
                nextButton.Content = "Next";
                prevButton.Visibility = Visibility.Hidden;
                nextButton.Margin = new Thickness(-100, 20, 0, 0);
            }
            else
            {
                this.SelectedIndex++;
            }

            this.ToggleButtonVisibility(nextButton, prevButton);

            if (frame.NavigationService.CanGoForward)
            {
                frame.NavigationService.GoForward();
            }
            else
            {
                // Registering the pages in navigation service journal for the first time.
                if (this.SelectedIndex == 1)
                {
                    frame.NavigationService.Navigate(new Uri("Resources/AcademicInfo.xaml", UriKind.Relative));
                }
                else if (this.SelectedIndex == 2)
                {
                    frame.NavigationService.Navigate(new Uri("Resources/PaymentInfo.xaml", UriKind.Relative));
                }
            }
        }

        private void ToggleButtonVisibility(Button nextButton, Button prevButton)
        {
            if (this.SelectedIndex > 0)
            {
                nextButton.Margin = new Thickness(20, 20, 0, 0);
                prevButton.Visibility = Visibility.Visible;
            }
            else
            {
                prevButton.Visibility = Visibility.Hidden;
                nextButton.Margin = new Thickness(-100, 20, 0, 0);
            }

            if (this.SelectedIndex == 2)
            {
                nextButton.Content = "Pay Now";
            }
            else
            {
                nextButton.Content = "Next";
            }
        }

        private bool CanExecute()
        {
            return true;
        }
    }

    /// <summary>
    /// Represents the command handler class.
    /// </summary>
    public class CommandHandler : ICommand
    {
        private Action<object> action;
        private bool canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler"/> class.
        /// </summary>
        /// <param name="action">action.</param>
        /// <param name="canExecute">can execute.</param>
        public CommandHandler(Action<object> action, bool canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Can execute changed event handler.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Represents whether the command can execute.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        /// <returns>true/false.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">parameter.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}