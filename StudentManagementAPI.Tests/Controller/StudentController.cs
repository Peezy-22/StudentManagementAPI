using Moq;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Controllers;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Tests.Controller
{
    public class StudentControllerTests
    {
        [Fact]
        public async Task GetStudent_ReturnsNotFound_WhenStudentDoesNotExist()
        {
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(repo => repo.GetStudentById(1)).ReturnsAsync((Student)null);

            var controller = new StudentController(mockRepo.Object);
            var result = await controller.GetStudent(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
