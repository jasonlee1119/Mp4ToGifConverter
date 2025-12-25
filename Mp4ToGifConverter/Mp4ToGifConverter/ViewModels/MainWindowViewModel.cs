using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mp4ToGifConverter.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _inputPath = string.Empty;

        [ObservableProperty]
        private string _inputPathText = string.Empty;
        
        [ObservableProperty]
        private string _outputPath = string.Empty;

        [ObservableProperty]
        private bool _isGrayScale = false;

        [ObservableProperty]
        private string _scale = "1.0";

        [ObservableProperty]
        private string _fps = "30";

        [ObservableProperty]
        private bool _isInProgress = false;

        public ICommand MainWindowLoadedCommand => new AsyncRelayCommand(async () =>
        {
            await Task.Delay(5);
        });

        public ICommand SelectInputCommand => new RelayCommand(() =>
        {
            var dialog = new OpenFileDialog
            {
                Filter = "mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*",
                Title = "Select MP4 File",
                DefaultExt = "*.mp4"
            };

            if (dialog.ShowDialog() == true)
            {
                InputPath = dialog.FileName;
                InputPathText = Path.GetFileName(InputPath);
            }
        });

        public ICommand SeletOutputCommand => new RelayCommand(() =>
        {
            var dialog = new SaveFileDialog
            {
                Title = "Save GIF",
                Filter = "*.gif|All files (*.*)|*.*",
                FileName = "output.gif"
            };

            if (dialog.ShowDialog() == true)
            {
                OutputPath = dialog.FileName;
            }
        });
    }
}
