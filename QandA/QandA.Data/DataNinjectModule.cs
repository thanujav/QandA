using Ninject.Modules;
using QandA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Data
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
