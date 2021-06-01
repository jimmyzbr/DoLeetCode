using System;
using System.Collections.Generic;

///二叉树前序遍历: 跟节点 左子树 右子树
//输入：root = [1,null,2,3]
//输出：[1,2,3]
//二叉树节点
public class TreeNode{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public  TreeNode(int val,TreeNode left,TreeNode right){
        this.val = val;
        this.left = left;
        this.right = right;
    }
}


public partial class Solution{
    public IList<int> PreOrderTravel(TreeNode root){
       List<int>  list = new List<int>();
       PreTravel(root,list);
       return list;
    }

    public void PreTravel(TreeNode node,IList<int> lst){
        if(node == null)
            return;
        lst.Add(node.val);
        if(node.left != null)
            PreTravel(node.left,lst);
        if(node.right != null)
            PreTravel(node.right,lst);
    }

    private TreeNode BuildTree(){
        
        TreeNode root = new TreeNode(1,null,null);
        TreeNode node1 = new TreeNode(2,null,null);
        TreeNode node2 = new TreeNode(3,null,null);
        root.right = node1;
        node1.left = node2;
        return root;
    }


/// <summary>
/// 使用迭代法进行前序变量 root-> left tree ->right tree
/// </summary>
/// <param name="root"></param>
/// <returns></returns>
    private IList<int> PreOrderTravel2(TreeNode root)
    {
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        var tempNode = root;
        while(stack.Count > 0 || tempNode  != null ){
            if(tempNode != null){
               //先把根节点加到结果列表，然后入栈，再处理左子树，直到没有左子树
               res.Add(tempNode.val);
               stack.Push(tempNode);
               tempNode = tempNode.left;
            }
            else{
                tempNode = stack.Pop();  //弹出跟节点，按照相同方法处理右子树
                tempNode = tempNode.right;
            }
        }
        return res;
    }


    public void PreTravelTest()
    {
       // Console.WriteLine("xxx test");
       var root = BuildTree();
       var list = PreOrderTravel2(root);
       for(int i = 0; i < list.Count; ++i){
           Console.WriteLine(list[i]);
       } 
    }
}