using BlogApplication.Application.Services;
using FluentAssertions;

namespace tests.BlogApplication.Application.Services.ValidateDataService;

public class RemoveBlankSpaces : DataValidationService
{
    /// <summary>
    /// CheckPasswordWhenGetAWeakSetup
    /// </summary>
    [Fact]
    public void RemoveBlankSpacesShouldReturnTrue()
    {
        var result = RemoveBlanks("     esto   es     una     prueba      ");
        result.Should().Be("esto es una prueba");
    }
}