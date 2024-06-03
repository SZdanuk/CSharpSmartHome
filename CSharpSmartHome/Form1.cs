//using CSharpSmartHomeCore;
using CSharpSmartHomeApplication;
using CSharpSmartHomeCore;

namespace CSharpSmartHome
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getTempButton_Click(object sender, EventArgs e)
        {

            var thermometerFactory = new ThermometerFactory();
            var thermometer = thermometerFactory.CreateThermometer(ThermometerType.Internet);
            var temperature = thermometer.GetTemperature();

            temperatureOutput.Text = temperature.ToString() + "°C";

        }
    }
}