using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using System;
using System.Collections.Generic;
using TreeBoxProject;


namespace TreeBoxProject
{
    public class Manager
    {
        public static TreeBoxTreeNode root;

        public static TreeBoxTreeNode Insert(Box box)
        {
            if (root == null)
            {
                root = new TreeBoxTreeNode(box.Width, new SecTree(box));
                return root;
            }
            else
            {
                root = root.InsertRecursive(box);
                TreeBoxTreeNode treeNode = root.Search(box.Width);
                if (treeNode != null)
                {
                    if (treeNode.HeightTree != null)
                    {
                        treeNode.HeightTree.InsertRecursiveSec(box);
                    }
                    else
                    {
                        treeNode.HeightTree = new SecTree(box);
                    }
                }
            }
            return root;
        }

        public static List<Box> GetAllBoxesFromSecTree(SecTree secTree)
        {
            List<Box> boxes = new List<Box>();
            if (secTree != null)
            {
                boxes.Add(secTree.Box);
                boxes.AddRange(GetAllBoxesFromSecTree(secTree.Left));
                boxes.AddRange(GetAllBoxesFromSecTree(secTree.Right));
            }
            return boxes;
        }

        public static List<Box> GetAllBoxesMainTree(TreeBoxTreeNode treeBoxTreeNode)
        {
            List<Box> boxes = new List<Box>();
            if (treeBoxTreeNode != null)
            {
                boxes.AddRange(GetAllBoxesMainTree(treeBoxTreeNode.Left));
                boxes.AddRange(GetAllBoxesMainTree(treeBoxTreeNode.Right));
                if (treeBoxTreeNode != null)
                {
                    boxes.AddRange(GetAllBoxesFromSecTree(treeBoxTreeNode.HeightTree));
                }
            }
            return boxes;
        }
        public static List<Box> FindMostSuitableBoxes(double width, double height, int quantity)
        {
            Settings settings = Settings.LoadItems();
            List<Box> suitableBoxes = new List<Box>();
            TreeBoxTreeNode widthTree = root.FindClosestWidth(width, settings.DeviationPercentage);

            while (widthTree != null && suitableBoxes.Count < quantity)
            {
                SecTree heightTree = widthTree.HeightTree;

                if (heightTree != null && heightTree.Box.BoxCount > 0)
                {
                    SecTree closestHeight = heightTree.FindClosestHeight(height, settings.DeviationPercentage);
                    if (closestHeight == null)
                    {
                        return null;
                    }
                    if (Math.Abs(closestHeight.Value - height) <= (settings.DeviationPercentage * height / 100.0))
                    {
                        Box suitableBox = heightTree.Box;
                        suitableBoxes.Add(suitableBox);
                        heightTree.UseBox(suitableBox.Height);

                        if (heightTree.Box.BoxCount == 0)
                        {
                            TreeBoxTreeNode widthNode = root.FindClosestWidth(width, settings.DeviationPercentage);

                            if (widthNode != null)
                            {
                                widthNode.HeightTree = widthNode.HeightTree.RemoveRecursive(heightTree.Box);

                                if (widthNode.HeightTree == null)
                                {
                                    root = root.RemoveRecursive(widthNode.Value);
                                }
                            }
                        }
                    }
                }
                else
                {
                    widthTree = root.BiggerValues(widthTree.Value + 1)
                        .FirstOrDefault(node => node.HeightTree != null && node.HeightTree.Box.BoxCount > 0);
                }
            }
            return suitableBoxes;
        }

        public static List<Box> DisplayBoxesWithoutDuplicates(List<Box> boxes)
        {
            List<Box> filteredBoxes = new List<Box>();
            int amount = boxes.Count;
            int countSame = 1;
            for (int i = 0; i < boxes.Count - 1; i++)
            {
                if (boxes[i].Width == boxes[i + 1].Width && boxes[i].Height == boxes[i + 1].Height)
                {
                    countSame++;
                }
                else
                {
                    // Display or handle boxes[i] with countSame quantity.
                    filteredBoxes.Add(boxes[i]);
                    amount -= countSame;
                    countSame = 1;
                }
            }

            if (amount > 0)
            {
                // Display or handle boxes[boxes.Count - 1] with amount quantity.
                filteredBoxes.Add(boxes[boxes.Count - 1]);
            }

            return filteredBoxes;
        }
    }
}
