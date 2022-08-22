using System.Windows;

namespace SquaredCircle_bot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Creates instance of <see cref="MainWindow"/>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var dependencyFactory = new DependencyFactory();

            DataContext = dependencyFactory.MainWindowViewModel;
        }
    }
}