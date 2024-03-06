using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TreeBoxProject;

namespace ClassLibrary
{
    public class FileManagement
    {

        public static void SaveItems(TreeBoxTreeNode root)
        {
            string data = JsonConvert.SerializeObject(root);
            string path = "C:\\Users\\Hp\\source\\TreeBoxProject\\DataSource\\AllBoxes.json";
            File.WriteAllText(path, data);
        }

        public static TreeBoxTreeNode LoadItems()
        {
            try
            {
                string path = "C:\\Users\\Hp\\source\\TreeBoxProject\\DataSource\\AllBoxes.json";
                string data = File.ReadAllText(path);
                TreeBoxTreeNode root = JsonConvert.DeserializeObject<TreeBoxTreeNode>(data);
                return root;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static void DeleteItems()
        {
            try
            {
                string path = "C:\\Users\\Hp\\source\\TreeBoxProject\\DataSource\\AllBoxes.json";
                string data = File.ReadAllText(path);
                TreeBoxTreeNode root = JsonConvert.DeserializeObject<TreeBoxTreeNode>(data);

                List<Box> boxesToRemove = Manager.GetAllBoxesFromSecTree(root.HeightTree);

                foreach (var box in boxesToRemove)
                {
                    if (box.LastBuyFunc())
                    {
                        root.RemoveRecursive(box.Width);
                    }
                }

                string updatedData = JsonConvert.SerializeObject(root);
                File.WriteAllText(path, updatedData);
                SaveItems(root);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Box> GetAllBoxes()
        {
            try
            {
                string path = "C:\\Users\\Hp\\source\\TreeBoxProject\\DataSource\\AllBoxes.json";
                string data = File.ReadAllText(path);
                TreeBoxTreeNode root = JsonConvert.DeserializeObject<TreeBoxTreeNode>(data);

                // Get all boxes from the SecTree.
                List<Box> allBoxes = Manager.GetAllBoxesFromSecTree(root.HeightTree);

                return allBoxes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}
