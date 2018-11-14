using System.Collections.Generic;

namespace Legendary.Business.Models
{
    /// <summary>
    /// Country DataTransferObject model.
    /// </summary>
    public class Country
    {
        public string Id { get; set; }
        public string CountryName { get; set; }

        public override bool Equals(object obj)
        {
            var country = obj as Country;
            return country != null &&
                   Id == country.Id &&
                   CountryName == country.CountryName;
        }

        public override int GetHashCode()
        {
            var hashCode = 1051187466;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CountryName);
            return hashCode;
        }
    }
}
