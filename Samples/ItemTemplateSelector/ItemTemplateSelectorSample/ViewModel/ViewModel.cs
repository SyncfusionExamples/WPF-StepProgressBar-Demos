using Syncfusion.UI.Xaml.ProgressBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ItemTemplateSelectorSample
{
    /// <summary>
    /// Represents the view model class.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the step view items.
        /// </summary>
        private ObservableCollection<string> m_stepViewItems;

        /// <summary>
        /// Represents the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the step view items.
        /// </summary>
        public ObservableCollection<string> StepViewItems
        {
            get
            {
                return m_stepViewItems;
            }
            set
            {
                m_stepViewItems = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StepViewItems"));
            }
        }

        /// <summary>
        /// Trigress the on property changed event.
        /// </summary>
        /// <param name="e"></param>
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        /// <summary>
        /// Initialize the instance of <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            StepViewItems = new ObservableCollection<string>();
            PopulateData();
        }

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {           
            StepViewItems.Add("Ordered");
            StepViewItems.Add("Shipped");
            StepViewItems.Add("Packed");
            StepViewItems.Add("Delivered");
        }
    }
}