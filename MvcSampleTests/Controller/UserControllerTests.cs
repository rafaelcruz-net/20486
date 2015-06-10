using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcSample.Infra.Repository.Interfaces;
using MvcSample.Controllers;
using System.Collections.Generic;
using MvcSample.Models;
using System.Web.Mvc;
using FluentAssertions;

namespace MvcSampleTests.Controller
{
    [TestClass]
    public class UserControllerTests
    {
        private Mock<IUserRepository> userRepository;
        private UserController userController;

        [TestInitialize]
        public void Setup()
        {
            this.userRepository = new Mock<IUserRepository>();
            userController = new UserController(this.userRepository.Object);
        }

        

        [TestMethod]
        public void IndexTest()
        {
            //Arrange
            List<User> userList = new List<User>(){
                new User(){
                    CreationDate = DateTime.Now,
                    Email = "joao@teste.com.br",
                    Id = 1,
                    Name = "João da silva",
                    Password = "123456",
                    UserName = "jsilva"
                },
                new User(){
                    CreationDate = DateTime.Now,
                    Email = "fulano@teste.com.br",
                    Id = 1,
                    Name = "Fulano da silva",
                    Password = "123456",
                    UserName = "fsilva"
                },
            };

            //Act
            this.userRepository.Setup(x => x.GetAll()).Returns(userList);
            var expect = userController.Index();


            //Assertions
            (expect as ViewResult).Model.Should().BeOfType<List<User>>();
            ((expect as ViewResult).Model as List<User>).Should().HaveCount(2);

        }

        [TestMethod]
        public void EditTest()
        {
            //Arrange
            User user = new User()
                {
                    CreationDate = DateTime.Now,
                    Email = "joao@teste.com.br",
                    Id = 1,
                    Name = "João da silva",
                    Password = "123456",
                    UserName = "jsilva"
                };
               

            //Act
            var id = 1;
            this.userRepository.Setup(x => x.GetById(id)).Returns(user);
            var expect = userController.Edit(id);

            //Assertions
            (expect as ViewResult).Model.Should().BeOfType<User>().And.NotBeNull();

        }


        [TestMethod]
        public void EditPostTest()
        {
            //Arrange
            User user = new User()
            {
                CreationDate = DateTime.Now,
                Email = "joao@teste.com.br",
                Id = 1,
                Name = "João da silva",
                Password = "123456",
                UserName = "jsilva"
            };

            List<User> userList = new List<User>(){
                new User(){
                    CreationDate = DateTime.Now,
                    Email = "joao@teste.com.br",
                    Id = 1,
                    Name = "João da silva",
                    Password = "123456",
                    UserName = "jsilva"
                },
                new User(){
                    CreationDate = DateTime.Now,
                    Email = "fulano@teste.com.br",
                    Id = 1,
                    Name = "Fulano da silva",
                    Password = "123456",
                    UserName = "fsilva"
                },
            };


            //Act
            var id = 1;
            this.userRepository.Setup(x => x.Update(user));
            this.userRepository.Setup(x => x.GetAll()).Returns(userList);

            var expect = userController.Edit(user);

            //Assertions
            (expect as ViewResult).Model.Should().BeOfType<List<User>>();
            ((expect as ViewResult).Model as List<User>).Should().HaveCount(2);

        }


    }
}
