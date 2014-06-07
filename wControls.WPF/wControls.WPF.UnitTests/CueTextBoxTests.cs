namespace wControls.WPF.UnitTests {
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using NUnit.Framework;

    [TestFixture, RequiresSTA]
    public class CueTextBoxTests {
        private CueTextBox textbox;

        [SetUp]
        public void Setup() {
            textbox = new CueTextBox();
        }

        [Test]
        public void CueIsVisibileByDefault() {
            Assert.That(textbox.IsCueVisible, Is.True);
        }

        [Test]
        public void CueIsNotVisibleWhenTextIsEntered() {
            textbox.Text = "Sample text";
            Assert.That(textbox.IsCueVisible, Is.False);
        }

        [Test]
        public void CueIsVisibleWhenTextIsSetToEmpty() {
            textbox.Text = "Sample Text";
            textbox.Text = "";
            Assert.That(textbox.IsCueVisible, Is.True);
        }

        [Test]
        public void CueIsVisibleWhenTextIsSetToNull() {
            textbox.Text = "Sample Text";
            textbox.Text = null;
            Assert.That(textbox.IsCueVisible, Is.True);
        }

        [Test]
        public void CueIsNotVisibleWhenTextboxHasFocus() {
            textbox.Focus();
            Assert.That(textbox.IsCueVisible, Is.False);
        }

        [Test]
        public void CueIsVisibleAgainWhenLostFocus() {
            var otherTextbox = new TextBox();

            textbox.Focus();

            var scope = FocusManager.GetFocusScope(textbox);
            FocusManager.SetFocusedElement(scope, otherTextbox);

            Assert.That(textbox.IsCueVisible, Is.True);
        }
    }

}
