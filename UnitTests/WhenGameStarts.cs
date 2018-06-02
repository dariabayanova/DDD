using System.Collections.Generic;
using Domain;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WhenGameStarts
    {
        [Test]
        // TODO: Сомнительный тест. Зачем вы с него начали?
        // TODO: Хотели сделать Factory для колонки беклога
        public void GameGenerates10Cards()
        {
            var gameMock = new Mock<Game>();
            gameMock.Setup(_ => _.GenerateCards(10));

            gameMock.Object.Start();

            gameMock.Verify(_ => _.GenerateCards(10), Times.Once);
        }
    }
}