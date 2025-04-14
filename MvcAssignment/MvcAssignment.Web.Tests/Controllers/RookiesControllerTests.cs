using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcAssignment.Business.Interfaces;
using MvcAssignment.Shared.DTOs;
using MvcAssignment.Shared.Enums;
using MvcAssignment.Web.Controllers;

namespace MvcAssignment.Web.Tests.Controllers
{
    public class RookiesControllerTests
    {
        private Mock<IPersonService> _mockPersonService;
        private RookiesController _controller;
        private List<PersonDTO> _testPeople;

        [SetUp]
        public void Setup()
        {
            _mockPersonService = new Mock<IPersonService>();
            _controller = new RookiesController(_mockPersonService.Object);

            // Setup test data
            _testPeople = [
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "Khánh",
                    LastName = "Vũ",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2003, 10, 14),
                    PhoneNumber = "0928492950",
                    BirthPlace = "Hà Nội",
                    IsGraduated = false
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Văn Chiến",
                    LastName = "Thái",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2003, 07, 29),
                    PhoneNumber = "0928492123",
                    BirthPlace = "Hà Nội",
                    IsGraduated = false
                },
                new PersonDTO
                {
                    Id = 3,
                    FirstName = "Hồng Giang",
                    LastName = "Nguyễn",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2003, 05, 22),
                    PhoneNumber = "0921292950",
                    BirthPlace = "Bắc Ninh",
                    IsGraduated = false
                },
                new PersonDTO
                {
                    Id = 4,
                    FirstName = "Đức Lâm",
                    LastName = "Trần",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1993, 03, 22),
                    PhoneNumber = "0921212950",
                    BirthPlace = "Nam Định",
                    IsGraduated = true
                },
                new PersonDTO
                {
                    Id = 5,
                    FirstName = "Thùy Linh",
                    LastName = "Trần",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2000, 01, 25),
                    PhoneNumber = "0921222950",
                    BirthPlace = "Thái Bình",
                    IsGraduated = true
                }
            ];
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

        [Test]
        public void Index_ShoudReturnViewWithAllPeople()
        {
            // Arrange
            _mockPersonService.Setup(s => s.GetAllMembers()).Returns(_testPeople);

            // Act
            var result = _controller.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(_testPeople));
        }

        [Test]
        public void GetMaleRookies_ShouldReturnViewWithMaleMembers()
        {
            // Arrange
            var males = _testPeople.Where(p => p.Gender == Gender.Male).ToList();
            _mockPersonService.Setup(s => s.GetMaleMembers()).Returns(males);

            // Act
            var result = _controller.GetMaleRookies();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.Multiple(() =>
            {
                Assert.That(viewResult?.Model, Is.EqualTo(males));
                Assert.That(viewResult?.ViewName, Is.EqualTo("Index"));
            });
        }

        [Test]
        public void Oldest_ShouldReturnViewWithOldestMember()
        {
            // Arrange
            var oldest = _testPeople.OrderBy(p => p.DateOfBirth).First();
            _mockPersonService.Setup(s => s.GetOldestMember()).Returns(oldest);

            // Act
            var result = _controller.GetOldestRookie();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(oldest));
        }

        [Test]
        public void Oldest_WhenNotFound_ShouldReturnNotFoundView()
        {
            // Arrange
            _mockPersonService.Setup(s => s.GetOldestMember()).Throws(new KeyNotFoundException("No person found."));

            // Act
            var result = _controller.GetOldestRookie();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.Multiple(() =>
            {
                Assert.That(viewResult?.ViewName, Is.EqualTo("RookiesNotFound"));
                Assert.That(viewResult?.Model, Is.EqualTo("No person found."));
            });
        }

        [Test]
        public void RedirectBasedOnOption_WithEqualOption_ShouldRedirectToGetRookiesByBirthYear()
        {
            // Arrange
            const int testYear = 2000;

            // Act
            var result = _controller.RedirectBasedOnOption(Option.Equal, testYear);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;

            Assert.Multiple(() =>
            {
                Assert.That(redirectResult?.ActionName, Is.EqualTo("GetRookiesByBirthYear"));
                Assert.That(redirectResult?.RouteValues["year"], Is.EqualTo(testYear));
            });
        }

        [Test]
        public void RedirectBasedOnOption_WithGreaterOption_ShouldRedirectToGetRookiesByBirthYearGreater()
        {
            // Arrange
            const int testYear = 2000;

            // Act
            var result = _controller.RedirectBasedOnOption(Option.Greater, testYear);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;

            Assert.Multiple(() =>
            {
                Assert.That(redirectResult?.ActionName, Is.EqualTo("GetRookiesByBirthYearGreater"));
                Assert.That(redirectResult?.RouteValues["year"], Is.EqualTo(testYear));
            });
        }

        [Test]
        public void RedirectBasedOnOption_WithLessOption_ShouldRedirectToGetRookiesByBirthYearLess()
        {
            // Arrange
            const int testYear = 2000;

            // Act
            var result = _controller.RedirectBasedOnOption(Option.Less, testYear);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;

            Assert.Multiple(() =>
            {
                Assert.That(redirectResult?.ActionName, Is.EqualTo("GetRookiesByBirthYearLess"));
                Assert.That(redirectResult?.RouteValues["year"], Is.EqualTo(testYear));
            });
        }

        [Test]
        public void RedirectBasedOnOption_WithUnknownOption_ShouldDefaultToGetRookiesByBirthYear()
        {
            // Arrange
            const int testYear = 2000;
            var unknownOption = (Option)99; // Some value not in the enum

            // Act
            var result = _controller.RedirectBasedOnOption(unknownOption, testYear);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;

            Assert.Multiple(() =>
            {
                Assert.That(redirectResult?.ActionName, Is.EqualTo("GetRookiesByBirthYear"));
                Assert.That(redirectResult?.RouteValues["year"], Is.EqualTo(testYear));
            });
        }

        [Test]
        public void ExportExcel_ShouldReturnFileResult()
        {
            // Arrange
            var testStream = new MemoryStream();
            _mockPersonService.Setup(s => s.WriteMembersToExcel()).Returns(testStream);

            // Act
            var result = _controller.ExportExcel();

            // Assert
            Assert.That(result, Is.InstanceOf<FileStreamResult>());
            var fileResult = result as FileStreamResult;
            Assert.Multiple(() =>
            {
                Assert.That(fileResult?.ContentType, Is.EqualTo("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                Assert.That(fileResult?.FileDownloadName, Is.EqualTo("Rookies.xlsx"));
            });
        }

        [Test]
        public void ExportExcel_WhenNoData_ShouldReturnNotFoundView()
        {
            // Arrange
            var testStream = new MemoryStream();
            _mockPersonService.Setup(s => s.WriteMembersToExcel())
                .Throws(new KeyNotFoundException("No data"));

            // Act
            var result = _controller.ExportExcel();

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result, Is.InstanceOf<ViewResult>());
                Assert.That((result as ViewResult)?.ViewName, Is.EqualTo("RookiesNotFound"));
            });
        }

        [Test]
        public void Create_Get_ShouldReturnView()
        {
            // Act
            var result = _controller.CreateNewRookie();
            
            // Assert
            Assert.Multiple(() =>
            {    
                Assert.That(result, Is.InstanceOf<ViewResult>());
                Assert.That((result as ViewResult)?.ViewName, Is.Null);
            });
        }

        [Test]
        public void Create_Post_WithValidModel_ShouldRedirectToIndex()
        {
            var newPerson = new PersonToCreateDTO
            {
                FirstName = "New",
                LastName = "Rookie",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2001, 07, 19),
                PhoneNumber = "0928212123",
                BirthPlace = "Hà Nội",
                IsGraduated = true
            };

            var createdPerson = new PersonDTO
            {
                Id = 6,
                FirstName = "New",
                LastName = "Rookie",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2001, 07, 19),
                PhoneNumber = "0928212123",
                BirthPlace = "Hà Nội",
                IsGraduated = true
            };

            _mockPersonService.Setup(s => s.CreateNewMember(newPerson))
                .Returns(createdPerson);

            // Act
            var result = _controller.CreateNewRookie(newPerson);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Create_Post_WithInvalidModel_ShouldReturnView()
        {
            // Arrange
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var result = _controller.CreateNewRookie(new PersonToCreateDTO
            {
                FirstName = "New",
                LastName = "Rookie",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2001, 07, 19),
                PhoneNumber = "0928212123",
                BirthPlace = "Hà Nội",
                IsGraduated = true
            });

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void Edit_Get_ShouldReturnViewWithPerson()
        {
            // Arrange
            var person = _testPeople[0];
            _mockPersonService.Setup(s => s.GetMemberById(1)).Returns(person);

            // Act
            var result = _controller.EditRookie(1);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult?.Model, Is.EqualTo(person));
        }

        [Test]
        public void Edit_Post_WithValidModel_ShouldRedirectToIndex()
        {
            // Arrange
            var updatedPerson = _testPeople[0];
            _mockPersonService.Setup(s => s.EditMember(It.IsAny<PersonDTO>())).Returns(updatedPerson);

            // Act
            var result = _controller.EditRookie(updatedPerson);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = result as RedirectToActionResult;
            Assert.That(redirectResult?.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Delete_ShouldRedirectToIndex()
        {
            // Arrange
            _mockPersonService.Setup(s => s.GetMemberById(1)).Returns(_testPeople[0]);

            // Act
            var result = _controller.DeleteRookie(1, "RookiesSuccess");

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var redirectResult = result as ViewResult;
            Assert.That(redirectResult?.ViewName, Is.EqualTo("RookiesSuccess"));
            _mockPersonService.Verify(s => s.DeleteMember(1), Times.Once);
        }
    }
}