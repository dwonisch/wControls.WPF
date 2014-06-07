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
            IsCueVisible = Text.Length == 0;
        }
    }
}
