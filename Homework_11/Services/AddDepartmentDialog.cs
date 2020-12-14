using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна добавить департамент
    /// </summary>
    public static class AddDepartmentDialog
    {
        public static string Show(string path)
        {
            WindowAddDepartment addDepartment = new WindowAddDepartment();
            AddDepartmentViewModel addDepartamentViewModel = new AddDepartmentViewModel();

            addDepartamentViewModel.Title = "Добавить депортамент";
            addDepartment.DataContext = addDepartamentViewModel;

            addDepartment.ShowDialog();

            if(string.IsNullOrWhiteSpace(addDepartamentViewModel.NameDepartment))
            {
                return null;
            }

            if(string.IsNullOrWhiteSpace(path))
            {
                return addDepartamentViewModel.NameDepartment;
            }

            return path + "/" + addDepartamentViewModel.NameDepartment;
        }
    }
}
