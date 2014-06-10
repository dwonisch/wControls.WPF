namespace wControls.WPF.Test {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged {
        private double scale;
        private string selectedFile;
        private readonly ICommand openFileCommand;
        private readonly ICommand openFileWithFilterCommand;

        private ICommand CreateOpenFileCommand(string filter) {
            var service = new OpenFileService();
            service.FileOpened += (sender, args) => SelectedFile = args.File;
            return new Command<string>(file => service.OpenFileDialog(file, filter));
        }

        public MainWindow() {
            Scale = 1;
            openFileCommand = CreateOpenFileCommand(null);
            openFileWithFilterCommand = CreateOpenFileCommand("Word Document|*.docx");
            InitializeComponent();
        }

        public double Scale {
            get { return scale; }
            set {
                scale = value; 
                OnPropertyChanged();
            }
        }

        public string SelectedFile {
            get { return selectedFile; }
            set {
                selectedFile = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand OpenFile {
            get { return openFileCommand; }
        }

        public ICommand OpenFileWithFilter {
            get { return openFileWithFilterCommand; }
        }
    }
}
