using System;
using System.Collections.Generic;

///二叉树后序遍历 :左子树  右子树 根节点 的方式遍历
//给定一个二叉树的根节点 root ，返回它的 中序 遍历。
//输入：root = [1,null,2,3]
//输出：[3,2,1]

public partial class Solution{
    private IList<int> PostOrderTravel(TreeNode root){
        List<int> list = new List<int>();
        PostOrderTravelImpl(root,list);
        return list;
    }

    private void PostOrderTravelImpl(TreeNode root, IList<int> list){
       if(root == null)
            return;
        PostOrderTravelImpl(root.left,list);
        PostOrderTravelImpl(root.right,list);
        list.Add(root.val);
    }


    /// <summary>
    /// 迭代法后序遍历二叉树  left->right->root
    /// </summary>
    
    private IList<int> PostOrderTravel2(TreeNode root){
        List<int> res = new List<int>();
        Stack<TreeNode> s  = new Stack<TreeNode>();
        var temp = root;
        TreeNode pre = null;
        while(s.Count > 0 || temp != null){ 
            if(temp != null){
                s.Push(temp);
                temp = temp.left;
            }
            else{
                temp = s.Pop();
                if(temp.right != null && temp.right != pre )  //防止重复push之前已经push过的节点
                {
                    s.Push(temp);
                    temp = temp.right;
                }
                else{
                    res.Add(temp.val);
                    pre = temp;
                    temp = null;  //清空 取栈中的下个节点
                }
            }
        }

        return res;
    }

    public void PostOrderTravelTest()
    {
        //先构建树
        TreeNode root = new TreeNode(1,null,null);
        TreeNode node1 = new TreeNode(2,null,null);
        TreeNode node2 = new TreeNode(3,null,null);
        root.right = node1;
        node1.left = node2;

        var list = PostOrderTravel2(root);
        for(int i = 0; i < list.Count; i++){
            Console.WriteLine(list[i]);
        }
       
    }

}


