﻿using QGen.App.ViewModels.QuestionQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QGen.App.Pages.QuestionQueries;
/// <summary>
/// Interaction logic for MultiChoiceQuestionQueryPage.xaml
/// </summary>
public partial class MultiChoiceQuestionQueryPage : QuestionQueryPage
{
    public MultiChoiceQuestionQueryViewModel ViewModel { get; private set; }
    public override QuestionQueryViewModel BaseViewModel => ViewModel;

    public MultiChoiceQuestionQueryPage(MultiChoiceQuestionQueryViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }
}
