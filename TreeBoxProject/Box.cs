using System;
using System.ComponentModel.Design.Serialization;

namespace TreeBoxProject
{
    public class Box
    {
        public double Width { get; }
        public double Height { get; }
        public int BoxCount { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime Manufactured { get; set; }
        public DateTime LastBuy { get; set; }

        public Box(double width, double height, int amount)
        {
            Width = width;
            Height = height;
            Manufactured = DateTime.Now;
            BoxCount = amount;
        }
        public bool LastBuyFunc()
        {
            return LastBuy > DateTime.Now.AddDays(15);
        }
        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }


}
