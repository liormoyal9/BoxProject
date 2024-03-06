using System;

namespace TreeBoxProject
{
    public class SecTree
    {
        public double Value { get; set; }
        public Box Box { get; set; }
        public SecTree Left { get; set; }
        public SecTree Right { get; set; }
        public SecTree() { }
        public SecTree(Box box)
        {
            Value = box.Height;
            Box = box;
        }
        public SecTree FindClosestHeight(double height, double diff)
        {
            SecTree closest = null;
            double minDiff = double.MaxValue;
            diff = (diff / 100) + 1;
            Settings settings = Settings.LoadItems();
            SecTree current = this;
            while (current != null)
            {
                diff = settings.DeviationPercentage / 100 + 1;
                if (current.Value / height > 1 && current.Value / height < diff && diff < minDiff)
                {
                    minDiff = diff;
                    closest = current;
                }

                if (height < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            if (minDiff > diff)
            {
                return null;
            }

            return closest;
        }

        public SecTree RemoveRecursive(Box Box)
        {
            if (this == null)
            {
                return this;
            }
            if (Box.Height < Value)
            {
                Left.RemoveRecursive(Box);
            }
            else if (Box.Height > Value)
            {
                Right.RemoveRecursive(Box);
            }

            else if (Box.Height == Value)
            {
                if (Left == null)
                {
                    return Right;
                }
                if (Right == null)
                {
                    return Left;
                }
                Value = TheSmallestValue(Right);
                Right.RemoveRecursive(Box);
            }
            return this;
        }
        public double TheSmallestValue(SecTree secTree)
        {
            while (secTree.Left != null)
            {
                secTree = secTree.Left;
            }
            return secTree.Value;
        }
        public SecTree InsertRecursiveSec(Box box)
        {
            if (this == null)
            {
                return new SecTree(box);
            }
            if (box.Height < Value)
            {
                if (Left == null)
                {
                    Left = new SecTree(box);
                }
                else
                {
                    Left.InsertRecursiveSec(box);
                }
            }
            else if (box.Height > Value)
            {
                if (Right == null)
                {
                    Right = new SecTree(box);
                }
                else
                {
                    Right.InsertRecursiveSec(box);
                }
            }
            else if (box.Height == Value)
            {
                AddToBoxCount(box);
            }
            return this;
        }
        public bool AddToBoxCount(Box box)
        {
            Settings settings = Settings.LoadItems();
            if (Box.BoxCount + box.BoxCount <= settings.MaxBoxes)
            {
                Box.BoxCount += box.BoxCount;
                Box.LastBuy = DateTime.Now;
            }
            else if (Box.BoxCount + box.BoxCount > settings.MaxBoxes && Box.BoxCount != settings.MaxBoxes)
            {
                Box.BoxCount = settings.MaxBoxes;
                Box.LastBuy = DateTime.Now;
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool UseBox(double height)
        {
            if (Box.BoxCount > 0)
            {
                Box.BoxCount--;
                Box.LastBuy = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
