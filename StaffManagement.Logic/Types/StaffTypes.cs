using System.ComponentModel;

namespace StaffManagement.Logic.Types
{
    public enum StatusType
    {
        [Description("Работает")]
        Works = 0,
        [Description("Уволен(а)")]
        Fired = 1,
        [Description("Ежегодный отпуск")]
        AnnualVacation = 2,
        [Description("Декретный отпуск")]
        MaternityLeave = 3
    }
}