/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:QuestDolls.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using DiscretInputDriver;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using QuestDolls.Model;
using QuestDolls.Settings;
using RelayDriver;
using System;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<Func<Type, string, object>>(() => (type,key) => ServiceLocator.Current.GetInstance(type, key));
            SimpleIoc.Default.Register<IMainSettings>(MainSettings.LoadSettings);
            SimpleIoc.Default.Register<IDiscretInputs>(() => new DiscretInputs(1), "DiscretInput");//TODO решить вопрос с моментом конфигурирования.
            SimpleIoc.Default.Register<IRelay>(() => new Relay(1), "Relay");//TODO решить вопрос с моментом конфигурирования.
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DoolsViewModel>();
        }

        /// <summary>
        /// G?ets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                var mine = ServiceLocator.Current.GetInstance<MainViewModel>();
                return mine;
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public DoolsViewModel Dools
        {
            get
            {
               var doors = ServiceLocator.Current.GetInstance<DoolsViewModel>();
                return doors;
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ServiceLocator.Current.GetInstance<IDataService>().Dispose();
        }
    }
}