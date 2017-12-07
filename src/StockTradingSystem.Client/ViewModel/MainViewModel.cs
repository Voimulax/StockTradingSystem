﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using StockTradingSystem.Client.Model.UI.Navigation;

namespace StockTradingSystem.Client.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public static readonly string Canback = "FrameNavigationServiceCanBack";
        public static readonly string ShowDialog = "DialogServiceShowDialog";

        private readonly IFrameNavigationService _navigationService;

        public MainViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<GenericMessage<bool>>(this, Canback, b => BackBtnVisibility = b.Content ? Visibility.Visible : Visibility.Collapsed);
            Messenger.Default.Register<GenericMessage<bool>>(this, ShowDialog, b =>
            {
                BackBtnIsEnabled = !b.Content;
                MainFrameIsEnabled = !b.Content;
                MainFrameEffect = b.Content
                    ? new BlurEffect { Radius = 17, RenderingBias = RenderingBias.Performance }
                    : null;
            });
        }

        #region Property

        /// <summary>
        /// The <see cref="WindowState" /> property's name.
        /// </summary>
        public const string WindowStatePropertyName = nameof(WindowState);

        private WindowState _windowState = WindowState.Normal;

        /// <summary>
        /// Sets and gets the <see cref="WindowState"/> property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                switch (value)
                {
                    case WindowState.Maximized:
                        WindowBorderMargin = new Thickness(7);
                        break;
                    case WindowState.Normal:
                        WindowBorderMargin = new Thickness(0);
                        break;
                    case WindowState.Minimized:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                Set(WindowStatePropertyName, ref _windowState, value);
            }
        }

        /// <summary>
        /// The <see cref="WindowBorderMargin" /> property's name.
        /// </summary>
        public const string WindowBorderMarginPropertyName = nameof(WindowBorderMargin);

        private Thickness _windowBorderMargin = new Thickness(0);

        /// <summary>
        /// Sets and gets the <see cref="WindowBorderMargin"/> property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Thickness WindowBorderMargin
        {
            get => _windowBorderMargin;
            set => Set(WindowBorderMarginPropertyName, ref _windowBorderMargin, value);
        }

        /// <summary>
        /// The <see cref="WindowTitle" /> property's name.
        /// </summary>
        public const string WindowTitlePropertyName = nameof(WindowTitle);

        private string _windowTitle = "股票交易系统";

        /// <summary>
        /// Sets and gets the <see cref="WindowTitle"/> property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WindowTitle
        {
            get => _windowTitle;
            set => Set(WindowTitlePropertyName, ref _windowTitle, value);
        }

        /// <summary>
        /// The <see cref="BackBtnVisibility" /> property's name.
        /// </summary>
        public const string BackBtnVisibilityPropertyName = nameof(BackBtnVisibility);

        private Visibility _backBtnVisibility = Visibility.Collapsed;

        /// <summary>
        /// Sets and gets the <see cref="BackBtnVisibility"/> property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility BackBtnVisibility
        {
            get => _backBtnVisibility;
            set => Set(BackBtnVisibilityPropertyName, ref _backBtnVisibility, value);
        }

        /// <summary>
        /// The <see cref="ThemeBrush" /> property's name.
        /// </summary>
        public const string ThemeBrushPropertyName = nameof(ThemeBrush);

        private SolidColorBrush _themeBrush = new SolidColorBrush(Color.FromArgb(255, 0, 99, 177));

        /// <summary>
        /// Sets and gets the <see cref="ThemeBrush"/> property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SolidColorBrush ThemeBrush
        {
            get => _themeBrush;
            set => Set(ThemeBrushPropertyName, ref _themeBrush, value);
        }

        /// <summary>
        /// The <see cref="WindowContent" /> property's name.
        /// </summary>
        public const string ContentPropertyName = nameof(WindowContent);

        private object _windowContent;

        /// <summary>
        /// Sets and gets the <see cref="WindowContent"/> property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object WindowContent
        {
            get => _windowContent;
            set => Set(ContentPropertyName, ref _windowContent, value);
        }

        /// <summary>
        /// The <see cref="BackBtnIsEnabled" /> property's name.
        /// </summary>
        public const string BackBtnEnabledPropertyName = nameof(BackBtnIsEnabled);

        private bool _backBtnIsEnabled = true;

        /// <summary>
        /// Sets and gets the <see cref="BackBtnIsEnabled"/> property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public bool BackBtnIsEnabled
        {
            get => _backBtnIsEnabled;
            set => Set(BackBtnEnabledPropertyName, ref _backBtnIsEnabled, value, true);
        }

        /// <summary>
        /// The <see cref="MainFrameIsEnabled" /> property's name.
        /// </summary>
        public const string MainFrameEnabledPropertyName = nameof(MainFrameIsEnabled);

        private bool _mainFrameIsEnabled = true;

        /// <summary>
        /// Sets and gets the <see cref="MainFrameIsEnabled"/> property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public bool MainFrameIsEnabled
        {
            get => _mainFrameIsEnabled;
            set => Set(MainFrameEnabledPropertyName, ref _mainFrameIsEnabled, value, true);
        }

        /// <summary>
        /// The <see cref="MainFrameEffect" /> property's name.
        /// </summary>
        public const string MainFrameEffectPropertyName = nameof(MainFrameEffect);

        private Effect _mainFrameEffect;

        /// <summary>
        /// Sets and gets the <see cref="MainFrameEffect"/> property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public Effect MainFrameEffect
        {
            get => _mainFrameEffect;
            set => Set(MainFrameEffectPropertyName, ref _mainFrameEffect, value, true);
        }

        #endregion

        #region Command

        private RelayCommand _minimizeCommand;

        /// <summary>
        /// Gets the <see cref="MinimizeCommand"/>.
        /// </summary>
        public RelayCommand MinimizeCommand => _minimizeCommand ?? (_minimizeCommand = new RelayCommand(ExecuteMinimize));

        private void ExecuteMinimize()
        {
            WindowState = WindowState.Minimized;
        }

        private RelayCommand _closeCommand;

        /// <summary>
        /// Gets the <see cref="CloseCommand"/>.
        /// </summary>
        public RelayCommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(ExecuteClose));

        private static async void ExecuteClose()
        {
            await SimpleIoc.Default.GetInstance<IDialogService>().ShowMessage("确定要退出吗？", "提示", "确定", "取消", b =>
              {
                  if (b) Application.Current.Shutdown();
              });
        }

        private RelayCommand _maximizeCommand;

        /// <summary>
        /// Gets the <see cref="MaximizeCommand"/>.
        /// </summary>
        public RelayCommand MaximizeCommand => _maximizeCommand ?? (_maximizeCommand = new RelayCommand(ExecuteMaximize));

        private void ExecuteMaximize()
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private RelayCommand<string> _navigateCommand;

        /// <summary>
        /// Gets the <see cref="NavigateCommand"/>.
        /// </summary>
        public RelayCommand<string> NavigateCommand => _navigateCommand
                                                       ?? (_navigateCommand = new RelayCommand<string>(ExecuteNavigateCommand));

        private void ExecuteNavigateCommand(string pageKey)
        {
            SimpleIoc.Default.GetInstance<IFrameNavigationService>()?.NavigateTo(pageKey);
        }

        private RelayCommand _goBackCommand;

        /// <summary>
        /// Gets the <see cref="GoBackCommand"/>.
        /// </summary>
        public RelayCommand GoBackCommand => _goBackCommand
                                             ?? (_goBackCommand = new RelayCommand(ExecuteGoBackCommand));

        private void ExecuteGoBackCommand()
        {
            _navigationService.GoBack();
        }

        #endregion

        public override void Cleanup()
        {
            // Clean up if needed
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }
    }
}