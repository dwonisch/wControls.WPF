using System;
using NUnit.Framework;

namespace wControls.WPF.UnitTests {
    
    [TestFixture]
    public class CommandTests {
        [Test]
        public void CommandDefaultConstructor() {
            int wasExecuted = 0;
            var command = new Command<object>(x => wasExecuted++);

            command.Execute(null);

            Assert.That(wasExecuted, Is.EqualTo(1));
        }

        [Test]
        public void CommandCalledWithNullAction() {
            Assert.Throws<ArgumentNullException>(() => new Command<object>(null));
        }

        [Test]
        public void CommandChecksCanExecute() {
            var command = new Command<object>(x => { }, y => true);
            Assert.That(command.CanExecute(null), Is.True);
        }

        [Test]
        public void CommandCanExecuteWhenFunctionIsNull() {
            var command = new Command<object>(x => { }, null);
            Assert.That(command.CanExecute(null), Is.True);
        }

        [Test]
        public void CanExecuteChanged() {
            var eventRaised = 0;
            var command = new Command<object>(x => { }, null);
            command.CanExecuteChanged += (sender, args) => eventRaised++;
            command.RaiseCanExecuteChanged();

            Assert.That(eventRaised, Is.EqualTo(1));
        }
    }
}
