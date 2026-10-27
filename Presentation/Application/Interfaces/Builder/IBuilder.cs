using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Builder
{
    public interface IBuilder<T>
    {

        public T Build();
    }
}
