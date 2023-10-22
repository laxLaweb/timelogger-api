using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TimeLogger.Access;
using TimeLogger.Dto;
using TimeLogger.Entities;
using TimeLogger.Services;
using TimeLogger.Services.Impl;
using Xunit;

namespace TimeLogger.UnitTests.Services.Impl
{
    public class TimeRegisterServiceTests
    {
        private readonly Mock<ITimeRegisterAccess> timeRegisterAccessMock;
        private readonly ITimeRegisterService timeRegisterService;

        public TimeRegisterServiceTests()
        {
            timeRegisterAccessMock = new Mock<ITimeRegisterAccess>();

            timeRegisterService = new TimeRegisterService(timeRegisterAccessMock.Object);
        }

        [Fact]
        public async Task AddTimeOnProject_Did_Not_Exists()
        {
            var dto = new TimeRegisterDto()
            {
                Date = "2023-10-17",
                Hours = 5
            };
            int projectId = 1;

            TimeRegister returnValue = null;

            timeRegisterAccessMock.Setup(x => x.GetByProjectIdAndDate(projectId, dto.Date)).ReturnsAsync(returnValue);
            await timeRegisterService.AddTimeOnProject(1, dto);

            timeRegisterAccessMock.Verify(x => x.GetByProjectIdAndDate(projectId, dto.Date), Times.Once);
            timeRegisterAccessMock.Verify(x => x.AddTimeOnProject(projectId, dto.Date, dto.Hours), Times.Once);
            timeRegisterAccessMock.Verify(x => x.Save(It.IsAny<TimeRegister>()), Times.Never);
        }

        [Fact]
        public async Task AddTimeOnProject_Did_Already_Exists()
        {
            var dto = new TimeRegisterDto()
            {
                Date = "2023-10-17",
                Hours = 5
            };
            int projectId = 1;

            TimeRegister returnValue = new TimeRegister()
            {
                Date = dto.Date,
                Hours = 3,
                ProjectId = projectId
            };

            timeRegisterAccessMock.Setup(x => x.GetByProjectIdAndDate(projectId, dto.Date)).ReturnsAsync(returnValue);
            await timeRegisterService.AddTimeOnProject(1, dto);

            timeRegisterAccessMock.Verify(x => x.GetByProjectIdAndDate(projectId, dto.Date), Times.Once);
            timeRegisterAccessMock.Verify(x => x.AddTimeOnProject(projectId, dto.Date, dto.Hours), Times.Never);
            timeRegisterAccessMock.Verify(x => x.Save(It.IsAny<TimeRegister>()), Times.Once);
        }
    }
}
