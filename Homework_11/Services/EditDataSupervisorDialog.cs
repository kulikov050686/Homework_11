using Models;
using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна редактирования данных руководителя
    /// </summary>
    public static class EditDataSupervisorDialog
    {        
        public static Supervisor Show(Supervisor supervisor)
        {
            WindowAddSupervisor addSupervisor = new WindowAddSupervisor();
            AddSupervisorViewModel addSupervisorViewModel = new AddSupervisorViewModel();

            addSupervisorViewModel.Title = "Редактировать данные";
            addSupervisorViewModel.SupervisorName = supervisor.Name;
            addSupervisorViewModel.SupervisorSurname = supervisor.Surname;
            addSupervisorViewModel.SupervisorAge = supervisor.Age;
            addSupervisorViewModel.SupervisorJobTitle = supervisor.JobTitle;
            addSupervisorViewModel.SupervisorSalary = supervisor.Salary;

            addSupervisor.DataContext = addSupervisorViewModel;
            addSupervisor.ShowDialog();

            if(addSupervisorViewModel.AddCancel)
            {
                if(!string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorName) &&
                   !string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorSurname) &&
                   (18 <= addSupervisorViewModel.SupervisorAge && addSupervisorViewModel.SupervisorAge <= 99))
                {
                    return new Supervisor(addSupervisorViewModel.SupervisorName,
                                          addSupervisorViewModel.SupervisorSurname, 
                                          addSupervisorViewModel.SupervisorAge, 
                                          addSupervisorViewModel.SupervisorSalary,
                                          addSupervisorViewModel.SupervisorJobTitle, 
                                          supervisor.PathToDepartment);
                }                
            }

            return supervisor;
        }
    }
}
