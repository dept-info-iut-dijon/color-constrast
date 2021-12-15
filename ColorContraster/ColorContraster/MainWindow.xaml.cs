using Egorozh.ColorPicker.Dialog;
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

namespace ColorContraster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic.Analyzer analyzer;
        private ViewModels.AnalyzerVM analyzerVM;
        public MainWindow()
        {
            InitializeComponent();
            analyzer = new Logic.Analyzer();
            analyzer.Background = new Logic.Color(50,50,50);
            analyzer.Foreground = new Logic.Color(200, 200, 200);

            DataContext = analyzerVM = new ViewModels.AnalyzerVM(analyzer);

        }

        private void ChooseFore(object sender, RoutedEventArgs e)
        {
            analyzerVM.ForeColor=Choose(analyzerVM.ForeColor);
        }

        private void ChooseBack(object sender, RoutedEventArgs e)
        {
            analyzerVM.BackColor=Choose(analyzerVM.BackColor);
        }

        private Color Choose(Color start)
        {
            Color choix = start;
            ColorPickerDialog dial = new ColorPickerDialog();
            dial.Color = start;
            dial.Title = Res.Strings.PickerTitle;            
            if(dial.ShowDialog()==true)
            {
                choix = dial.Color;
            }
            return choix;
        }

        private void What(object sender, RoutedEventArgs e)
        {
            AProposDe dial = new AProposDe();
            dial.Show();
        }
    }
}
