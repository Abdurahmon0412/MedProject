using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities
{
    [Table("plastic_card")]
    public class PlasticCard : IEntity<int>
    {
        public PlasticCard()
        {
            PaymentHystoryRecievedCards = new HashSet<PaymentHystory>();
            PaymentHystorySentCards = new HashSet<PaymentHystory>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("card_number")]
        [StringLength(100)]
        public string CardNumber { get; set; } = null!;
        [Column("validate_period", TypeName = "timestamp without time zone")]
        public DateTime? ValidatePeriod { get; set; }
        [Column("balans")]
        public decimal? Balans { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }
        [Column("created_user_id")]
        public int? CreatedUserId { get; set; }
        [Column("modified_date", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedDate { get; set; }
        [Column("modified_user_id")]
        public int? ModifiedUserId { get; set; }

        [InverseProperty(nameof(PaymentHystory.RecievedCard))]
        public virtual ICollection<PaymentHystory> PaymentHystoryRecievedCards { get; set; }
        [InverseProperty(nameof(PaymentHystory.SentCard))]
        public virtual ICollection<PaymentHystory> PaymentHystorySentCards { get; set; }
        [InverseProperty(nameof(Payment.PlasticCard))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
