using AutoMapper;
using BLL.DTO;
using BLL.MapperProfiles;
using BLL.Services.Abstract;
using BLL.Services.Impl;
using DAL.UnitOfWork.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Test
{
    public class VoteServiceTests
    {
        [Test]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            var mapper = new MapperConfiguration(cnf => cnf.AddProfile(new VoteMapperProfile()))
                .CreateMapper();

            Assert.Throws<ArgumentNullException>(() => new VoteService(nullUnitOfWork, mapper));
        }

        [Test]
        public void Create_InvalidPolicemanDTO_ThrowValidationException()
        {
            // Arrange
            VoteDTO policeman = new VoteDTO
            {
                Id = 1,
                VoteChoose = 10
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mapper = new MapperConfiguration(cnf => cnf.AddProfile(new VoteMapperProfile()))
                .CreateMapper();
            IVoteService streetService = new VoteService(mockUnitOfWork.Object, mapper);
            // Act
            // Assert
            Assert.Throws<ValidationException>(() => streetService.Create(policeman));
        }
    }
}