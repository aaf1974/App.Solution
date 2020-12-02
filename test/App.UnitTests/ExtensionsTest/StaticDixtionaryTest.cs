using App.Domain.Abstraction.Enum;
using App.Infrastructure.Helper;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace App.UnitTests.ExtensionsTest
{

    public class StaticDixtionaryTest
    {
        [Fact(DisplayName = "Проверка StaticDictionaryTypes")]
        public void StaticDictionaryListTest()
        {
            var list = StaticDictionaryTypesHelper.LtcGetEnumCollection<StaticDictionaryTypes>();

            Assert.NotEmpty(list);
        }

        [Fact(DisplayName ="Проверка корректного создания десрипторов статичных справочников")]
        public void StaticDictionaryDescriptor()
        {
            //Arrange
            var list = StaticDictionaryTypesHelper.LtcGetEnumCollection<StaticDictionaryTypes>();

            //Act
            var descriptors = list.GetStaticDitionaryDescriptor();

            //Assert
            descriptors.Should()
                .NotBeEmpty()
                .And.OnlyContain(x => !string.IsNullOrEmpty(x.StaticDictionaryTitle))
                .And.OnlyHaveUniqueItems(x => x.StaticDictionaryClrType)
                .And.OnlyContain(x => x.StaticDictionaryItems.Any());

            Assert.NotEmpty(descriptors);
        }
    }
}
