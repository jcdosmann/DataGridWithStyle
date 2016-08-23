using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridWithStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Nested Types

        #endregion Nested Types

        #region Fields

        MainWindowViewModel _mainWindowViewModel;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        public MainWindow()
        {
            /*
             * References: 
             *http://stackoverflow.com/questions/20683047/databinding-issues-with-programmatically-added-datatemplate-and-datagrid-wpf
             *http://stackoverflow.com/questions/8779893/create-datagridtemplatecolumn-through-c-sharp-code
             * 
            */

            InitializeComponent();

            _mainWindowViewModel = new MainWindowViewModel();
            _mainWindowViewModel.Initialize();

            this.DataContext = _mainWindowViewModel;

            if (_mainWindowViewModel.JobPredictions.Count > 0)
            {
                foreach (string header in _mainWindowViewModel.JobPredictions[0].Headers)
                {
                    DataGridTemplateColumn dataGridTemplateColumn = new DataGridTemplateColumn();
                    dataGridTemplateColumn.Header = header;
                    
                    int month = _mainWindowViewModel.JobPredictions[0].Headers.IndexOf(header);

                    string binding = "AmountsPerMonth[" + month.ToString() + "]";

                    string templatetest = @"
                    <DataTemplate xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns = 'http://schemas.microsoft.com/winfx/2006/xaml/presentation' x:Key='MonthCell'>
                        <Grid>
                            <DataGrid HeadersVisibility='None' ItemsSource='{Binding Path=" + binding + @"}' AutoGenerateColumns='False' x:Name='amountsDataGrid' >
                                <DataGrid.Columns>
                                    <DataGridTextColumn Binding='{Binding .}' />
                                </DataGrid.Columns>
                            </DataGrid>
                        </Grid>
                    </DataTemplate>
                    ";

                    // other options for the DataGridTextColumn Binding I considered:
                    //  {Binding Path=DataContext, RelativeSource={RelativeSource Self}}
                    //  {Binding}

                    var template = (DataTemplate)XamlReader.Parse(templatetest);


                    dataGridTemplateColumn.CellTemplate = template;
                    dataGridTemplateColumn.CellEditingTemplate = template;

                    dataGrid.Columns.Add(dataGridTemplateColumn);
                }
            }
            
            
        }


        #endregion Constructors

        #region Event Handlers

        #endregion Event Handlers

        #region Methods



        #endregion Methods
    }
}
