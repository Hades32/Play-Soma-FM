using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PlaySomaFM
{
    public class Helper
    {
        #region SelectedTemplate

        /// <summary>
        /// SelectedTemplate Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty SelectedTemplateProperty =
            DependencyProperty.RegisterAttached("SelectedTemplate", typeof(DataTemplate), typeof(Helper),
                new PropertyMetadata((DataTemplate)null,
                    new PropertyChangedCallback(OnSelectedTemplateChanged)));

        /// <summary>
        /// Gets the SelectedTemplate property. This dependency property 
        /// indicates the data template to use for the selected item.
        /// </summary>
        public static DataTemplate GetSelectedTemplate(DependencyObject d)
        {
            return (DataTemplate)d.GetValue(SelectedTemplateProperty);
        }

        /// <summary>
        /// Sets the SelectedTemplate property. This dependency property 
        /// indicates the data template to use for the selected item.
        /// </summary>
        public static void SetSelectedTemplate(DependencyObject d, DataTemplate value)
        {
            d.SetValue(SelectedTemplateProperty, value);
        }

        /// <summary>
        /// Handles changes to the SelectedTemplate property.
        /// </summary>
        private static void OnSelectedTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var oldValue = (DataTemplate)e.OldValue;
            var newValue = (DataTemplate)d.GetValue(SelectedTemplateProperty);
            var lb = (ListBox)d;

            lb.SelectionChanged += new SelectionChangedEventHandler(lb_SelectionChanged);
        }

        static void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lb = (ListBox)sender;
            // hack to check if the list is loaded
            if (lb.ActualHeight == 0)
            {
                lb.Loaded += (_, __) => lb_SelectionChanged(sender, e);
                return;
            }
            var template = (DataTemplate)lb.GetValue(SelectedTemplateProperty);

            foreach (var item in e.AddedItems)
            {
                var cont = (ListBoxItem)lb.ItemContainerGenerator.ContainerFromItem(item);
                cont.ContentTemplate = template;
            }

            foreach (var item in e.RemovedItems)
            {
                var cont = (ListBoxItem)lb.ItemContainerGenerator.ContainerFromItem(item);
                cont.ContentTemplate = lb.ItemTemplate;
            }
        }

        #endregion


    }
}
