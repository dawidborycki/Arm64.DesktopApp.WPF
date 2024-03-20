using Arm64.DesktopApp.WPF.Data;
using Arm64.DesktopApp.WPF.Helpers;
using System.Collections.ObjectModel;
using System.Windows;

namespace Arm64.DesktopApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ChartData> Items { get; set; } = [];

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            LabelProcessorArchitecture.Content = "Processor architecture: " +
                $"{Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")}";
        }

        private void ButtonRunCalculations_Click(object sender, RoutedEventArgs e)
        {
            int size = Convert.ToInt32(TextBoxVectorSize.Text);
            int executionCount = Convert.ToInt32(TextBoxExecutionCount.Text);

            var executionTime = PerformanceHelper.MeasurePerformance(
                () => VectorHelper.AdditionOfProduct(size),
                executionCount);

            Items.Add(new ChartData { 
                ExecutionCount = executionCount,
                ExecutionTime = executionTime,
            });         
        }

        private void ButtonClearResults_Click(object sender, RoutedEventArgs e)
        {
            Items.Clear();
        }
    }
}








