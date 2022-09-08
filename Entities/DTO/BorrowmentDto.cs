namespace Entities.DTO;

public class BorrowmentDto
{
    public Guid Id { get; set; }
    public DateOnly? DateBorrowment { get; set; }
    public DateOnly? ReturningDate { get; set; }
    public long? DaysBorrowed { get; set; }
    public bool? RenewAble { get; set; }
}