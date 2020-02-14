using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HandsOnDataAccess
{
    [Table("Item")]
  public  class Item
    {
        [Key]
        [StringLength(5)]
        public int item_id { get; set; }
        [Required]
        [StringLength(30)]
        public string item_name { get; set; }
        
        public int price { get; set; }
    }
}
