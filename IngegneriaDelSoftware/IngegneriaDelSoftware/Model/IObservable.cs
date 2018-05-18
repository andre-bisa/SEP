using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IngegneriaDelSoftware.Model.ArgsEvent;

namespace IngegneriaDelSoftware.Model
{
    public interface IObservable<T>
    {
        event EventHandler<ArgsModifica<T>> OnModifica;
    }
}
