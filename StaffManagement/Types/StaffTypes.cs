using System.ComponentModel;

namespace StaffManagement.Types
{
    public enum StatusType
    {
        [Description("Работает")]
        Omission = 0,
        [Description("Уволен(а)")]
        Repair = 1,
        [Description("Ежегодный отпуск")]
        Service = 2,
        [Description("Декретный отпуск")]
        Equipment = 3
    }
}