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
            if (supervisor.EmployeePosition == EmployeePosition.GeneralDirector) return EditGeneralDirector(supervisor);
            if (supervisor.EmployeePosition == EmployeePosition.DeputyDirector) return EditDeputyDirector(supervisor);
            if (supervisor.EmployeePosition == EmployeePosition.ChiefAccountant) return EditChiefAccountant(supervisor);

            return EditSupervisor(supervisor);
        }

        /// <summary>
        /// Редактирование данных главного бухгалтера
        /// </summary>        
        private static ChiefAccountant EditChiefAccountant(Supervisor supervisor)
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

            if (addSupervisorViewModel.AddCancel)
            {
                if (!string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorName) &&
                   !string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorSurname) &&
                   (18 <= addSupervisorViewModel.SupervisorAge && addSupervisorViewModel.SupervisorAge <= 99))
                {
                    return new ChiefAccountant(addSupervisorViewModel.SupervisorName,
                                               addSupervisorViewModel.SupervisorSurname,
                                               addSupervisorViewModel.SupervisorAge,
                                               addSupervisorViewModel.SupervisorSalary,
                                               addSupervisorViewModel.SupervisorJobTitle);
                }
            }

            return null;
        }

        /// <summary>
        /// Редактирование данных заместителя генерального директора
        /// </summary>        
        private static DeputyDirector EditDeputyDirector(Supervisor supervisor)
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

            if (addSupervisorViewModel.AddCancel)
            {
                if (!string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorName) &&
                   !string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorSurname) &&
                   (18 <= addSupervisorViewModel.SupervisorAge && addSupervisorViewModel.SupervisorAge <= 99))
                {
                    return new DeputyDirector(addSupervisorViewModel.SupervisorName,
                                               addSupervisorViewModel.SupervisorSurname,
                                               addSupervisorViewModel.SupervisorAge,
                                               addSupervisorViewModel.SupervisorSalary,
                                               addSupervisorViewModel.SupervisorJobTitle);
                }
            }

            return null;
        }

        /// <summary>
        /// Редактирование данных генерального директора
        /// </summary>        
        private static GeneralDirector EditGeneralDirector(Supervisor supervisor)
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

            if (addSupervisorViewModel.AddCancel)
            {
                if (!string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorName) &&
                   !string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorSurname) &&
                   (18 <= addSupervisorViewModel.SupervisorAge && addSupervisorViewModel.SupervisorAge <= 99))
                {
                    return new GeneralDirector(addSupervisorViewModel.SupervisorName,
                                               addSupervisorViewModel.SupervisorSurname,
                                               addSupervisorViewModel.SupervisorAge,
                                               addSupervisorViewModel.SupervisorSalary,
                                               addSupervisorViewModel.SupervisorJobTitle);
                }
            }

            return null;
        }

        /// <summary>
        /// Редактирование данных руководителя департамента
        /// </summary>        
        private static Supervisor EditSupervisor(Supervisor supervisor)
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

            if (addSupervisorViewModel.AddCancel)
            {
                if (!string.IsNullOrWhiteSpace(addSupervisorViewModel.SupervisorName) &&
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

            return null;
        }
    }
}
