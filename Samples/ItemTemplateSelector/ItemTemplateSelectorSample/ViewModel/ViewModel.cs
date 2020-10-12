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
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> m_stepViewItems;
        public event PropertyChangedEventHandler PropertyChanged;
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

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public ViewModel()
        {
            StepViewItems = new ObservableCollection<string>();
            PopulateData();
        }

        private void PopulateData()
        {           
            StepViewItems.Add("Ordered");
            StepViewItems.Add("Shipped");
            StepViewItems.Add("Packed");
            StepViewItems.Add("Delivered");
        }
    }
}