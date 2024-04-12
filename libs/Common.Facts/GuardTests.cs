namespace Common;

public class GuardTests
{
    [Fact]
    public void DoesNotThrowOnValidStringArgument()
    {
        const string argument = "Argument";

        var guard = () => Guard.NotNullOrEmpty(() => argument);
        guard.Should().NotThrow();
    }

    [Fact]
    public void DetectsNullStringArgument()
    {
        const string? argument = default;

        var guard = () => Guard.NotNullOrEmpty(() => argument!);
        guard.Should().Throw<ArgumentException>().WithMessage("Parameter must be null");
    }

    [Fact]
    public void DetectsEmptyStringArgument()
    {
        const string argument = "";

        var guard = () => Guard.NotNullOrEmpty(() => argument);
        guard.Should().Throw<ArgumentException>().WithMessage("Parameter must be empty");
    }

    [Fact]
    public void DoesNotThrowOnValidArgument()
    {
        const int argument = 4;

        var guard = () => Guard.Argument(() => argument < 5, "Argument must be smaller than 5");
        guard.Should().NotThrow();
    }

    [Fact]
    public void DetectsInvalidArgument()
    {
        const int argument = 5;

        var guard = () => Guard.Argument(() => argument < 5, "Argument must be smaller than 5");
        guard.Should().Throw<ArgumentException>().WithMessage("Argument must be smaller than 5");
    }

    [Fact]
    public void DoesNotThrowOnValidState()
    {
        const int state = 4;

        var guard = () => Guard.State(() => state < 5, "State must be smaller than 5");
        guard.Should().NotThrow();
    }

    [Fact]
    public void DetectsInvalidState()
    {
        const int state = 5;

        var guard = () => Guard.Argument(() => state < 5, "State must be smaller than 5");
        guard.Should().Throw<ArgumentException>().WithMessage("State must be smaller than 5");
    }
}
