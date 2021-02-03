using Models;
using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна редактирования данных работника
    /// </summary>
    public static class EditDataWorkerDialog
    {
        public static BaseWorker Show(BaseWorker worker)
        {
            WindowAddWorker addWorker = new WindowAddWorker();
            AddWorkerViewModel addWorkerViewModel = new AddWorkerViewModel();

            addWorkerViewModel.Title = "Изменить данные работника";
            addWorkerViewModel.WorkerName = worker.Name;
            addWorkerViewModel.WorkerSurname = worker.Surname;
            addWorkerViewModel.WorkerSalary = worker.Salary;
            addWorkerViewModel.WorkerAge = worker.Age;
            addWorkerViewModel.WorkerJobTitle = worker.JobTitle;
            addWorkerViewModel.WorkerEmployeePosition = worker.EmployeePosition;                       

            addWorker.DataContext = addWorkerViewModel;            

            addWorker.ShowDialog();

            if (addWorkerViewModel.AddCancel)
            {
                if (!string.IsNullOrWhiteSpace(addWorkerViewModel.WorkerName) &&
                   !string.IsNullOrWhiteSpace(addWorkerViewModel.WorkerSurname) &&
                   (18 <= addWorkerViewModel.WorkerAge && addWorkerViewModel.WorkerAge <= 99) &&
                   0 < addWorkerViewModel.WorkerSalary &&
                   !string.IsNullOrWhiteSpace(addWorkerViewModel.WorkerJobTitle))
                {
                    if (addWorkerViewModel.WorkerEmployeePosition == EmployeePosition.Intern)
                    {
                        return new Intern(addWorkerViewModel.WorkerName,
                                          addWorkerViewModel.WorkerSurname,
                                          addWorkerViewModel.WorkerAge,
                                          addWorkerViewModel.WorkerSalary,
                                          addWorkerViewModel.WorkerJobTitle,
                                          worker.PathToDepartment);
                    }

                    if (addWorkerViewModel.WorkerEmployeePosition == EmployeePosition.Employee)
                    {
                        return new Employee(addWorkerViewModel.WorkerName,
                                            addWorkerViewModel.WorkerSurname,
                                            addWorkerViewModel.WorkerAge,
                                            addWorkerViewModel.WorkerSalary,
                                            addWorkerViewModel.WorkerJobTitle,
                                            worker.PathToDepartment);
                    }
                }
            }

            return worker;
        }        
    }
}
