using QGen.Base;
using QGen.Domain.Queries;

namespace QGen.Providers;

public interface IQuestionProvider
{
    public Task<Result<string>> FetchQuestion(QuestionQuery questionQuery);
}
