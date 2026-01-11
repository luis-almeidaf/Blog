using Blog.Application.Features.Articles.Commands.EditArticle;

namespace Blog.Tests.Application.Features.Articles.Commands.EditArticle;

public class EditArticleValidatorTest
{
    [Fact]
    public void ResultShouldBeTrueWhenCommandIsValid()
    {
        var validator = new EditArticleValidator();

        var command = new EditArticleViewModel
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
        var validator = new EditArticleValidator();

        var command = new EditArticleViewModel()
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
        var validator = new EditArticleValidator();

        var command = new EditArticleViewModel
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
        var validator = new EditArticleValidator();

        var command = new EditArticleViewModel
        {
            Title = "Test Title",
            Summary =  summary,
            Content = "Test Content",
            TagNames = ["Tag1, Tag2,Tag3"]
        };

        var result = validator.Validate(command);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, x => x.ErrorMessage.Equals("Summary is required"));
    }
}