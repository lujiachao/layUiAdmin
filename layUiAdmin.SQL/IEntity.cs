using System;
using System.Collections.Generic;
using System.Text;

namespace layUiAdmin.SQL
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
