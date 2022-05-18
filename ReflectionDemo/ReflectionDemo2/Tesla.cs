using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo2
{
    public class Tesla : ICar
    {
        public string Model { get ; set ; }
        public double Speed { get ; set ; }
        public double CurrentSpeed { get; set; }
        public string Color { get ; set ; }

        public Tesla()
        {
            Model = "Tesla";
        }
        public void Start()
        {
            CurrentSpeed = 0;
        }
        public void SpeedUp(double speed)
        {
            CurrentSpeed += speed * 20;
        }
    }
}
