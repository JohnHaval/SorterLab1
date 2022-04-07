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
using SorterLib;
using AllXFiller;
using DataGridFiller;

namespace SorterLab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] _arr;
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            int a, b;
            try
            {
                _arr = new int[Convert.ToInt32(MasLength.Text)];
            }
            catch
            {
                MessageBox.Show("Некорректно введен размер массива!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MasLength.Focus();
                return;
            }
            try
            {
                a = Convert.ToInt32(FirstVal.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно введено начальное значение диапазона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                FirstVal.Focus();
                return;
            }
            try
            {
                b = Convert.ToInt32(SecondVal.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно введен конечное значение диапазона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                SecondVal.Focus();
                return;
            }
            try
            {
                OwnTable.ItemsSource = VisualArray.ToDataTable(_arr = XFiller.XFillRnd(a, b, _arr.Length)).DefaultView;
                ResultOfEven.Clear();
            }
            catch
            {
                MessageBox.Show("Некорректно задан размер массива!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MasLength.Focus();
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OwnTable.ItemsSource = VisualArray.ToDataTable(Sorter.SortOnUp(_arr)).DefaultView;
                ResultOfEven.Clear();
            }
            catch
            {
                MessageBox.Show("Для сортировки требуется массив со ЗНАЧЕНИЯМИ!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                MasLength.Focus();
            }
        }

        private void OwnTable_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int iColumn = e.Column.DisplayIndex;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                try
                {
                    _arr[iColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
                    ResultOfEven.Clear();
                }
                catch
                {                    
                }
            }
        }

        private void ProfEven_Click(object sender, RoutedEventArgs e)
        {
            int x, y;
            try
            {
                x = _arr[_arr.Length - 1];
                y = _arr[0];
            }
            catch
            {
                MessageBox.Show("Необходим заполненный массив", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                MasLength.Focus();
                return;
            }
            ResultOfEven.Text = MainWindow.CheckEven(x, y);     
        }
        public static string CheckEven(int x, int y)
        {
            do
            {
                x--;
                y++;
            }
            while (x > y);
            if (x == y)
            {
                return "Чет";
            }
            else return "Нечет";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            OwnTable.ItemsSource = _arr = null;
            ResultOfEven.Clear();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа имеет следующие особенности:\n" +
                "1) Максимальный размер для поля - 6\n" +
                "2) Заполнение таблицы происходит посредством заполнения соответствующих полей данными и нажатием \"Заполнить\"\n" +
                "3) Доступно использование AccessKeys(Alt+Подчеркнутая буква в меню)\n" +
                "", "Справка", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Лопаткин Сергей ИСП-31 (GitHub.Name= \"Hapro Bishop\")","О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
