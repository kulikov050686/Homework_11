using Models;
using System;
using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна добавить руководителя
    /// </summary>
    public static class AddSupervisorDialog
    {
        public static Supervisor Show(EmployeePosition employeePosition, string pathToDepartment = null)
        {
            switch (employeePosition)
            {                
                case EmployeePosition.Supervisor:

                    if(string.IsNullOrWhiteSpace(pathToDepartment))
                    {
                        throw new ArgumentNullException("Путь до департамента не может быть пустым!!!");
                    }

                    WindowAddSupervisor windowAddSupervisor = new WindowAddSupervisor();
                    AddSupervisorViewModel addSupervisorViewModel = new AddSupervisorViewModel();

                    addSupervisorViewModel.Title = "Добавить Руководителя";
                    addSupervisorViewModel.SupervisorJobTitle = "Руководитель департамента";
                    windowAddSupervisor.DataContext = addSupervisorViewModel;

                    windowAddSupervisor.ShowDialog();

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
                                                  pathToDepartment);
                        }
                    }

                    break;
                case EmployeePosition.GeneralDirector:
                    break;
                case EmployeePosition.ChiefAccountant:
                    break;
                case EmployeePosition.DeputyDirector:
                    break;                
            }

            return null;
        }
    }
}
