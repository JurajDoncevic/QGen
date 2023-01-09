using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QGen.App.Utils;
internal static class Helpers
{
    internal static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        => new ObservableCollection<T>(enumerable);
}
