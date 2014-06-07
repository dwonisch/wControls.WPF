namespace wControls.WPF.UnitTests {
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
    }
}
