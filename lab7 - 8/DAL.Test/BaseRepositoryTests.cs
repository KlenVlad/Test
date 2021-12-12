using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

using Moq;
using NUnit.Framework;

namespace DAL.Test
{
    public class BaseRepositoryTests
    {
        [Test]
        public void Create_InputInstance_CalledAddMethodOfDbSetWithInstance()
        {
            //Установка
            var mockContext = new Mock<VoteContext>(); 
            var mockDbSet = new Mock<DbSet<Vote>>();
            mockContext
                .Setup(c => c.Set<Vote>())
                .Returns(mockDbSet.Object);

            var repository = new VoteRepository(mockContext.Object);

            Vote expected = new Mock<Vote>().Object;

            //Действие
            repository.Create(expected);

            //Проверка
            mockDbSet.Verify(dbSet => dbSet.Add(expected), Times.Once());
        }

        [Test]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            var mockContext = new Mock<VoteContext>();
            var mockDbSet = new Mock<DbSet<Vote>>();
            mockContext
                .Setup(context =>
                    context.Set<Vote>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new VoteRepository(mockContext.Object);

            Vote expected = new Vote() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.Id)).Returns(expected);

            //Act
            repository.Delete(expected.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expected.Id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expected
                    ), Times.Once());
        }

        [Test]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            var mockContext = new Mock<VoteContext>();
            var mockDbSet = new Mock<DbSet<Vote>>();
            mockContext
                .Setup(context =>
                    context.Set<Vote>())
                .Returns(mockDbSet.Object);

            Vote expected = new Vote() { Id = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.Id))
                    .Returns(expected);
            var repository = new VoteRepository(mockContext.Object);

            //Act
            var actual = repository.Get(expected.Id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expected.Id
                    ), Times.Once());
            Assert.AreEqual(expected, actual);
        }
    }
}