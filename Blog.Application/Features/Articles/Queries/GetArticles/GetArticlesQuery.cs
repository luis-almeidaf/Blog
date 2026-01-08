using MediatR;

namespace Blog.Application.Features.Articles.Queries.GetArticles;

public class GetArticlesQuery : IRequest<GetArticlesQueryResponse> { }