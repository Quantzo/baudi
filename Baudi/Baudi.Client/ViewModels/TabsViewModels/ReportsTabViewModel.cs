using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Baudi.Client.Annotations;
using Baudi.Client.Reports.BuildingReport.ExpenseReport;
using Baudi.Client.Reports.BuildingReport.RentReport;
using Baudi.Client.Reports.SalaryReport;
using Baudi.DAL;
using Baudi.DAL.Models;

namespace Baudi.Client.ViewModels.TabsViewModels
{





    public class ReportsTabViewModel : INotifyPropertyChanged
    {



        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ButtonGenerate { get; set; }



        private ReportType _reportType;


        public ReportType ReportType
        {
            get { return _reportType; }
            set
            {
                _reportType = value;
                OnPropertyChanged("ReportType");
            }
        }

        public IEnumerable<ReportType> ReportTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(ReportType))
                    .Cast<ReportType>();
            }
        }




        private bool _isBuildingReport;
        public bool IsBuildingReport
        {
            get
            {
                return _isBuildingReport;
            }
            set
            {
                _isBuildingReport = value;
                OnPropertyChanged("IsBuildingReport");
            }
        }

        private List<Building> _buildingsList;

        public List<Building> BuildingsList
        {
            get { return _buildingsList; }
            set
            {
                _buildingsList = value;
                OnPropertyChanged("BuildingsList");
            }
        }

        private Building _selectedBuilding;

        public Building SelectedBuilding
        {
            get { return _selectedBuilding; }
            set
            {
                _selectedBuilding = value;
                OnPropertyChanged("SelectedBuilding");
            }
        }


        private DateTime _dateFrom;

        public DateTime DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                _dateFrom = value;
                OnPropertyChanged("DateFrom");
            }
        }

        private DateTime _dateTo;

        public DateTime DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                _dateTo = value;
                OnPropertyChanged("DateTo");
            }
        }



        #endregion


        public ReportsTabViewModel()
        {
            ButtonGenerate = new RelayCommand(pars => Generate(), pars =>IsValid());
            _dateFrom = DateTime.Now;
            _dateTo = DateTime.Now;
            PropertyChanged += OnReportTypeChange;
            _reportType = ReportType.SalaryReport;
            using (var con = new BaudiDbContext())
            {
                BuildingsList = con.Buildings.ToList();
            }
            SelectedBuilding = BuildingsList.FirstOrDefault();

        }




        private void Generate()
        {
            if (ReportType == ReportType.SalaryReport)
            {
                var report = new SalaryReport(DateFrom,DateTo,"Pensje"+DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace("/","").Replace(" ", "").Replace(":","") + ".pdf");
                report.LoadData();
                report.PrintPdf();

            }
            else if(ReportType == ReportType.ExpenseReport)
            {
                var report = new ExpenseReport(DateFrom,DateTo,"Wydatki" + DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace("/", "").Replace(" ","").Replace(":", "") + ".pdf",SelectedBuilding.NotificationTargetID);
                report.LoadData();
                report.PrintPdf();
            }
            else if (ReportType == ReportType.RentReport)
            {
                var report = new RentReport(DateFrom, DateTo,"Czynsze" + DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace("/", "").Replace(" ", "").Replace(":", "") + ".pdf",SelectedBuilding.NotificationTargetID);
                report.LoadData();
                report.PrintPdf();
            }


        }

        private bool IsValid()
        {
            return DateTo > DateFrom;

        }


        private void OnReportTypeChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReportType")
            {
                IsBuildingReport = CheckIfReportIsBuildingReport();
            }
        }

        private bool CheckIfReportIsBuildingReport()
        {
            return ReportType == ReportType.ExpenseReport || ReportType == ReportType.RentReport;
        }


        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }

    public enum ReportType
    {
        [Description("Czynsze dla budynku")]
        RentReport,
        [Description("Wydatki dla budynku")]
        ExpenseReport,
        [Description("Pensje")]
        SalaryReport,

    }
}