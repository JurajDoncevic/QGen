using QGen.Domain.Queries;
using System.Collections.ObjectModel;

namespace QGen.App.ViewModels;

public class QuestionGenerationViewModel : BaseViewModel
{
    public ObservableCollection<(QuestionTypes QuestionType, string DisplayName)> AvailableQuestionTypes { get; private set; } = new ObservableCollection<(QuestionTypes QuestionType, string DisplayName)>
    {
        (QuestionType: QuestionTypes.OPEN, DisplayName: "Open"),
        (QuestionType: QuestionTypes.YES_NO, DisplayName: "Yes-No"),
        (QuestionType: QuestionTypes.MULTI_CHOICE, DisplayName: "Multi-choice"),
        (QuestionType: QuestionTypes.SINGLE_WORD, DisplayName: "Single word answer"),
        (QuestionType: QuestionTypes.FILL_BLANKS, DisplayName: "Fill blanks")
    };

    public QuestionTypes SelectedQuestionType { get; set; }
}
