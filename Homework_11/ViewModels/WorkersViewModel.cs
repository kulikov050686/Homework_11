using Models;
using System.ComponentModel;

namespace ViewModels
{
    public class WorkersViewModel : BaseClassINPC
    {
        #region Закрытые поля

        BindingList<BaseWorker> _listWorkers;
        Supervisor _supervisor;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Лист работников департамента
        /// </summary>
        public BindingList<BaseWorker> ListWorkers
        {
            get => _listWorkers;
            set => Set(ref _listWorkers, value);
        }

        /// <summary>
        /// Руководитель департамента
        /// </summary>
        public Supervisor Supervisor
        { 
            get => _supervisor; 
            set => Set(ref _supervisor, value); 
        }

        #endregion

        #region Конструктор

        public WorkersViewModel()
        {}

        #endregion
    }
}
