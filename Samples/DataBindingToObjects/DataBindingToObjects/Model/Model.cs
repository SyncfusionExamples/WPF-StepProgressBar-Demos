using Syncfusion.UI.Xaml.ProgressBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataBindingToObjects
{
    /// <summary>
    /// Represents the model.
    /// </summary>
    public class StepItem 
    {
        /// <summary>
        /// Gets or sets the text for step view item.
        /// </summary>
        public string ModelText { get; set; } 
        
        /// <summary>
        /// Gets or sets the space between text and step view item.
        /// </summary>
        public double TitleSpace { get; set; }
    }
}
