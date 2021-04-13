using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Infrastructure
{
    /// <summary>
    /// Сортировка
    /// </summary>
    public static class SortList<T>
    {        
        /// <summary>
        /// Сортировка листа работников
        /// </summary>
        /// <param name="list"> Сортируемый лист </param>
        /// <param name="key"> Критерий сортировки </param>
        static public void Sort(ObservableCollection<BaseWorker> list, Func<BaseWorker, T> key)
        {
            ObservableCollection<BaseWorker> TempList = new ObservableCollection<BaseWorker>();
            IEnumerable<BaseWorker> e = list.OrderBy(key);

            TempList.Clear();

            foreach (BaseWorker my in e)
            {
                TempList.Add(my);
                list.Remove(my);
            }

            foreach (BaseWorker my in TempList)
            {
                list.Add(my);
            }
        }        
    }
}
