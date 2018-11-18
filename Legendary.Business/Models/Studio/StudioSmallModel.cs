using System.Collections.Generic;

namespace Legendary.Business.Models.Studio
{
    /// <summary>
    /// Studio Small Model.
    /// </summary>
    public class StudioSmallModel
    {
        /// <summary>
        /// Gets or sets Studio Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Studio Name.
        /// </summary>
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as StudioSmallModel;
            return model != null &&
                   Id == model.Id &&
                   Name == model.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
