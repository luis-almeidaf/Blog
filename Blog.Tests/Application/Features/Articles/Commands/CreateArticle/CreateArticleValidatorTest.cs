using Blog.Application.Features.Articles.Commands.CreateArticle;

namespace Blog.Tests.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleValidatorTest
{
    [Fact]
    public void ResultShouldBeTrueWhenCommandIsValid()
    {
        var validator = new CreateArticleValidator();

        var command = new CreateArticleCommand
        {
            Title = "Test Title",
            Content = "Test Content",
            TagNames = ["Tag1, Tag2,Tag3"]
        };

        var result = validator.Validate(command);

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ResultShouldBeFalseWhenTitleIsEmpty(string title)
    {
        var validator = new CreateArticleValidator();

        var command = new CreateArticleCommand
        {
            Title = title,
            Content = "Test Content",
            TagNames = ["Tag1, Tag2,Tag3"]
        };

        var result = validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, x => x.ErrorMessage.Equals("Title is required"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ResultShouldBeFalseWhenContentIsEmpty(string content)
    {
        var validator = new CreateArticleValidator();

        var command = new CreateArticleCommand
        {
            Title = "Test Title",
            Content = content,
            TagNames = ["Tag1, Tag2,Tag3"]
        };

        var result = validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, x => x.ErrorMessage.Equals("Content is required"));
    }
}