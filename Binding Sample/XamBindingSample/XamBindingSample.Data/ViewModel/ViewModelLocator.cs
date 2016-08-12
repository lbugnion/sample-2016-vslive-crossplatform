using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace XamBindingSample.ViewModel
{
    /// <summary>
    /// This class contains static references to the most relevant view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        private static bool _initialized;

        /// <summary>
        /// The key used by the NavigationService to go to the Bindings page.
        /// </summary>
        public const string BindingsPageKey = "BindingsPage";

        /// <summary>
        /// The key used by the NavigationService to go to the Commands page.
        /// </summary>
        public const string CommandsPageKey = "CommandsPage";

        /// <summary>
        /// The key used by the NavigationService to go to the Lists page.
        /// </summary>
        public const string ListsPageKey = "ListsPage";

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public BindingsViewModel Bindings
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BindingsViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CommandsViewModel Commands
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommandsViewModel>();
            }
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ListsViewModel Lists
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListsViewModel>();
            }
        }

        /// <summary>
        /// This property can be used to force the application to run with design time data.
        /// </summary>
        public static bool UseDesignTimeData
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }

        public static void Initialize()
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<BindingsViewModel>();
            SimpleIoc.Default.Register<CommandsViewModel>();
            SimpleIoc.Default.Register<ListsViewModel>();
        }

        static ViewModelLocator()
        {
            Initialize();
        }
    }
}