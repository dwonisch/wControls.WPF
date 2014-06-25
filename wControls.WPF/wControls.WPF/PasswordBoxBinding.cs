using System.Windows;
using System.Windows.Controls;

namespace wControls.WPF {

    public static class PasswordBoxBinding {
        public static readonly DependencyProperty BoundPassword = DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxBinding), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));
        private static readonly DependencyProperty IsUpdating = DependencyProperty.RegisterAttached("IsUpdating", typeof(bool), typeof(PasswordBoxBinding), new PropertyMetadata(false));
        
        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var box = d as PasswordBox;
            if (box != null) {
                box.PasswordChanged -= OnPasswordChanged;
                if(!GetIsUpdating(box))
                    box.Password = (string)e.NewValue;
                box.PasswordChanged += OnPasswordChanged;
            }
        }

        private static void OnPasswordChanged(object sender, RoutedEventArgs e) {
            var box = sender as PasswordBox;
            if (box != null) {
                SetIsUpdating(box, true);
                SetBoundPassword(box, box.Password);
                SetIsUpdating(box, false);
            }
        }

        public static string GetBoundPassword(DependencyObject dp) {
            return (string)dp.GetValue(BoundPassword);
        }

        public static void SetBoundPassword(DependencyObject dp, string value) {
            dp.SetValue(BoundPassword, value);
        }

        public static bool GetIsUpdating(DependencyObject dp) {
            return (bool)dp.GetValue(IsUpdating);
        }

        public static void SetIsUpdating(DependencyObject dp, bool value) {
            dp.SetValue(IsUpdating, value);
        }
    }
}
