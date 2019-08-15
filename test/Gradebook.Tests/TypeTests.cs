using System;
using Xunit;

namespace Gradebook.Tests
{
    public delegate string WriteToLogDelegate(string logMessage);
    public class TypeTests
    {
        int count; 
        [Fact]
        public void TestDelegateCallPoint()
        {
            WriteToLogDelegate logDelegate;
            logDelegate = new WriteToLogDelegate(ReturnMessageForDeletegate); //OR logDelegate = ReturnMessageForDelegate;
            logDelegate+=ReturnMessageForDeletegate;//add new method to call using the delegate 
            logDelegate+=IncrementCount;//add another method to be called to add delegate
            var result = logDelegate("Hello!");//this would call all the methods which are mentioned above (it only calls those method whose return type and method signature matches the delegate)
            //Assert.Equal("Hello!", result);// FOR single delegate(calling one method using delegate)
            Assert.Equal(3,count); //FOR counting the number of methods called by delegate (multicasting delegate)
        }
        string IncrementCount(string message)
        {
            count++;
            return message;
        }
        string ReturnMessageForDeletegate(string message)
        {
            count++;
            return message;
        }
        [Fact]
        public void StringsBehaveLikeValueType()
        {
            string name = "Jay";
            var upperName = MakeUppercase(name);
            Assert.Equal("Jay",name);
            Assert.Equal("JAY",upperName);
        }

        private string MakeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(4);
            Assert.Equal(3,x);
        }

        private void SetInt(int x)
        {
            x = 4; 
        }

        private int GetInt()
        {
            return 3;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");
            Assert.Equal("Book1",book1.Name);
            Assert.Equal("Book2",book2.Name);
            Assert.NotSame(book1,book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1,"NewName");
            Assert.Equal("NewName",book1.Name);
        }

        private void SetName(InMemoryBook book,  string name)
        {
            book.Name = name;
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(book1,"NewName");
            Assert.Equal("Book1",book1.Name);
        }

        private void GetBookSetName(InMemoryBook book,  string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpIsPassByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetName(out book1,"NewName");
            Assert.Equal("NewName",book1.Name);
        }

        private void GetBookSetName(out InMemoryBook book,  string name)
        {
            book = new InMemoryBook(name);
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}