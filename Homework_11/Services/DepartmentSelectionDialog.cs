using Controllers;
using ViewModels;
using Views;

namespace Services
{
    /// <summary>
    /// Открытие диалогового окна выбрать департамент
    /// </summary>
    public static class DepartmentSelectionDialog
    {
        public static string Show(Ministry ministry)
        {
            WindowLocationSelection windowLocationSelection = new WindowLocationSelection();
            LocationSelectionViewModel locationSelectionViewModel = new LocationSelectionViewModel(ministry);

            locationSelectionViewModel.Title = "Выбрать департамент";
            windowLocationSelection.DataContext = locationSelectionViewModel;

            windowLocationSelection.ShowDialog();

            if(locationSelectionViewModel.SelectCancel)
            {
                return locationSelectionViewModel.PathToDepartment;
            }

            return null;
        }
    }
}
