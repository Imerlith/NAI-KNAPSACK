using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace NAI_PROJECT3
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
        }
        public ResultWindow(ICollection<Item> items, double timer, string name)
        {
            InitializeComponent();
            TitleLabel.Content = name;
            var allValue = 0d;
            var allWeigth = 0d;
            var values = "";
            var weights = "";
            foreach(var item in items)
            {
                values += item.Value + " ";
                weights += item.Weigth + " ";
                allValue += item.Value;
                allWeigth += item.Weigth;
            }
            TimeLabel.Content = timer;
            ValuesLabel.Content = values;
            WeigthLabel.Content = weights;
            FullValueLabel.Content = allValue;
            FullWeigthLabel.Content = allWeigth;

        }
    }
}
