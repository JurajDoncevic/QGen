using QGen.App.Commands;
using System.Collections.ObjectModel;

namespace QGen.App.ViewModels;
public class GeneratedQuestionsViewModel : BaseViewModel
{
    public ObservableCollection<string> GeneratedQuestions { get; private set; } = new ObservableCollection<string>();
    public RelayCommand ClearHistoryCommand => new RelayCommand(o => ClearQuestions());

    public GeneratedQuestionsViewModel()
    {
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
        GeneratedQuestions.Add("Sastavi pitanje iz aaa aaa iz teme \"aaaa\". Neka je pitanje oblika nadopune rečenice. Nadopunjuje se s jednom ili dvije riječi.");
    }

    public void AddQuestion(string question)
    {
        GeneratedQuestions.Add(question);
    }

    public void RemoveQuestion(string question)
    {
        GeneratedQuestions.Remove(question);
    }

    public void RemoveQuestion(int index)
    {
        if(index > -1 && index < GeneratedQuestions.Count)
        {
            GeneratedQuestions.RemoveAt(index);
        }
    }

    public void ClearQuestions()
    {
        GeneratedQuestions.Clear();
    }
}
