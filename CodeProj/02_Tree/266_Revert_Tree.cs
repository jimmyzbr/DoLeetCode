using System;
using System.Collections.Generic;

/// <summary>
/// 翻转一颗二叉树   https://leetcode-cn.com/problems/invert-binary-tree/
/// </summary>
public partial class Solution{
   

/// <summary>
/// 递归解法
/// </summary>
/// <param name="root"></param>
/// <returns></returns>
   private TreeNode RevertTree(TreeNode root){
       RevertImpl(root);
       return root;
   }
    
   private void RevertImpl(TreeNode root){
       if(root == null)
            return;
        
        //先交换左右两个节点
        var temp = root.left;
        root.left = root.right;
        root.right = temp;
        //再处理交换左子树
        RevertImpl(root.left);
        //再处理交换右子树
       RevertImpl(root.right);
   }

    public void RevertTree_Test()
    {
        //先构建树
        TreeNode root = new TreeNode(4,null,null);
        TreeNode node1 = new TreeNode(2,null,null);
        TreeNode node2 = new TreeNode(7,null,null);
        root.left = node1;
        root.right = node2;

        TreeNode node3 = new TreeNode(1,null,null);
        TreeNode node4 = new TreeNode(3,null,null);
        node1.left = node3;
        node1.right = node4;

        TreeNode node5 = new TreeNode(6,null,null);
        TreeNode node6 = new TreeNode(9,null,null);
        node2.left = node5;
        node2.right = node6;

        var list = PreOrderTravel2(root);
        for(int i = 0; i < list.Count; i++){
            Console.WriteLine(list[i]);
        }
       

        root = RevertTree(root);

        list = PreOrderTravel2(root);
        for(int i = 0; i < list.Count; i++){
            Console.WriteLine(list[i]);
        }
       
    }

}


