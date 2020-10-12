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
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StepItem> m_stepViewItems;
        public event PropertyChangedEventHandler PropertyChanged;
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

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public ViewModel()
        {
            StepViewItems = new ObservableCollection<StepItem>();
            PopulateData();
        }

        private void PopulateData()
        {
            //Adding the stepview items into the collection
            StepItem orderedStepViewItem = new StepItem()
            {
                ModelText = "Ordered",
                TitleSpace = new Thickness(0, 8, 0, 0)
            };

            StepItem shippedStepViewItem = new StepItem()
            {
                ModelText = "Shipped",
                TitleSpace = new Thickness(0, 8, 0, 0)
            };

            StepItem packedStepViewItem = new StepItem()
            {
                ModelText = "Packed",
                TitleSpace = new Thickness(0, 8, 0, 0)
            };

            StepItem deliveredStepViewItem = new StepItem()
            {
                ModelText = "Delivered",
                TitleSpace = new Thickness(0, 8, 0, 0)
            };

            StepViewItems.Add(orderedStepViewItem);
            StepViewItems.Add(shippedStepViewItem);
            StepViewItems.Add(packedStepViewItem);
            StepViewItems.Add(deliveredStepViewItem);
        }
    }
}