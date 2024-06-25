using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models.UnitModule.DTOs
{
    public class UnitUpdateRequest : UnitAddRequest
    {
        public int Id { get; set; }
    }
}
