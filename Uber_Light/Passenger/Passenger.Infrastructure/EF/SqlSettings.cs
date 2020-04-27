using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.EF
{
    public class SqlSettings
    {
        public string ConnectionString { get; set; }
        public bool InMemory { get; set; }              //Flaga określa czy chemy uzyć rzeczywistej bazy dancyh czy bazy danychw pamięci.
    }
}
