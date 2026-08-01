namespace NurserySystem.Domain.Enums;

public enum SubscriptionType
{
    Monthly = 1,  // شهري
    Quarterly = 2, // فصلي
    Yearly = 3    // سنوي
}

public enum PaymentStatus
{
    Pending = 0,   // قيد الانتظار
    Paid = 1,      // مدفوع
    Overdue = 2,   // متأخر
    Cancelled = 3  // ملغى
}

public enum PaymentMethod
{
    Cash = 1,           // نقدي
    BankTransfer = 2,   // تحويل بنكي
    DigitalWallet = 3,  // محفظة إلكترونية
    CreditCard = 4      // بطاقة ائتمان
}

public enum Gender
{
    Male = 1,   // ذكر
    Female = 2  // أنثى
}
