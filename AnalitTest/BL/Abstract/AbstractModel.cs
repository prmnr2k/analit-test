using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public abstract class AbstractModel<T> : AbstractNotifyPropertyChanged
    {
        /// <summary> Возвращает глубокую копию объекта </summary>
        public abstract T GetDeepCopy();
    }
}
