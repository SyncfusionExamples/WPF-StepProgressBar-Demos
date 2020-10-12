using Syncfusion.UI.Xaml.ProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemTemplateSelectorSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class StepViewItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            StepViewItem stepViewItem = item as StepViewItem;
            if (stepViewItem != null)
            {
                if (stepViewItem.Status == StepStatus.Indeterminate)
                {
                    return (item as StepViewItem).FindResource("IndeterminateContentTemplate") as DataTemplate;
                }
                else if (stepViewItem.Status == StepStatus.Active)
                {
                    return (item as StepViewItem).FindResource("ActiveContentTemplate") as DataTemplate;
                }
                else
                    return (item as StepViewItem).FindResource("InactiveContentTemplate") as DataTemplate;
            }
            return null;
        }
    }
}
