using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithStyle
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Nested Types

        #endregion Nested Types

        #region Fields

        private ObservableCollection<JobPredictionViewModel> _jobPredictions;
        private JobPredictionViewModel _selectedRow;
        private string _selectedRowText;

        #endregion Fields

        #region Properties

        public ObservableCollection<JobPredictionViewModel> JobPredictions
        {
            get { return _jobPredictions; }
            set
            {
                _jobPredictions = value;
                NotifyPropertyChanged("JobPredictions");
            }
        }

        public JobPredictionViewModel SelectedRow
        {
            get { return _selectedRow; }
            set
            {
                _selectedRow = value;
                NotifyPropertyChanged("SelectedRow");

                if (_selectedRow != null && _selectedRow.Headers.Count > 0)
                {
                    this.SelectedRowText = string.Format("Phase:\t\t\t{0}\nDate:\t\t\t{1}\nPercent Complete:\t{2}\n",
                         _selectedRow.PhaseName, _selectedRow.Date.ToShortDateString(), _selectedRow.PercentComplete);

                    for (int index = 0; index < _selectedRow.Headers.Count; index++)
                    {
                        this.SelectedRowText = _selectedRowText + _selectedRow.Headers[index] + ":\t\t\t";

                        foreach (string amount in _selectedRow.AmountsPerMonth[index])
                        {
                            this.SelectedRowText = _selectedRowText + amount + ", ";
                        }
                        this.SelectedRowText = _selectedRowText.TrimEnd(' ', ',') + "\n";
                    }
                }
                else
                {
                    this.SelectedRowText = "";
                    if (_selectedRow != null)
                    {
                        _selectedRow.Headers = _jobPredictions[0].Headers;

                        for (int index = 0; index < _selectedRow.Headers.Count; index++)
                        {
                            _selectedRow.AmountsPerMonth.Add(new ObservableCollection<string>() { "0", "0" });
                        }
                    }
                        

                }


            }
        }

        public string SelectedRowText
        {
            get { return _selectedRowText; }
            set
            {
                _selectedRowText = value;
                NotifyPropertyChanged("SelectedRowText");
            }
        }

        #endregion Properties

        #region Constructors

        public MainWindowViewModel()
        {
            JobPredictions = new ObservableCollection<JobPredictionViewModel>();
        }

        #endregion Constructors

        #region Event Handlers

        #endregion Event Handlers

        #region Methods

        public void Initialize()
        {
            List<JobPrediction> jobPredictions = JobPrediction.Enum1();
            List<JobPredictionViewModel> jobPredictionViewModels = new List<JobPredictionViewModel>();

            foreach (JobPrediction jobPrediction in jobPredictions)
            {
                if (jobPredictionViewModels.Any(x=> x.PhaseName == jobPrediction.Phase))
                {
                    JobPredictionViewModel jobPredictionViewModel = jobPredictionViewModels.First(x => x.PhaseName == jobPrediction.Phase);

                    //jobPredictionViewModel.AmountsPerMonth.Add(new ObservableCollection<string>(jobPrediction.Amount));
                    for (int index = 0; index < jobPrediction.Months.Count; index++)
                    {
                        if (jobPredictionViewModel.AmountsPerMonth[index] == null)
                        {
                            jobPredictionViewModel.AmountsPerMonth.Add(new ObservableCollection<string>() { jobPrediction.Amount[index] });
                        }
                        else
                        {
                            jobPredictionViewModel.AmountsPerMonth[index].Add(jobPrediction.Amount[index]);
                        }
                        
                    }
                }
                else
                {
                    jobPredictionViewModels.Add(new JobPredictionViewModel(jobPrediction));
                }
            }

            JobPredictions = new ObservableCollection<JobPredictionViewModel>(jobPredictionViewModels);
        }

        #endregion Methods

    }
}
