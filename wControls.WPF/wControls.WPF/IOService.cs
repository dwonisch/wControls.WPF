using System;

namespace wControls.WPF {

    public interface IOService {
        void OpenFileDialog(string file, string filter);
        event EventHandler<FileEventArgs> FileOpened;
    }

    public class FileEventArgs : EventArgs {
        public FileEventArgs(string file) {
            File = file;
        }

        public string File { get; private set; }
    }
}
