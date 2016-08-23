using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithStyle
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Nested Types

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Nested Types

        #region Fields

        protected bool _pageIsActive = false;

        #endregion Fields

        #region Properties

        //public bool PageIsActive
        //{
        //    get { return _pageIsActive; }
        //    set
        //    {
        //        if (_pageIsActive != value)
        //        {
        //            _pageIsActive = value;

        //            if (_pageIsActive)
        //            {
        //                OnPageActivated();
        //            }
        //            else
        //            {
        //                OnPageDeactivated();
        //            }
        //        }
        //    }
        //}

        #endregion Properties

        #region Constructors

        public ViewModelBase()
        {

        }

        #endregion Constructors

        #region Event Handlers

        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        protected virtual void OnPageActivated()
        {

        }

        protected virtual void OnPageDeactivated()
        {

        }

        #endregion Event Handlers

        #region Methods

        #endregion Methods

    }
}
