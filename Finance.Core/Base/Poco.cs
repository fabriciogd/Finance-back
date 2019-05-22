using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Finance.Core.Base
{
    public abstract class Poco
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public virtual int Id { get; set; }
    }
}
