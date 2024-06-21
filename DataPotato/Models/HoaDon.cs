namespace DataPotato.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public DateTime SoldDate { get; set; }
        public Guid UserId { get; set; }
        public Decimal TotalMoney { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }  // 1 user  co nhieu hoadon
    }
}
