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

using CustomControl;

namespace CS5MachineMath
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

        private void ShowSize(object sender, RoutedEventArgs e)
        {
            ImprovedButton btn = sender as ImprovedButton;
            Type t = Type.GetType($"System.{btn.TypeString}");            
            var someVar = Activator.CreateInstance(t);
            string sizeInBytes = System.Runtime.InteropServices.Marshal.SizeOf(someVar).ToString();

            string maxVal = t.GetField("MaxValue").GetValue(someVar).ToString();
            string minVal = t.GetField("MinValue").GetValue(someVar).ToString();

            MessageBox.Show
                (
                $"Data type \t- \t{t.Name} \n" +
                $"Size in bytes \t- \t{sizeInBytes} \n" +
                $"Min value \t- \t{minVal} \n" +
                $"Max value \t- \t{maxVal}"
                );
        }
    }
}
