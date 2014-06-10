using System;
using Microsoft.Win32;

namespace wControls.WPF {

    public class OpenFileService : IOService {
        public void OpenFileDialog(string file) {
            OpenFileDialog(file, null);
        }

        public void OpenFileDialog(string file, string filter) {
            var dialog = new OpenFileDialog();
            dialog.FileName = file;
            dialog.Filter = filter;

            var result = dialog.ShowDialog();

            if (result.HasValue && result.Value) {
                OnFileSelected(dialog.FileName);
            }
        }

        public event EventHandler<FileEventArgs> FileOpened;

        protected virtual void OnFileSelected(string file) {
            FileOpened.Raise(this, new FileEventArgs(file));
        }
    }
}
