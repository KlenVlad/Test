namespace DAL.Entities
{
    public class VoteStats : BaseEntity
    {
        public int Percentage { get; set; }
        
        public virtual Vote Vote { get; set; }
    }
}