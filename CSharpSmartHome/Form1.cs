using CSharpSmartHomeApplication.Equipment;
using CSharpSmartHomeInfrastructure.Equipment;

namespace CSharpSmartHome
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
                        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IThermometer roomTemp = new I2CThermometer();

            string roomTemp_s = (roomTemp.GetTemperature()).ToString();

            roomTemperature.Text = roomTemp_s;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}