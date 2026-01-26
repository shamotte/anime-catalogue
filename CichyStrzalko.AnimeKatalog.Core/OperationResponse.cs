using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.AnimeKatalog.Core
{
    public record class OperationResponse<T>
    {
        public T? value { get; set; }
        public string message { get; set; } = "";

        public bool succesful { get; set; } = true;

    }
}
