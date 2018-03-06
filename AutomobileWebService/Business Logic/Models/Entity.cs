using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomobileWebService.Business_Logic.Models
{
    public abstract class Entity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; protected set; }
        public bool Deleted {get; protected set;}

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}
