namespace _7._3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //       4
            //      / \
            //     2   7
            //    / \
            //   1   3
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.left.right = new TreeNode(1);
            root.left.right = new TreeNode(3);

            Solution sol = new Solution();

            // Search for a value
            int val = 2;
            TreeNode result = sol.SearchBST(root, val);

            if (result != null)
            {
                Console.WriteLine($"Found node with value {result.val}");
            } else
            {
                Console.WriteLine("Value not found in BST");
            }
        }
    }
}
