using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using XamBindingSample.Model;

namespace XamBindingSample.ViewModel
{
    public class BindingsViewModel : ViewModelBase
    {
        private MainModel _model;
        private bool _myBoolProperty;
        private bool _myProperty;
        private RelayCommand _setModelPropertyCommand;
        private RelayCommand _toggleCommand;

        public MainModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                Set(ref _model, value);
            }
        }

        public bool MyBoolProperty
        {
            get
            {
                return _myBoolProperty;
            }
            set
            {
                Set(ref _myBoolProperty, value);
            }
        }

        public bool MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {
                Set(ref _myProperty, value);
            }
        }

        public RelayCommand SetModelPropertyCommand
        {
            get
            {
                return _setModelPropertyCommand
                       ?? (_setModelPropertyCommand = new RelayCommand(
                           () =>
                           {
                               if (Model == null)
                               {
                                   Model = new MainModel();
                                   return;
                               }

                               Model.MyModelProperty = DateTime.Now.Ticks.ToString();
                           }));
            }
        }

        public RelayCommand ToggleCommand
        {
            get
            {
                return _toggleCommand
                       ?? (_toggleCommand = new RelayCommand(
                           () =>
                           {
                               MyBoolProperty = !MyBoolProperty;
                           }));
            }
        }
    }
}