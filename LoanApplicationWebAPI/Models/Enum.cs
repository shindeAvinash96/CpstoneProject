namespace LoanApplicationWebAPI.Models
{
    public enum UserRole
    {
        Admin,
        Officer,
        Customer
    }

    public enum UserType
    {
        Customer,
        LoanAdmin,
        SystemAdministrator,
        LoanOfficer
    }

    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected,
        Disbursed,
        Repaid,
        UnderReview
    }

    public enum LoanType
    {
        Home,
        Personal,
        Educational,
        Business
    }

    public enum RepaymentMethod
    {
        Online,
        Cheque,
        Cash,
        AutoDebit
    }

    public enum RepaymentStatus
    {
        Pending,
        Paid,
        Overdue,
        NPA
    }
}
