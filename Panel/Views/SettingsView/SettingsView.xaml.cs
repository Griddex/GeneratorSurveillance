﻿using Panel.BusinessLogic.MaintenanceLogic;
using Panel.Interfaces;
using Panel.ViewModels.SettingsViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Unity;

namespace Panel.Views.SettingsView
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page, IView
    {
        public static UnityContainer container { get; private set; } =
                      (UnityContainer)Application.Current.Resources["UnityIoC"];

        IView mainView = container.Resolve<IView>("MainView");

        public AuthoriserSettingsViewModel AuthoriserSettingsViewModel { get; set; }
        public ConsumptionSettingsViewModel ConsumptionSettingsViewModel { get; set; }
        public RemindersConfigViewModel RemindersConfigViewModel { get; set; }

        public SettingsView(AuthoriserSettingsViewModel authoriserSettingsViewModel,
            ConsumptionSettingsViewModel consumptionSettingsViewModel,
            RemindersConfigViewModel remindersConfigViewModel)
        {
            InitializeComponent();

            this.expdrfclSettings.DataContext = consumptionSettingsViewModel;
            this.expdrraSettings.DataContext = authoriserSettingsViewModel;
            this.expdrrcSettings.DataContext = remindersConfigViewModel;
            this.stcpnlfc1Settings.DataContext = remindersConfigViewModel;

            AuthoriserSettingsViewModel = authoriserSettingsViewModel;
            ConsumptionSettingsViewModel = consumptionSettingsViewModel;
            RemindersConfigViewModel = remindersConfigViewModel;

            this.stckpnlPassword.Margin = new Thickness(0, 440, 0, 0);

            this.Loaded += SettingsView_Loaded;
        }

        private void SettingsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.stckpnlPassword.Visibility = Visibility.Visible;
            this.vwbxSettings.Visibility = Visibility.Collapsed;
            Keyboard.Focus(this.psswrdReminder);

            ConsumptionSettingsViewModel.RefreshFuelCompTable.Execute(null);
            AuthoriserSettingsViewModel.RefreshAuthoriserTable.Execute(null);
            AuthoriserSettingsViewModel.RefreshActionPartyTable.Execute(null);
            RemindersConfigViewModel.RefreshRemindersTableCmd.Execute(null);

        }

        private void GroupbyGeneratorConsumption_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsGeneratorConsumption = CollectionViewSource
                                                      .GetDefaultView(this.dtgdGenFuelConsumptionTable
                                                                          .ItemsSource);

            if (cvsGeneratorConsumption != null && cvsGeneratorConsumption.CanGroup == true)
            {
                cvsGeneratorConsumption.GroupDescriptions.Clear();
                cvsGeneratorConsumption.GroupDescriptions
                                       .Add(new PropertyGroupDescription("GeneratorName"));
            }
        }

        private void ClearGeneratorGroupingConsumption_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsGeneratorConsumption = CollectionViewSource
                                                      .GetDefaultView(this.dtgdGenFuelConsumptionTable
                                                                          .ItemsSource);
            if (cvsGeneratorConsumption != null && cvsGeneratorConsumption
                                                        .CanGroup == true)
            {
                cvsGeneratorConsumption.GroupDescriptions.Clear();
            }
        }

        private void GroupbyFirstNameAuthorisers_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsRemindersAuthorisers = CollectionViewSource
                                                      .GetDefaultView(this.dtgdAuthoriserTable
                                                                          .ItemsSource);
            if (cvsRemindersAuthorisers != null && cvsRemindersAuthorisers
                                                        .CanGroup == true)
            {
                cvsRemindersAuthorisers.GroupDescriptions.Clear();
                cvsRemindersAuthorisers.GroupDescriptions
                                       .Add(new PropertyGroupDescription("FirstNameAuthoriser"));
            }
        }

        private void ClearFirstNameGroupingAuthorisers_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsRemindersAuthorisers = CollectionViewSource
                                                      .GetDefaultView(this.dtgdAuthoriserTable
                                                                          .ItemsSource);

            if (cvsRemindersAuthorisers != null && cvsRemindersAuthorisers.CanGroup == true)
            {
                cvsRemindersAuthorisers.GroupDescriptions.Clear();
            }
        }

        private void GroupbyFirstNameActionParties_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsRemindersAuthorisers = CollectionViewSource
                                                      .GetDefaultView(this.dtgdAuthoriserTable
                                                                          .ItemsSource);

            if (cvsRemindersAuthorisers != null && cvsRemindersAuthorisers
                                                        .CanGroup == true)
            {
                cvsRemindersAuthorisers.GroupDescriptions.Clear();
                cvsRemindersAuthorisers.GroupDescriptions
                                       .Add(new PropertyGroupDescription("FirstNameActionParty"));
            }
        }

        private void ClearFirstNameGroupingActionParties_Click(
            object sender, RoutedEventArgs e)
        {
            ICollectionView cvsRemindersAuthorisers = CollectionViewSource
                                                      .GetDefaultView(this.dtgdAuthoriserTable
                                                                          .ItemsSource);

            if (cvsRemindersAuthorisers != null && cvsRemindersAuthorisers
                                                        .CanGroup == true)
            {
                cvsRemindersAuthorisers.GroupDescriptions.Clear();
            }
        }

        private void GroupbyGeneratorRemConfig_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsRemConfig = CollectionViewSource
                                            .GetDefaultView(this.dtgdGenRemindersConfigTable
                                                                .ItemsSource);

            if (cvsRemConfig != null && cvsRemConfig.CanGroup == true)
            {
                cvsRemConfig.GroupDescriptions.Clear();
                cvsRemConfig.GroupDescriptions
                            .Add(new PropertyGroupDescription("GeneratorName"));
            }
        }

        private void ClearGeneratorGroupingRemConfig_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cvsRemConfig = CollectionViewSource
                                            .GetDefaultView(this.dtgdGenRemindersConfigTable
                                                                .ItemsSource);

            if (cvsRemConfig != null && cvsRemConfig.CanGroup == true)
            {
                cvsRemConfig.GroupDescriptions.Clear();
            }
        }

        private void DeactivateGeneratorRemConfig_Click(object sender, RoutedEventArgs e)
        {
            var dataGridRowSelected = (dynamic)dtgdGenRemindersConfigTable.SelectedItem;
            string GeneratorName = dataGridRowSelected.GeneratorName;

            MessageBoxResult result = MessageBox.Show($"Do you want to deactivate {GeneratorName}?",
                                                    "Confirmation", 
                                                    MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.No:
                case MessageBoxResult.None:
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                case MessageBoxResult.OK:
                    ScheduledRemindersMethods.DeactivateGenerator(GeneratorName);
                    break;
                default:
                    break;
            }

            this.dtgdGenRemindersConfigTable
                .ItemsSource = (this.grpbxRemConfig.DataContext as 
                                        RemindersConfigViewModel)
                                        .UnitOfWork
                                        .GeneratorScheduler
                                        .GetActiveGeneratorSchedules();

            this.dtgdGenRemindersConfigTable.Items.Refresh();
            ICollectionView cvsGeneratorReminders = CollectionViewSource
                                                    .GetDefaultView(this.dtgdGenRemindersConfigTable
                                                                        .ItemsSource);
            cvsGeneratorReminders.Refresh();
        }

        private void FuelComp_Expanded(object sender, RoutedEventArgs e)
        {
            this.expdrraSettings.IsExpanded = false;
            this.expdrrcSettings.IsExpanded = false;
                        
            double FrameWidth = (mainView as MainView).MainViewFrame.ActualWidth;
            double FrameHeight = (mainView as MainView).MainViewFrame.ActualHeight;
            this.vwbxSettings.Width = FrameWidth * 0.90;
            this.vwbxSettings.Height = FrameHeight * 0.95;
            this.expdrfclSettings.Height = FrameHeight * 0.90;
            this.grpbxFuelConsumption.Height = FrameHeight * 0.88;

            this.stckpnlPassword.Visibility = Visibility.Collapsed;

            this.vwbxSettings.Margin = new Thickness(0, 5, 0, 0);
            this.expdrfclSettings.Margin = new Thickness(0, 5, 0, 0);
            this.grpbxFuelConsumption.Margin = new Thickness(0, 5, 0, 0);

            var consumptionSettingsViewModel =
                    this.grpbxFuelConsumption.DataContext
                    as ConsumptionSettingsViewModel;

            consumptionSettingsViewModel.RefreshFuelCompTable.Execute(null);
        }

        private void FuelComp_Collapsed(object sender, RoutedEventArgs e)
        {
            this.expdrfclSettings.Height = 300;
            CollapseAllExpanders();
        }

        private void expdrAuthorisers_Expanded(object sender, RoutedEventArgs e)
        {
            this.expdrfclSettings.IsExpanded = false;
            this.expdrrcSettings.IsExpanded = false;            

            double FrameWidth = (mainView as MainView).MainViewFrame.ActualWidth;
            double FrameHeight = (mainView as MainView).MainViewFrame.ActualHeight;
            this.vwbxSettings.Width = FrameWidth * 0.90;
            this.vwbxSettings.Height = FrameHeight * 0.95;
            this.expdrraSettings.Height = FrameHeight * 0.90;
            this.grpbxAuthorisers.Height = FrameHeight * 0.88;            

            this.stckpnlPassword.Visibility = Visibility.Collapsed;

            this.vwbxSettings.Margin = new Thickness(0, 5, 0, 0);
            this.expdrraSettings.Margin = new Thickness(0, 5, 0, 0);
            this.grpbxAuthorisers.Margin = new Thickness(0, 5, 0, 0);
        }

        private void Authorisers_Collapsed(object sender, RoutedEventArgs e)
        {
            this.expdrraSettings.Height = 300;
            CollapseAllExpanders();
        }

        private void expdrAuthorisersPanel_Expanded(object sender, RoutedEventArgs e)
        {
            this.expdrAuthorisersPanel.Background = Brushes.White;
            this.expdrActionPartyPanel.IsExpanded = false;
            e.Handled = true;
        }

        private void expdrAuthorisersPanel_Collapsed(object sender, RoutedEventArgs e)
        {
            this.expdrAuthorisersPanel.Background = new BrushConverter()
                                    .ConvertFromString("#F2F2F2") as Brush;
            e.Handled = true;
        }

        private void expdrActionPartiesPanel_Expanded(object sender, RoutedEventArgs e)
        {
            this.expdrActionPartyPanel.Background = Brushes.White;
            this.expdrAuthorisersPanel.IsExpanded = false;
            e.Handled = true;
        }

        private void expdrActionPartiesPanel_Collapsed(object sender, RoutedEventArgs e)
        {
            this.expdrActionPartyPanel.Background = new BrushConverter()
                        .ConvertFromString("#F2F2F2") as Brush;
            e.Handled = true;
        }

        private void expdrReminders_Expanded(object sender, RoutedEventArgs e)
        {
            this.expdrfclSettings.IsExpanded = false;
            this.expdrraSettings.IsExpanded = false;            

            double FrameWidth = (mainView as MainView).MainViewFrame.ActualWidth;
            double FrameHeight = (mainView as MainView).MainViewFrame.ActualHeight;
            this.vwbxSettings.Width = FrameWidth * 0.90;
            this.vwbxSettings.Height = FrameHeight * 0.95;
            this.grpbxRemConfig.Height = FrameHeight * 0.90;
            this.expdrrcSettings.Height = FrameHeight * 0.88;

            this.stckpnlPassword.Visibility = Visibility.Collapsed;

            this.vwbxSettings.Margin = new Thickness(0, 5, 0, 0);
            this.expdrrcSettings.Margin = new Thickness(0, 5, 0, 0);
            this.grpbxRemConfig.Margin = new Thickness(0, 5, 0, 0);

            var remindersConfigViewModel =
                    this.grpbxRemConfig.DataContext
                    as RemindersConfigViewModel;

            remindersConfigViewModel.UniqueAuthoriserFullNamesCmd
                .Execute(null);

            remindersConfigViewModel.RefreshRemindersTableCmd
                .Execute(this.dtgdGenRemindersConfigTable);

            remindersConfigViewModel.RefreshRemindersTableCmd.Execute(null);
        }

        private void Reminders_Collapsed(object sender, RoutedEventArgs e)
        {
            this.expdrrcSettings.Height = 300;
            CollapseAllExpanders();
        }

        private void CollapseAllExpanders()
        {
            if(this.expdrfclSettings.IsExpanded == false ||
                this.expdrraSettings.IsExpanded == false ||
                this.expdrrcSettings.IsExpanded == false)
            {
                this.vwbxSettings.Margin = new Thickness(0, 300, 0, 0);
                this.vwbxSettings.Height = 300;
                this.expdrfclSettings.Height = 300;
                this.expdrraSettings.Height = 300;
                this.expdrrcSettings.Height = 300;
            }
        }

        private void expdrraSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.expdrfclSettings.IsExpanded = false;
                this.expdrraSettings.IsExpanded = false;
                this.expdrrcSettings.IsExpanded = false;
                this.stckpnlPassword.Visibility = Visibility.Visible;
            }                
        }

        private void expdrrcSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.expdrfclSettings.IsExpanded = false;
                this.expdrraSettings.IsExpanded = false;
                this.expdrrcSettings.IsExpanded = false;
                this.stckpnlPassword.Visibility = Visibility.Visible;
            }                
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
