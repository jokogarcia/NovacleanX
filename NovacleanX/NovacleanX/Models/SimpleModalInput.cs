using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NovacleanX.Models
{
    public class SimpleModalInput
    {
        public string OkButtonText { get; set; }
        public string CancelButtonText { get; set; }
        public string TitleText { get; set; }
        public string Message { get; set; }

        public bool ShowOkButton { get; set; }
        public bool ShowCancelButton { get; set; }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public bool IsErrorModal { get; set; }
    }
}
