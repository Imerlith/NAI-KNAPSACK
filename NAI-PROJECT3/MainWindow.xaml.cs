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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NAI_PROJECT3
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var items = new List<Item>
            {
                new Item{Value=20, Weigth= 5 },
                new Item{Value=40, Weigth= 3},
                new Item{Value=30, Weigth= 4 }
            }.ToArray();
            var knapsack = new Knapsack { Items = items, Capacity = 10 };
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            var weigths = WeigthsTxtBox.Text.Split(' ');
            var values = ValuesTxtBox.Text.Split(' ');
            var capacity = CapacityTxtBox.Text;
            var items = new List<Item>();
            if(weigths.Length == values.Length)
            {
                for (int i = 0; i < weigths.Length; i++)
                {
                    items.Add(new Item { Weigth = double.Parse( weigths[i]), Value = double.Parse( values[i] )});
                }
                var knapsack = new Knapsack { Items = items.ToArray(), Capacity = int.Parse(capacity) };
                var selected = MainGrid.Children.OfType<RadioButton>().ToList().Where(r => r.GroupName == "Algorithm" && r.IsChecked.Value).Single();

                switch (selected.Content)
                {
                    case "Brute Force":
                        var res = knapsack.FindWithBruteForce();
                        var resultWindow = new ResultWindow(res,knapsack.Timer,"Brute Force");
                        resultWindow.Show();
                        ; break;
                    case "Greedy":
                        var res2 = knapsack.FindWithGreedy();
                        var resultWindow2 = new ResultWindow(res2, knapsack.Timer, "Greedy");
                        resultWindow2.Show();
                        break;
                    default: MessageBox.Show("Cos");break;
                }
            }
            else
            {
                MessageBox.Show("Niepoprawne wartosci");
            }
            
        }
    }
}
