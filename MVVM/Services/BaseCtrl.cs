using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.Services {
    public class BaseCtrl : INotifyPropertyChanged {
        protected SQLExecuter _sqlExecuter;
        //protected abstract void containerHeightChanged(double actualHeight);
        //protected abstract void containerWidthChanged(double actualWidth);
        //protected abstract void setContainer(UserControl uc);
        //protected abstract void setContainer(Window wd);

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void printError(string exc) {
            MessageBox.Show("Something went wrong...\n\n" + exc, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        protected void printError(Exception exc) {
            MessageBox.Show("Something went wrong...\n\n" + exc.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        protected void printIncorrectInput() {
            MessageBox.Show("Some fields had not been set properly.", "Incorrect input", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        protected MessageBoxResult printDeleteQuestion() {
            return MessageBox.Show("Do you really want to delete the selected item(s)?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
