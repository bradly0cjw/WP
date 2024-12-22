using HW2;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace HW2
{
    public class PresentationModel2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsConfirmEnabled { get; set; }

        private readonly string _text;
        public PresentationModel2(string text)
        {
            _text = text;
            IsConfirmEnabled = false;
        }

        public void TextChanged(string text)
        {
            if (text.Length > 0 && text != _text)
            {
                IsConfirmEnabled = true;
            }
            else
            {
                IsConfirmEnabled = false;
            }
            Notify("IsConfirmEnabled");
        }

        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}