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
using static _9._11.Model;
using static _9._11.ViewModel;

namespace _9._11
{
    public partial class MainWindow : Window
    {
        private PersonViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new PersonViewModel();
            this.DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddPerson(new Person { FullName = FullNameTextBox.Text, Address = AddressTextBox.Text, PhoneNumber = PhoneNumberTextBox.Text });
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SaveToFile("people.txt");
        }
    }
}