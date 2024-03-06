using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TreeBoxProject;
using System.Configuration;

namespace TreeBoxProject
{
    public class Settings
    {
        public int ExpireDays { get; set; }
        public int MaxBoxes { get; set; }
        public int MinBoxes { get; set; }
        public double DeviationPercentage { get; set; }

        public Settings(int minBoxes, int maxBoxes,  int expireDays, double deviationPercentage)
        {
            ExpireDays = expireDays;
            MaxBoxes = maxBoxes;
            MinBoxes = minBoxes;
            DeviationPercentage = deviationPercentage;
        }

        public void SaveItems()
        {
            string data = JsonConvert.SerializeObject(this);
            string path = "C:\\Users\\Hp\\source\\TreeBoxProject\\DataSource\\Settings.json";
            File.WriteAllText(path, data);
        }

        public static Settings LoadItems()
        {
            try
            {
                string path = "C:\\Users\\Hp\\source\\TreeBoxProject\\DataSource\\Settings.json";
                string data = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Settings>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}
