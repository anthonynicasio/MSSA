using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._3
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x;  }
    }

    public class Solution
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            // Base case: root is null or val is found
            if (root == null || root.val == val)
            {
                return root;
            }

            // Since it's a BST, search left or right depending on val
            if (val < root.val)
            {
                return SearchBST(root.left, val);
            } else
            {
                return SearchBST(root.right, val);
            }
        }
    }
}
