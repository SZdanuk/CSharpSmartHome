using CSharpSmartHomeApplication.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSmartHomeApplication.Equipment;

public interface IThermometerFactory
{

    IThermometer CreateThermometer(ThermometerType type);

}
