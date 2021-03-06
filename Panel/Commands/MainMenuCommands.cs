﻿using System.Windows.Input;

namespace Panel.Commands
{
    public static class MainMenuCommands
    {
        public static readonly RoutedUICommand showInputView  = new RoutedUICommand
                                                                    (
                                                                    "ShowInputView",
                                                                    "ShowInputView",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.I, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand ShowInputView
        {
            get { return showInputView; }
        }


        public static readonly RoutedUICommand showTablesView  = new RoutedUICommand
                                                                    (
                                                                    "ShowTablesView",
                                                                    "ShowTablesView",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.T, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand ShowTablesView
        {
            get { return showTablesView; }
        }


        public static readonly RoutedUICommand showChartsView  = new RoutedUICommand
                                                                    (
                                                                    "ShowChartsView",
                                                                    "ShowChartsView",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.C, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand ShowChartsView
        {
            get { return showChartsView; }
        }


        public static readonly RoutedUICommand showReportsView = new RoutedUICommand
                                                                    (
                                                                    "ShowReportsView",
                                                                    "ShowReportsView",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.R, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand ShowReportsView
        {
            get { return showReportsView; }
        }

        public static readonly RoutedUICommand showHelpView = new RoutedUICommand
                                                                    (
                                                                    "ShowHelpView",
                                                                    "ShowHelpView",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.H, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand ShowHelpView
        {
            get { return showHelpView; }
        }

        public static readonly RoutedUICommand showSettingsView = new RoutedUICommand
                                                                    (
                                                                    "ShowSettingsView",
                                                                    "ShowSettingsView",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.S, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand ShowSettingsView
        {
            get { return showSettingsView; }
        }


        public static readonly RoutedUICommand exit = new RoutedUICommand
                                                                    (
                                                                    "Exit",
                                                                    "Exit",
                                                                    typeof(MainView),
                                                                    new InputGestureCollection()
                                                                    {
                                                                        new KeyGesture(Key.E, ModifierKeys.Alt)
                                                                    });
        public static RoutedUICommand Exit
        {
            get { return exit; }
        }
    }
}
