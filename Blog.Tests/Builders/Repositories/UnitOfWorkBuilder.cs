using Blog.Domain.Repositories;
using Moq;

namespace Blog.Tests.Builders.Repositories;

public static class UnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();

        return mock.Object;
    }
}