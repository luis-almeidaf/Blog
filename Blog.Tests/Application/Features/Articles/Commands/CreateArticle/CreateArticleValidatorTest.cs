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
            Summary =  "Test Summary",
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
            Summary =  "Test Summary",
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
            Summary =  "Test Summary",
            Content = content,
            TagNames = ["Tag1, Tag2,Tag3"]
        };

        var result = validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, x => x.ErrorMessage.Equals("Content is required"));
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ResultShouldBeFalseWhenSummaryIsEmpty(string summary)
    {
        var validator = new CreateArticleValidator();

        var command = new CreateArticleCommand
        {
            Title = "Test Title",
            Summary =  summary,
            Content = "Test content",
            TagNames = ["Tag1, Tag2,Tag3"]
        };

        var result = validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, x => x.ErrorMessage.Equals("Summary is required"));
    }
}