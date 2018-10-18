using System;
using System.Collections.Generic;
using System.Text;

namespace layUiAdmin.SQL
{
    public class BaseModel : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
