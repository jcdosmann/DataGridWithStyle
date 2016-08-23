using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithStyle
{
    public class JobPredictionViewModel : ViewModelBase
    {
        #region Nested Types

        #endregion Nested Types

        #region Fields

        private string _phaseName;
        private DateTime _date;
        private int _percentComplete;
        private List<string> _headers;
        private List<ObservableCollection<string>> _amountsPerMonth;

        #endregion Fields

        #region Properties

        public string PhaseName
        {
            get { return _phaseName; }
            set
            {
                _phaseName = value;
                NotifyPropertyChanged("PhaseName");
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public int PercentComplete
        {
            get { return _percentComplete; }
            set
            {
                _percentComplete = value;
                NotifyPropertyChanged("PercentComplete");
            }
        }

        public List<string> Headers
        {
            get { return _headers; }
            set
            {
                _headers = value;
                NotifyPropertyChanged("Headers");
            }
        }

        public List<ObservableCollection<string>> AmountsPerMonth
        {
            get { return _amountsPerMonth; }
            set
            {
                _amountsPerMonth = value;
                NotifyPropertyChanged("AmountsPerMonth");
            }
        }

        #endregion Properties

        #region Constructors

        public JobPredictionViewModel()
        {
            _date = DateTime.Today;
            _percentComplete = 0;
            _headers = new List<string>();
            _amountsPerMonth = new List<ObservableCollection<string>>();
        }

        public JobPredictionViewModel(JobPrediction jobPrediction)
        {
            _phaseName = jobPrediction.Phase;
            _date = jobPrediction.Date;
            _percentComplete = jobPrediction.PercentComplete;
            _headers = jobPrediction.Months;
            ObservableCollection<string> amounts = new ObservableCollection<string>(jobPrediction.Amount);
            _amountsPerMonth = new List<ObservableCollection<string>>() ;

            foreach( string amount in jobPrediction.Amount)
            {
                _amountsPerMonth.Add(new ObservableCollection<string>() { amount });
            }
        }

        #endregion Constructors

        #region Event Handlers

        #endregion Event Handlers

        #region Methods

        #endregion Methods

    }
}
