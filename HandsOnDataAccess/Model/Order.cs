using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HandsOnDataAccess.Model
{
    [Table("Order")]

   public class Order
    {
        [Key]
        [StringLength(5)]
        public int order_id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DelivaryDate { get; set; }

        public int item_id { get; set; }
        [ForeignKey("item_id")]
        public Item item{ get; set; }
    }
}
