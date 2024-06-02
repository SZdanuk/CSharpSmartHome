using CSharpSmartHomeApplication.AutomationSystemComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSmartHomeApplication
{
    public interface IThermometerFactory
    {

        IThermometer CreateThermometer(ThermometerType type);

    }
}
