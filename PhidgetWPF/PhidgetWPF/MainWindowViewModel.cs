using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhidgetWPF
{
    class MainWindowViewModel :  ViewModelBase
    {
        #region Events
        #endregion

        #region Fields and Properties

        private CommandLineOpen _commandLineOpen { get; set; }

        private string _test;
        public string Test
        {
            get { return _test; }
            set { Set(() => Test, ref _test, value); }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set 
            { 
                Set(() => Value, ref _value, value);
                Test = Value.ToString();
            }
        }

        #endregion

        #region Relay Commands

        private RelayCommand _turnOnCommand;
        public RelayCommand TurnOnCommand
        {
            get
            {
                return _turnOnCommand ?? (_turnOnCommand = new RelayCommand(() =>
                {
                    Test = "Test !!!";
                }));
            }
        }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            _commandLineOpen = new CommandLineOpen();
            Test = "Some text";
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
