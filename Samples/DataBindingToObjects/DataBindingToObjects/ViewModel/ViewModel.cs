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

namespace DataBindingToObjects
{
    /// <summary>
    /// Represents the view model class.
    /// </summary>
    public class StepViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Represents the step view items.
        /// </summary>
        private ObservableCollection<StepItem> m_stepViewItems;

        /// <summary>
        /// Represents the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the step view items.
        /// </summary>
        public ObservableCollection<StepItem> StepViewItems
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
        /// Initialize the instance of <see cref="StepViewModel"/> class.
        /// </summary>
        public StepViewModel()
        {
            StepViewItems = new ObservableCollection<StepItem>();
            PopulateData();
        }

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {
            //Adding the stepview items into the collection
            StepItem orderedStepViewItem = new StepItem()
            {
                ModelText = "Ordered",
                TitleSpace = 8
            };

            StepItem shippedStepViewItem = new StepItem()
            {
                ModelText = "Shipped",
                TitleSpace = 8
            };

            StepItem packedStepViewItem = new StepItem()
            {
                ModelText = "Packed",
                TitleSpace = 8
            };

            StepItem deliveredStepViewItem = new StepItem()
            {
                ModelText = "Delivered",
                TitleSpace = 8
            };

            StepViewItems.Add(orderedStepViewItem);
            StepViewItems.Add(shippedStepViewItem);
            StepViewItems.Add(packedStepViewItem);
            StepViewItems.Add(deliveredStepViewItem);
        }
    }
}