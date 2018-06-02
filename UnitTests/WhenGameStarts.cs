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
        public void GameGenerates10_000Cards()
        {
            var gameMock = new Mock<Game>();
            gameMock.Setup(_ => _.GenerateCards(10_000));

            gameMock.Object.Start();

            gameMock.Verify(_ => _.GenerateCards(10_000), Times.Once);
        }
    }
}