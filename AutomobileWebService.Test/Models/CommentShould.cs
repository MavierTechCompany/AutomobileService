using AutomobileWebService.Business_Logic.Extras.Custom_Exceptions;
using AutomobileWebService.Business_Logic.Models;
using AutomobileWebService.Test.CustomAttributes;
using Moq;
using System;
using Xunit;

namespace AutomobileWebService.Test.Models
{
    public class CommentShould
    {
        [Theory]
        [CommentValidData]
        public void CreateItself(string commentText)
        {
            //Arrange
            var userMock = Mock.Of<User>(x => x.Id == 1);
            var projectMock = Mock.Of<Project>(x => x.Id == 1);

            //Act
            var sut = new Comment(commentText, userMock, projectMock);

            //Assert
            Assert.Equal(commentText, sut.CommentText);
            Assert.Equal(userMock.Id, sut.CommenterId);
            Assert.Equal(projectMock.Id, sut.ProjectId);
        }

        [Theory]
        [CommentNotValidData]
        public void ThrowsExceptionDuringCreation(string commentText)
        {
            //Arrange
            var userMock = Mock.Of<User>(x => x.Id == 1);
            var projectMock = Mock.Of<Project>(x => x.Id == 1);

            //Act and Assert
            Assert.Throws<ForbiddenValueException>(() => new Comment(commentText, userMock, projectMock));
        }

        [Fact]
        public void DeleteItself()
        {
            //Arrange
            var userMock = Mock.Of<User>(x => x.Id == 1);
            var projectMock = Mock.Of<Project>(x => x.Id == 1);
            var sut = new Comment("This is test comment!", userMock, projectMock);

            //Act
            sut.Delete();

            //Assert
            Assert.Equal(true, sut.Deleted);
        }
    }
}