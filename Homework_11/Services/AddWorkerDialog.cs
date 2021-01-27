using Models;
using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна добавить работника
    /// </summary>
    public static class AddWorkerDialog
    {
        public static BaseWorker Show(string path)
        {
            WindowAddWorker addWorker = new WindowAddWorker();
            AddWorkerViewModel addWorkerViewModel = new AddWorkerViewModel();

            addWorkerViewModel.Title = "Добавить работника";
            addWorker.DataContext = addWorkerViewModel;

            addWorker.ShowDialog();

            if(addWorkerViewModel.AddCancel)
            {
                if(!string.IsNullOrWhiteSpace(addWorkerViewModel.WorkerName) && 
                   !string.IsNullOrWhiteSpace(addWorkerViewModel.WorkerSurname) && 
                   (18 <= addWorkerViewModel.WorkerAge && addWorkerViewModel.WorkerAge <= 99) && 
                   0 < addWorkerViewModel.WorkerSalary && 
                   !string.IsNullOrWhiteSpace(addWorkerViewModel.WorkerJobTitle) && 
                   !string.IsNullOrWhiteSpace(path))
                {
                    if(addWorkerViewModel.WorkerEmployeePosition == EmployeePosition.Intern)
                    {
                        return new Intern(addWorkerViewModel.WorkerName, 
                                          addWorkerViewModel.WorkerSurname, 
                                          addWorkerViewModel.WorkerAge, 
                                          addWorkerViewModel.WorkerSalary, 
                                          addWorkerViewModel.WorkerJobTitle, 
                                          path);
                    }

                    if(addWorkerViewModel.WorkerEmployeePosition == EmployeePosition.Employee)
                    {
                        return new Employee(addWorkerViewModel.WorkerName,
                                            addWorkerViewModel.WorkerSurname,
                                            addWorkerViewModel.WorkerAge,
                                            addWorkerViewModel.WorkerSalary,
                                            addWorkerViewModel.WorkerJobTitle, 
                                            path);
                    }
                }
            }

            return null;
        }
    }
}
