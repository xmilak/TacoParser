using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.741158, -86.662532, Taco Bell Huntsville...", -86.662532)]
        [InlineData("30.478469, -87.206052, Taco Bell Pensacola...", -87.206052)]
        [InlineData("32.48032, -85.030559, Taco Bell Phenix Cit...", -85.030559)]
        [InlineData("32.422457, -85.692774, Taco Bell Tuskege...", -85.692774)]
        [InlineData("30.192338, -85.83407, Taco Bell Panama City Beach...", -85.83407)]
        public void ShouldParseLongitude(string line, double expected)
        {

            //Arrange

            var longitude = new TacoParser();

            //Act

            var actual = longitude.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Longitude);
        }



        [Theory]
        [InlineData("34.047374,-84.223918,Taco Bell Alpharetta...", 34.047374)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", 34.996237)]
        [InlineData("30.903723,-84.556037,Taco Bell Bainbridg..", 30.903723)]
        [InlineData("32.472496,-84.987592,Taco Bell Columbus...", 32.472496)]
        [InlineData("33.849014,-87.279978,Taco Bell Jasper...", 33.849014)]
        [InlineData("34.742044,-87.667791,Taco Bell Muscle Shoal...", 34.742044)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Act

            var latitude = new TacoParser();

            //Arrange

            var actual = latitude.Parse(line);

            //Assert

            Assert.Equal(expected, actual.Location.Latitude);


        }

    }
}
