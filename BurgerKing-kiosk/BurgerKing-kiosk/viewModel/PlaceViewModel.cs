using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BurgerKing_kiosk.viewModel
{
    class PlaceViewModel : INotifyPropertyChanged
    {
        private int iNum;
        public int Number
        {
            get
            { return iNum; }
            set
            {
                iNum = value;
                OnPropertyChanged("Number");

                OnPropertyChanged("PlusEnable");
                OnPropertyChanged("MinusEnable");

                PageContents = string.Format("{0} 페이지를 보고 있어요.", iNum);
            }
        }

        public PlaceViewModel()
        {
            Number = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand minusCommand;
        public ICommand MinusCommand
        {
            get { return (this.minusCommand) ?? (this.minusCommand = new DelegateCommand(Minus)); }
        }
        private void Minus()
        {
            Number--;
        }

        public bool MinusEnable
        {
            get { return Number > 1 ? true : false; }
        }

        private ICommand plusCommand;
        public ICommand PlusCommand
        {
            get { return (this.plusCommand) ?? (this.plusCommand = new DelegateCommand(Plus)); }
        }
        private void Plus()
        {
            Number++;
        }
        public bool PlusEnable
        {
            get { return Number < 10 ? true : false; }
        }

        private string pageContent;
        public string PageContents
        {
            get { return pageContent; }
            set
            {
                pageContent = value;
                OnPropertyChanged("PageContents");
            }
        }
    }
}
