using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace TreeBoxProject
{
    public class TreeBoxTreeNode
    {
        public SecTree HeightTree;
        public double Value;
        public TreeBoxTreeNode Left;
        public TreeBoxTreeNode Right;

        public TreeBoxTreeNode(double value)
        {
            Value = value;
            HeightTree = null;
        }
        public TreeBoxTreeNode(double value, SecTree heightTree)
        {
            Value = value;
            HeightTree = heightTree;
        }
        public TreeBoxTreeNode()
        {

        }
        public TreeBoxTreeNode Search(double width)
        {
            if (this == null || width == Value)
            {
                return this;
            }
            if (Value > width)
            {
                return Left.Search(width);
            }
            else
            {
                return Right.Search(width);
            }
        }
        public TreeBoxTreeNode FindClosestWidth(double width, double diff)
        {
            TreeBoxTreeNode closest = null;
            double minDiff = double.MaxValue;
            diff = (diff / 100) + 1;
            TreeBoxTreeNode current = this;
            while (current != null)
            {
                if (current.Value / width > 1 && current.Value / width < diff && diff < minDiff)
                {
                    minDiff = diff;
                    closest = current;
                }
                if (width < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return closest;
        }

        public TreeBoxTreeNode InsertRecursive(Box box)
        {
            if (this == null)
            {
                return new TreeBoxTreeNode(box.Width);
            }

            if (box.Width < Value)
            {
                if (Left == null)
                {
                    Left = new TreeBoxTreeNode(box.Width);
                }
                else
                {
                    Left.InsertRecursive(box);
                }
            }

            else if (box.Width > Value)
            {
                if (Right == null)
                {
                    Right = new TreeBoxTreeNode(box.Width);
                }
                else
                {
                    Right.InsertRecursive(box);
                }
            }
            return this;
        }
        public TreeBoxTreeNode RemoveRecursive(double width)
        {
            if (this == null)
            {
                return this;
            }
            if (width < Value)
            {
                Left.RemoveRecursive(width);
            }
            else if (width > Value)
            {
                Right.RemoveRecursive(width);
            }
            else
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
                Right.RemoveRecursive(width);
            }
            return this;
        }
        public double TheSmallestValue(TreeBoxTreeNode treeNode)
        {
            while (treeNode.Left != null)
            {
                treeNode = treeNode.Left;
            }
            return treeNode.Value;
        }

        public IEnumerable<TreeBoxTreeNode> BiggerValues(double value)
        {
            List<TreeBoxTreeNode> nodes = new List<TreeBoxTreeNode>();
            BiggerValuesRecursive(this, value, nodes);
            return nodes;
        }

        private void BiggerValuesRecursive(TreeBoxTreeNode node, double value, List<TreeBoxTreeNode> nodes)
        {
            if (node == null)
                return;

            if (node.Value >= value)
            {
                BiggerValuesRecursive(node.Left, value, nodes);
                nodes.Add(node);
                BiggerValuesRecursive(node.Right, value, nodes);
            }
            else
            {
                BiggerValuesRecursive(node.Right, value, nodes);
            }
        }
    }
}
