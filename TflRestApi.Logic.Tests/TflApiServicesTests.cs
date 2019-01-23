using NUnit.Framework;

namespace TflRestApi.Logic.Tests
{
    [TestFixture]
    public class TflApiServicesTests
    {
        private readonly ITflApiServices apiServices = new TflApiServices();

        [Test]
        public void Valid_Road_Id_Returns_DisplayName()
        {
            //Arrange
            var roadId = "A2";


            var expectedJsonValue = "A2";

            //Act
            var actualJsonValue = apiServices.GetDisplayName(roadId);
            //Assert
            Assert.AreEqual(expectedJsonValue,actualJsonValue);
        }

        [Test]
        public void Valid_Road_Id_Returns_StatusSeverity()
        {
            //Arrange
            var roadId = "A2";


            var expectedStatusSeverity = "Good";

            //Act
            var actualStatusSeverity = apiServices.GetStatusSeverity(roadId);
            //Assert
            Assert.AreEqual(expectedStatusSeverity, actualStatusSeverity);
        }

        [Test]
        public void Valid_Road_Id_Returns_StatusSeverityDescription()
        {
            //Arrange
            var roadId = "A2";


            var expectedStatusSeverityDescription = "No Exceptional Delays";

            //Act
            var actualStatusSeverityDescription = apiServices.GetStatusSeverity(roadId);
            //Assert
            Assert.AreEqual(expectedStatusSeverityDescription, actualStatusSeverityDescription);
        }
        [Test]
        public void Invalid_Road_Id_Returns_ErrorMessage()
        {
            //Arrange
            var roadId = "A5";


            var expectedErrorMessage = "The following road id is not recognised:" + roadId;

            //Act
            var actualErrorMessage = apiServices.GetMessage(roadId);
            //Assert
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
        [Test]
        public void Invalid_Road_Id_Returns_HttpStatus()
        {
            //Arrange
            var roadId = "A6";


            var expectedHttpStatus = "NotFound";

            //Act
            var actualHttpStatus = apiServices.GetHttpStatus(roadId);
            //Assert
            Assert.AreEqual(expectedHttpStatus, actualHttpStatus);
        }

        [Test]
        public void Invalid_Road_Id_Returns_HttpStatusCode()
        {
            //Arrange
            var roadId = "A7";


            var expectedHttpStatusCode = 404;

            //Act
            var actualHttpStatusCode = apiServices.GetHttpStatusCode(roadId);
            //Assert
            Assert.AreEqual(expectedHttpStatusCode, actualHttpStatusCode);
        }


    }
}
