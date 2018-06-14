﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Panel.Interfaces;
using Panel.Models.InputModels;
using Panel.Services;
using Panel.Services.NavigationService;
using Panel.Views.ChartViews;
using Panel.Views.HelpViews;
using Panel.Views.InputViews;
using Panel.Views.ReportViews;
using Panel.Views.TableViews;
using Unity;

namespace Panel
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class MainView : Window, IView
    {
        UnityContainer container = (UnityContainer)Application.Current.Resources["UnityIoC"];
        
        private InputView _inputView;
        public MainView(InputView inputView)
        {
            InitializeComponent();
            this._inputView = inputView;
            MainViewFrame.Navigate(this._inputView);
        }

        private void InputViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void InputViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainViewFrame.Navigate(this._inputView);
        }

        private void TablesViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void TablesViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UsageFuellingTablesView usageFuellingTablesView = (UsageFuellingTablesView)container.Resolve<IView>("UsageFuellingTablesView");
            MainViewFrame.Navigate(usageFuellingTablesView);
        }

        private void ChartsViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void ChartsViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ChartView chartView = (ChartView)container.Resolve<IView>("ChartView");
            MainViewFrame.Navigate(chartView);
        }

        private void ReportsViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void ReportsViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ReportView reportView = (ReportView)container.Resolve<IView>("ReportView");
            MainViewFrame.Navigate(reportView);
        }

        private void HelpViewCmd_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void HelpViewCmd_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpView helpView = (HelpView)container.Resolve<IView>("HelpView");
            MainViewFrame.Navigate(helpView);
        }
        
        private void InputToUsageView_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void InputToUsageView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UsageView usageView = (UsageView)container.Resolve<IView>("UsageView");
            usageView.lblCurrentGeneratorName.Content = this._inputView.cmbxGenInfo.Text;
            usageView.lblGenRecordDate.Content = $"{this._inputView.dtepkrGenInfo.SelectedDate.Value.ToShortDateString()} { this._inputView.lblGenTimeStarted.Content.ToString()}";
            MainViewFrame.Navigate(usageView);
        }

        private void UsageToFuellingView_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void UsageToFuellingView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FuellingView fuellingView = (FuellingView)container.Resolve<IView>("FuellingView");
            MainViewFrame.Navigate(fuellingView);
        }

        private void FuellingToMaintenanceView_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void FuellingToMaintenanceView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MaintenanceView maintenanceView = (MaintenanceView)container.Resolve<IView>("MaintenanceView");
            MainViewFrame.Navigate(maintenanceView);
        }

        private void UsageMaintToRunningHrsSchedulerView_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void UsageMaintToRunningHrsSchedulerView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RunningHrsSchedulingTablesView runningHrsSchedulingTablesView = (RunningHrsSchedulingTablesView)container.Resolve<IView>("RunningHrsSchedulingTablesView");
            MainViewFrame.Navigate(runningHrsSchedulingTablesView);
        }
        //RunningHrsSchedulerToUsageMaintView_Executed
        private void RunningHrsSchedulerToUsageMaintView_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void RunningHrsSchedulerToUsageMaintView_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UsageFuellingTablesView usageFuellingTablesView = (UsageFuellingTablesView)container.Resolve<IView>("UsageFuellingTablesView");
            MainViewFrame.Navigate(usageFuellingTablesView);
        }
    }
}