using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridWithStyle
{
    public class JobPrediction
    {
        #region Nested Types

        #endregion Nested Types

        #region Fields

        #endregion Fields

        #region Properties

        public string Phase { get; set; }

        public DateTime Date { get; set; }

        public int PercentComplete { get; set; }

        public List<string> Months { get; set; }

        public List<string> Amount { get; set; }

        #endregion Properties

        #region Constructors

        public JobPrediction()
        {
            Months = new List<string>();
            Amount = new List<string>();
        }

        #endregion Constructors

        #region Event Handlers

        #endregion Event Handlers

        #region Methods

        public static List<JobPrediction> Enum1()
        {
            List<JobPrediction> exampleList = new List<JobPrediction>();
            List<string> months = new List<string>() { "May", "June", "July" };

            exampleList.Add(new JobPrediction() { Phase = "Phase 1", Date = DateTime.Today, PercentComplete = 30, Months = months, Amount = new List<string>() { "35559", "19", "15" } });
            exampleList.Add(new JobPrediction() { Phase = "Phase 1", Date = DateTime.Today, PercentComplete = 30, Months = months, Amount = new List<string>() { "99", "59", "150" } });

            exampleList.Add(new JobPrediction() { Phase = "Phase 2", Date = DateTime.Today, PercentComplete = 30, Months = months, Amount = new List<string>() { "39", "14449", "15" } });
            exampleList.Add(new JobPrediction() { Phase = "Phase 2", Date = DateTime.Today, PercentComplete = 30, Months = months, Amount = new List<string>() { "99", "59", "150" } });
            exampleList.Add(new JobPrediction() { Phase = "Phase 2", Date = DateTime.Today, PercentComplete = 30, Months = months, Amount = new List<string>() { "167", "78", "159" } });

            exampleList.Add(new JobPrediction() { Phase = "Phase 3", Date = DateTime.Today, PercentComplete = 30, Months = months, Amount = new List<string>() { "99", "59", "150" } });

            return exampleList;
        }

        #endregion Methods

    }
}
