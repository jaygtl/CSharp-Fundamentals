using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAveraegGrade()
        {
        //Given
            var book = new InMemoryBook("");
            book.AddGrade(43.2);
            book.AddGrade(87.65);
        //When
            var result = book.GetStatistics();
        //Then
            Assert.Equal(65.42,result.Average,1);
            Assert.Equal(43.2,result.Lowest);
            Assert.Equal(87.65,result.Highest);
            Assert.Equal('D', result.Letter);
        }
        [Fact]
        public void AddGradeReturnsSuccess()
        {
             //Given
            var book = new InMemoryBook("");
            var expected =  43.2;
        //When
            book.AddGrade(43.2);
        //Then
            Assert.Equal(expected,book.grades[0]);
        }
    }
}