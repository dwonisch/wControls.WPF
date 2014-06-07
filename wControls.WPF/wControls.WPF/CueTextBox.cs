namespace wControls.WPF {
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public class CueTextBox : TextBox {
        static CueTextBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CueTextBox), new FrameworkPropertyMetadata(typeof(CueTextBox)));
        }

        public CueTextBox() {
            IsCueVisible = true;
        }

        public static DependencyProperty CueProperty = DependencyProperty.Register("Cue", typeof(string), typeof(CueTextBox));
        public static DependencyProperty IsCueVisibleProperty = DependencyProperty.Register("IsCueVisible", typeof(bool), typeof(CueTextBox));

        public string Cue {
            get { return (string)GetValue(CueProperty); }
            set { SetValue(CueProperty, value); }
        }

        public bool IsCueVisible {
            get { return (bool)GetValue(IsCueVisibleProperty); }
            private set { SetValue(IsCueVisibleProperty, value);}
        }

        /// <summary>
        /// Is called when content in this editing control changes.
        /// </summary>
        /// <param name="e">The arguments that are associated with the <see cref="E:System.Windows.Controls.Primitives.TextBoxBase.TextChanged"/> event.</param>
        protected override void OnTextChanged(TextChangedEventArgs e) {
            base.OnTextChanged(e);
            CheckIfCueShouldBeVisible();
        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.UIElement.GotFocus"/> event reaches this element in its route.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(RoutedEventArgs e) {
            base.OnGotFocus(e);
            CheckIfCueShouldBeVisible();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.UIElement.LostFocus"/> event (using the provided arguments).
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnLostFocus(RoutedEventArgs e) {
            base.OnLostFocus(e);
            CheckIfCueShouldBeVisible();
        }

        private void CheckIfCueShouldBeVisible() {
            IsCueVisible = Text.Length == 0 && !IsFocused;
        }
    }
}
