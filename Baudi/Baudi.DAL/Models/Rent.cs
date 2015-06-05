namespace Baudi.DAL.Models
{
    public class Rent : Payment
    {
        public virtual Ownership Ownership { get; set; }
    }
}