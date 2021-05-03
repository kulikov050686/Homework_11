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

                    return AddSupervisor(pathToDepartment);
                    
                case EmployeePosition.GeneralDirector: return AddGeneralDirector();
                    
                case EmployeePosition.ChiefAccountant: return AddChiefAccountant();
                    
                case EmployeePosition.DeputyDirector: return AddDeputyDirector();                                    
            }

            return null;
        }

        /// <summary>
        /// Добавить руководителя департамента
        /// </summary>        
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        private static Supervisor AddSupervisor(string pathToDepartment)
        {
            WindowAddSupervisor windowAddSupervisor = new WindowAddSupervisor();
            AddSupervisorViewModel addSupervisorViewModel = new AddSupervisorViewModel();

            addSupervisorViewModel.Title = "Добавить Руководителя";
            addSupervisorViewModel.SupervisorJobTitle = "Руководитель департамента";
            windowAddSupervisor.DataContext = addSupervisorViewModel;

            windowAddSupervisor.ShowDialog();

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
                                          pathToDepartment);
                }
            }

            return null;
        }

        /// <summary>
        /// Добавить генерального директора
        /// </summary>        
        private static GeneralDirector AddGeneralDirector()
        {
            WindowAddSupervisor windowAddSupervisor = new WindowAddSupervisor();
            AddSupervisorViewModel addSupervisorViewModel = new AddSupervisorViewModel();

            addSupervisorViewModel.Title = "Добавить Генерального директора";
            addSupervisorViewModel.SupervisorJobTitle = "Генеральный Директор";
            windowAddSupervisor.DataContext = addSupervisorViewModel;

            windowAddSupervisor.ShowDialog();

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
        /// Добавить заместителя генерального директора
        /// </summary>        
        private static DeputyDirector AddDeputyDirector()
        {
            WindowAddSupervisor windowAddSupervisor = new WindowAddSupervisor();
            AddSupervisorViewModel addSupervisorViewModel = new AddSupervisorViewModel();

            addSupervisorViewModel.Title = "Добавить Заместителя Генерального директора";
            addSupervisorViewModel.SupervisorJobTitle = "Заместитель Генерального директора";
            windowAddSupervisor.DataContext = addSupervisorViewModel;

            windowAddSupervisor.ShowDialog();

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
        /// Добавить главного бухгалтера
        /// </summary>        
        private static ChiefAccountant AddChiefAccountant()
        {
            WindowAddSupervisor windowAddSupervisor = new WindowAddSupervisor();
            AddSupervisorViewModel addSupervisorViewModel = new AddSupervisorViewModel();

            addSupervisorViewModel.Title = "Добавить Главного Бухгалтера";
            addSupervisorViewModel.SupervisorJobTitle = "Заместитель Генерального директора";
            windowAddSupervisor.DataContext = addSupervisorViewModel;

            windowAddSupervisor.ShowDialog();

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
    }
}
