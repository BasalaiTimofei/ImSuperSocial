using System.Collections.Generic;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Studio;

namespace Legendary.Data.Models.Country
{
    /// <summary>
    /// Country DataBase model.
    /// </summary>
    public class CountryDb
    {
        /// <summary>
        /// Gets or sets Country Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets country Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets collection Actors.
        /// </summary>
        public virtual ICollection<ActorDb> Actors { get; set; }
        /// <summary>
        /// Gets or sets collection Studio
        /// </summary>
        public virtual ICollection<StudioDb> Studio { get; set; }
    }
}