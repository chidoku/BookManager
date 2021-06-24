namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(100, ErrorMessage = "không được quá 100 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(30, ErrorMessage = "không được quá 30 ký tự")]
        public string Author { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [StringLength(255)]
        public string Images { get; set; }
        [Required(ErrorMessage = "không được để trống")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000- 1000000")]
        public int Price { get; set; }
    }
}
