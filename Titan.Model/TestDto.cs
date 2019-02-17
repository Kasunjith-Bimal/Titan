using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Titan.Model
{
   public class TestDto 
    {
        public int TestEntityId { get; set; }

        [Required]
        public string TestEntityName { get; set; }
    }
}
