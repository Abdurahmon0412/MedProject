using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedDomain.Common;

public interface IEntityLong 
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    /// <value>
    /// The unique identifier of the entity.
    /// </value>
    public long Id { get; set; }
}
