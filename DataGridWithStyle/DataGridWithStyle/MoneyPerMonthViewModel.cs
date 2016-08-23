using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithStyle
{
    public class MoneyPerMonthViewModel : ViewModelBase
    {
        #region Nested Types

        #endregion Nested Types

        #region Fields

        private ObservableCollection<string> _moneyPerMonth;
        //private string _moneyPerMonth;

        #endregion Fields

        #region Properties

        //public string MoneyPerMonth
        //{
        //    get { return _moneyPerMonth; }
        //    set
        //    {
        //        _moneyPerMonth = value;
        //        NotifyPropertyChanged("MoneyPerMonth");
        //    }
        //}

        public ObservableCollection<string> MoneyPerMonth
        {
            get { return _moneyPerMonth; }
            set
            {
                _moneyPerMonth = value;
                NotifyPropertyChanged("MoneyPerMonth");
            }
        }

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Event Handlers

        #endregion Event Handlers

        #region Methods

        #endregion Methods

    }
}
