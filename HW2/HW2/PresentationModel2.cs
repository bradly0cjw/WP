using HW2;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

public class PresentationModel2 : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    Model _model;
    public bool IsConfirmEnabled { get; set; }

    string _text;
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
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

}

