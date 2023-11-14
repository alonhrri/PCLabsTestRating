using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRating
{
    internal interface IDeserializer<T>
    {
        T Deserialize(string json);
    }
}
