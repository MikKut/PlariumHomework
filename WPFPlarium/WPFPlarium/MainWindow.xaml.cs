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

namespace WPFPlarium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        
        private void TurnOnTask1()
        {
            InputTextForTasks.Visibility = Visibility.Visible;
            RectangleTask1.Visibility = Visibility.Visible;
            FieldTask1.Visibility = Visibility.Visible;
            CalculateTask1Button.Visibility = Visibility.Visible;
            Conditions.Visibility = Visibility.Visible;
            TurnOffStartButtonOfTask1();
        }
        private void TurnOffStartButtonOfTask1()
        {
            Task_1_1.Visibility = Visibility.Collapsed;
            ToolBar.Visibility = Visibility.Collapsed;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateTask1(object sender, RoutedEventArgs e)
        {
            int? result;
            result = SyntaxHomework.CountSumOfNumbersDividedByThreeWithoutReminder(FieldTask1.Text);
            myPopupText.Text = $"The sum of all the numbers divided by three without reminder is {result}";
        }


        private void DoTask1(object sender, RoutedEventArgs e)
        {
            TurnOnTask1();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CalculateTask1Button_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
