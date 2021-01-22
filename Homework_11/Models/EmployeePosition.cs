namespace Models
{
    /// <summary>
    /// Статус работника
    /// </summary>
    public enum EmployeePosition
    {
        /// <summary>
        /// Стажёр
        /// </summary>
        Intern = 0,

        /// <summary>
        /// Штатный сотрудник
        /// </summary>
        Employee = 1,

        /// <summary>
        /// Руководитель департамента
        /// </summary>
        Supervisor = 2,

        /// <summary>
        /// Генеральный директор
        /// </summary>
        GeneralDirector = 3,

        /// <summary>
        /// Главный бухгалтер
        /// </summary>
        ChiefAccountant = 4,

        /// <summary>
        /// Заместитель генерального директора
        /// </summary>
        DeputyDirector = 5
    }
}
