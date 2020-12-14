using Models;
using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна добавить руководителя
    /// </summary>
    public static class AddChiefDialog
    {
        public static BaseWorker Show()
        {
            WindowAddChief addChief = new WindowAddChief();
            AddChiefViewModel addChiefViewModel = new AddChiefViewModel();

            addChiefViewModel.Title = "Добавить руководителя";
            addChief.DataContext = addChiefViewModel;

            addChief.ShowDialog();

            if(addChiefViewModel.YesNo)
            {
                if (addChiefViewModel.ChiefEmployeePosition == EmployeePosition.GeneralDirector)
                {
                    return new GeneralDirector(addChiefViewModel.ChiefName,
                                               addChiefViewModel.ChiefSurname,
                                               addChiefViewModel.ChiefAge,
                                               addChiefViewModel.ChiefSalary,
                                               addChiefViewModel.ChiefJobTitle);
                }

                if (addChiefViewModel.ChiefEmployeePosition == EmployeePosition.DeputyDirector)
                {
                    return new DeputyDirector(addChiefViewModel.ChiefName,
                                              addChiefViewModel.ChiefSurname,
                                              addChiefViewModel.ChiefAge,
                                              addChiefViewModel.ChiefSalary,
                                              addChiefViewModel.ChiefJobTitle);
                }

                if (addChiefViewModel.ChiefEmployeePosition == EmployeePosition.ChiefAccountant)
                {
                    return new ChiefAccountant(addChiefViewModel.ChiefName,
                                               addChiefViewModel.ChiefSurname,
                                               addChiefViewModel.ChiefAge,
                                               addChiefViewModel.ChiefSalary,
                                               addChiefViewModel.ChiefJobTitle);
                }

                if (addChiefViewModel.ChiefEmployeePosition == EmployeePosition.Supervisor)
                {
                    return new Supervisor(addChiefViewModel.ChiefName,
                                          addChiefViewModel.ChiefSurname,
                                          addChiefViewModel.ChiefAge,
                                          addChiefViewModel.ChiefSalary,
                                          addChiefViewModel.ChiefJobTitle);
                }
            }            

            return null;
        }
    }
}
