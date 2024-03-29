﻿using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities
{
    [Table("payment_hystory")]
    public class PaymentHystory : IEntity<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("details")]
        [StringLength(100)]
        public string Details { get; set; } = null!;
        [Column("transform_time", TypeName = "timestamp without time zone")]
        public DateTime? TransformTime { get; set; }
        [Column("transform_balans")]
        public decimal? TransformBalans { get; set; }
        [Column("recieved_card_id")]
        public int RecievedCardId { get; set; }
        [Column("sent_card_id")]
        public int SentCardId { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }
        [Column("created_user_id")]
        public int? CreatedUserId { get; set; }
        [Column("modified_date", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedDate { get; set; }
        [Column("modified_user_id")]
        public int? ModifiedUserId { get; set; }

        [ForeignKey(nameof(RecievedCardId))]
        [InverseProperty(nameof(PlasticCard.PaymentHystoryRecievedCards))]
        public virtual PlasticCard RecievedCard { get; set; } = null!;
        [ForeignKey(nameof(SentCardId))]
        [InverseProperty(nameof(PlasticCard.PaymentHystorySentCards))]
        public virtual PlasticCard SentCard { get; set; } = null!;
    }
}
