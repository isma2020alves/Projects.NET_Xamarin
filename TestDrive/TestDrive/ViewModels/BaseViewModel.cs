using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestDrive.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            //if (PropertyChanged != null) insted of using "if" we used the conditional "?"
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
