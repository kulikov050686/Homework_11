using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна переименования департамента
    /// </summary>
    public static class RenameDepartmentDialog
    {
        public static string Show(string nameDepartment)
        {
            WindowAddDepartment addDepartment = new WindowAddDepartment();
            AddDepartmentViewModel addDepartamentViewModel = new AddDepartmentViewModel();

            addDepartamentViewModel.Title = "Переименовать депортамент";
            addDepartamentViewModel.NameDepartment = nameDepartment;
            addDepartment.DataContext = addDepartamentViewModel;

            addDepartment.ShowDialog();

            if (addDepartamentViewModel.AddCancel)
            {
                if (!string.IsNullOrWhiteSpace(nameDepartment))
                {
                    return addDepartamentViewModel.NameDepartment;
                }                
            }            

            return nameDepartment;
        }
    }
}
