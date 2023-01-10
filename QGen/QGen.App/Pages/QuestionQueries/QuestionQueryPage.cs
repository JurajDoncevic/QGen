using QGen.App.ViewModels.QuestionQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QGen.App.Pages.QuestionQueries;

public abstract class QuestionQueryPage : Page
{
    public virtual QuestionQueryViewModel BaseViewModel { get; }

    public static QuestionQueryPage CreateEmpty() => (QuestionQueryPage) new Page();
}
