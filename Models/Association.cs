using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinistryOfJustice.Models
{
    public class Association
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssociationId { get; set; }

        [RegularExpression(@"^[א-תa-zA-Z''-'\s]{1,20}$", ErrorMessage = "Name contains not allowed characters")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Association type is required")]
        public int AssociationTypeId { get; set; }

        [JsonIgnore]
        public AssociationType AssociationType { get; set; }

        [Required(ErrorMessage = "Donation amount is required")]
        public decimal DonationAmount { get; set; }

        [RegularExpression(@"^[א-תa-zA-Z''-'\s]{1,40}$", ErrorMessage = "Donation Purpose contains not allowed characters")]
        [Required(ErrorMessage = "Donation purpose is required")]
        [StringLength(40, ErrorMessage = "Donation purpose can't be longer than 40 characters")]
        public string DonationPurpose { get; set; }

        [RegularExpression(@"^[א-תa-zA-Z''-'\s]{1,40}$", ErrorMessage = "Donation terms contains not allowed characters")]
        [StringLength(40, ErrorMessage = "Donation terms can't be longer than 40 characters")]
        public string DonationTerms { get; set; }

        [Required(ErrorMessage = "Currency type is required")]
        public int CurrencyTypeId { get; set; }

        [JsonIgnore]
        public CurrencyType CurrencyType { get; set; }

        [Required(ErrorMessage = "Conversion rate is required")]
        public decimal ConversionRate { get; set; }

        public int? CreatedByUserId { get; set; }

        [NotMapped]
        public string AssociationTypeName => AssociationType?.AssociationTypeName;

        [NotMapped]
        public string CurrencyTypeName => CurrencyType?.CurrencyTypeName;
    }
}
