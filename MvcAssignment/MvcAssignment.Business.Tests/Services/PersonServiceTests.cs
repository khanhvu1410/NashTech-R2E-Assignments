using Moq;
using MvcAssignment.Business.Services;
using MvcAssignment.Data.Interfaces;
using MvcAssignment.Data.Models;
using MvcAssignment.Shared.DTOs;
using MvcAssignment.Shared.Enums;

namespace MvcAssignment.Business.Tests.Services
{
    public class PersonServiceTests
    {
        private Mock<IPersonRepository> _mockPersonRepository;  
        private PersonService _personService;
        private List<Person> _testPeople;

        [SetUp]
        public void Setup()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _personService = new PersonService(_mockPersonRepository.Object);

            // Setup test data
            _testPeople = [
                new Person
                {
                    Id = 1,
                    FirstName = "Khánh",
                    LastName = "Vũ",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2003, 10, 14),
                    PhoneNumber = "0928492950",
                    BirthPlace = "Hà Nội",
                    IsGraduated = false,
                    CreatedDate = new DateTime(2025, 04, 01)
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Văn Chiến",
                    LastName = "Thái",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(2003, 07, 29),
                    PhoneNumber = "0928492123",
                    BirthPlace = "Hà Nội",
                    IsGraduated = false,
                    CreatedDate = new DateTime(2025, 04, 01)
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Hồng Giang",
                    LastName = "Nguyễn",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2003, 05, 22),
                    PhoneNumber = "0921292950",
                    BirthPlace = "Bắc Ninh",
                    IsGraduated = false,
                    CreatedDate = new DateTime(2025, 04, 01)
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Đức Lâm",
                    LastName = "Trần",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1993, 03, 22),
                    PhoneNumber = "0921212950",
                    BirthPlace = "Nam Định",
                    IsGraduated = true,
                    CreatedDate = new DateTime(2025, 04, 01)
                },
                new Person
                {
                    Id = 5,
                    FirstName = "Thùy Linh",
                    LastName = "Trần",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(2000, 01, 25),
                    PhoneNumber = "0921222950",
                    BirthPlace = "Thái Bình",
                    IsGraduated = true,
                    CreatedDate = new DateTime(2025, 04, 01)
                }
            ];

            // Setup mock repository
            _mockPersonRepository.Setup(repo => repo.GetAll()).Returns(_testPeople);
            _mockPersonRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                .Returns<int>(id => _testPeople.FirstOrDefault(p => p.Id == id));
        }

        [Test]
        public void GetAllMembers_ShouldReturnAllPeople()
        {
            // Act
            var result = _personService.GetAllMembers();

            // Assert
            Assert.That(result, Has.Count.EqualTo(5));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].FirstName, Is.EqualTo("Khánh"));
                Assert.That(result[1].FirstName, Is.EqualTo("Văn Chiến"));
                Assert.That(result[2].FirstName, Is.EqualTo("Hồng Giang"));
                Assert.That(result[3].FirstName, Is.EqualTo("Đức Lâm"));
                Assert.That(result[4].FirstName, Is.EqualTo("Thùy Linh"));
            });
        }

        [Test]
        public void GetMaleMembers_ShouldReturnOnlyMales()
        {
            // Act
            var result = _personService.GetMaleMembers();

            // Assert
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result.All(p => p.Gender == Gender.Male), Is.True);
        }

        [Test]
        public void GetOldestMember_ShouldReturnPersonWithEarliestBirthDate()
        {
            // Act 
            var result = _personService.GetOldestMember();

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("Đức Lâm"));
        }

        [Test]
        public void GetOldestMember_WhenNoPeople_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            _mockPersonRepository.Setup(repo => repo.GetAll()).Returns([]);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _personService.GetOldestMember());
        }

        [Test]
        public void GetFullnames_ShouldReturnCorrectFullnames()
        {
            // Act
            var result = _personService.GetFullnames();


            // Assert
            Assert.That(result, Has.Count.EqualTo(5));
            Assert.Multiple(() =>
            {   
                Assert.That(result[0], Is.EqualTo("Vũ Khánh"));
                Assert.That(result[1], Is.EqualTo("Thái Văn Chiến"));
                Assert.That(result[2], Is.EqualTo("Nguyễn Hồng Giang"));
                Assert.That(result[3], Is.EqualTo("Trần Đức Lâm"));
                Assert.That(result[4], Is.EqualTo("Trần Thùy Linh"));
            });
        }

        [Test]
        public void GetFullnames_WhenNoPeople_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            _mockPersonRepository.Setup(repo => repo.GetAll()).Returns([]);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _personService.GetFullnames());
        }

        [Test]
        public void GetMembersByBirthYear_ShouldReturnCorrectPeople()
        {
            // Act
            var result = _personService.GetMembersByBirthYear(Option.Equal, 2000);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].FirstName, Is.EqualTo("Thùy Linh"));
        }

        [Test]
        public void GetMembersByBirthYearGreater_ShouldReturnCorrectPeople()
        {
            // Act
            var result = _personService.GetMembersByBirthYear(Option.Greater, 2000);

            // Assert
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(result[0].FirstName, Is.EqualTo("Khánh"));
                Assert.That(result[1].FirstName, Is.EqualTo("Văn Chiến"));
                Assert.That(result[2].FirstName, Is.EqualTo("Hồng Giang"));
            });
        }

        [Test]
        public void GetMembersByBirthYearLess_ShouldReturnCorrectPeople()
        {
            // Act
            var result = _personService.GetMembersByBirthYear(Option.Less, 2000);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].FirstName, Is.EqualTo("Đức Lâm"));
        }

        [Test]
        public void WriteMemberToExcel_ShouldReturnValidMemoryStream()
        {
            // Act
            var result = _personService.WriteMembersToExcel();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.GreaterThan(0));
        }

        [Test]
        public void WriteMembersToExcel_WhenNoPeople_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            _mockPersonRepository.Setup(repo => repo.GetAll()).Returns([]);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _personService.WriteMembersToExcel());
        }

        [Test] 
        public void CreateNewMember_ShouldAddNewPerson()
        {
            // Arrange
            var newPersonDto = new PersonToCreateDTO
            {
                FirstName = "Diệc Phi",
                LastName = "Lưu",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1995, 7, 7),
                PhoneNumber = "0955555555",
                BirthPlace = "Trùng Khánh",
                IsGraduated = true
            };

            _mockPersonRepository.Setup(repo => repo.Create(It.IsAny<Person>()))
                .Returns<Person>(p =>
                {
                    p.Id = 6;
                    return p;
                });
            
            // Act
            var result = _personService.CreateNewMember(newPersonDto);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(6));
                Assert.That(result.FirstName, Is.EqualTo("Diệc Phi"));
            });
            _mockPersonRepository.Verify(repo => repo.Create(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void EditMember_ShouldUpdateExistingPerson()
        {
            // Arrange
            var updatedPersonDto = new PersonDTO
            {
                Id = 1,
                FirstName = "Khánh Vy",
                LastName = "Vũ",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2006, 12, 10),
                PhoneNumber = "0928123123",
                BirthPlace = "Hà Nội",
                IsGraduated = false
            };

            _mockPersonRepository.Setup(repo => repo.Update(It.IsAny<Person>()))
                .Returns<Person>(p => p);
            
            // Act 
            var result = _personService.EditMember(updatedPersonDto);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("Khánh Vy"));
            _mockPersonRepository.Verify(repo => repo.Update(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void EditMember_WhenPersonNotFound_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var updatedPersonDto = new PersonDTO 
            { 
                Id = 99,
                FirstName = "Khánh Vy",
                LastName = "Vũ",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2006, 12, 10),
                PhoneNumber = "0928123123",
                BirthPlace = "Hà Nội",
                IsGraduated = false
            };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _personService.EditMember(updatedPersonDto));
        }

        [Test]
        public void GetMemberById_ShouldReturnCorrectPerson()
        {
            // Act 
            var result = _personService.GetMemberById(2);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("Văn Chiến"));
        }

        [Test]
        public void GetMemberById_WhenPersonNotFound_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _personService.GetMemberById(99));
        }

        [Test]
        public void DeleteMember_ShouldCallRepositoryDelete()
        {
            // Act
            _personService.DeleteMember(1);

            // Assert
            _mockPersonRepository.Verify(repo => repo.Delete(1), Times.Once);
        }

        [Test]
        public void DeleteMember_WhenPersonNotFound_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => _personService.DeleteMember(99));
        }
    }
}