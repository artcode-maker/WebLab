using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebLab.Controllers;
using WebLab.Models;
using WebLab.DAL.Entities;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;

namespace WebLab.Tests
{
    public class LegalServiceControllerTests
    {
        //[Theory]
        //[InlineData(1, 3, 1)]
        //[InlineData(2, 3, 4)]
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            var controllerContext = new ControllerContext();
            var moqHttpContext = new Mock<HttpContext>();

            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;

            var controller = new LegalServiceController() { ControllerContext = controllerContext };

            // Act
            ViewResult result = controller.Index(pageNo:page, group:null) as ViewResult;
            List<LegalService> model = result?.Model as List<LegalService>;

            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].LegalServiceId);
        }
    }

    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<LegalService>.GetModel(TestData.GetLegalServices(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<LegalService>.GetModel(TestData.GetLegalServices(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<LegalService>.GetModel(TestData.GetLegalServices(), page, 3);
            Assert.Equal(id, model[0].LegalServiceId);
        }

        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            var controllerContext = new ControllerContext();
            var moqHttpContext = new Mock<HttpContext>();

            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;

            var controller = new LegalServiceController() { ControllerContext = controllerContext };

            var data = TestData.GetLegalServices();
            controller._legalServices = data;
            var comparer = Comparer<LegalService>.GetComparer((d1, d2) => d1.LegalServiceId.Equals(d2.LegalServiceId));
            // act
            var result = controller.Index(2) as ViewResult;
            var model = result.Model as List<LegalService>;
            // assert
            Assert.Equal(2, model.Count);
            Assert.Equal(data[2], model[0], comparer);
        }
    }

    public class TestData
    {
        public static List<LegalService> GetLegalServices() =>
            new List<LegalService>
            {
                new LegalService
                {
                    LegalServiceId = 1,
                    Name = "������������ �� ��������� �����",
                    Description = "����������� �� �������� ����������� ����� � ������� ���������",
                    Price = 50M,
                    LegalServiceGroupId = 1,
                    Image = "consult.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 2,
                    Name = "������������ �� ��������� �����",
                    Description = "����������� �� �������� ��������� �� �������� ��� ����",
                    Price = 50M,
                    LegalServiceGroupId = 1,
                    Image = "consult.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 3,
                    Name = "����������� �������� ��������� �� ��������� �����",
                    Description = "������� ��������� �� �����, ����������� �� �������� ��������������",
                    Price = 200M,
                    LegalServiceGroupId = 2,
                    Image = "document.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 4,
                    Name = "����������� �������� ��������� �� ��������� �����",
                    Description = "������� ��������� �� �����, ����������� �� �������� ��������������",
                    Price = 200M,
                    LegalServiceGroupId = 2,
                    Image = "document.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 5,
                    Name = "����������������� �� �������� ����� � ����",
                    Description = "������� � �������� ������������� �� �������� ����� � ����",
                    Price = 250M,
                    LegalServiceGroupId = 3,
                    Image = "court.jpg"
                },
                new LegalService
                {
                    LegalServiceId = 6,
                    Name = "����������������� �� �������� ����� � ����",
                    Description = "������� � �������� ������������� �� �������� ����� � ����",
                    Price = 250M,
                    LegalServiceGroupId = 3,
                    Image = "court.jpg"
                }
            };

        public static IEnumerable<object[]> Params()
        {
            yield return new object[] { 1, 3, 1 };
            yield return new object[] { 2, 3, 4 };
        }
    }
}
