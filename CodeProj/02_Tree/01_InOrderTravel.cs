using System;
using System.Collections.Generic;

///二叉树中序遍历 :左子树 根节点 右子树的方式遍历
//给定一个二叉树的根节点 root ，返回它的 中序 遍历。
//输入：root = [1,null,2,3]
//输出：[1,3,2]

public partial class Solution{

    //递归求解的方式
    public IList<int> InOrderTravel(TreeNode root){
        List<int> list = new List<int>();
        InOrderTravelImp(root,list);
        return list;
    }

    public void InOrderTravelImp(TreeNode root, IList<int> list){
        //递归退出条件     
        if(root == null)
            return;
        InOrderTravelImp(root.left,list); //访问左子树
        list.Add(root.val);   //访问根节点
        InOrderTravelImp(root.right,list); //访问右子树
    }

    ////非递归求解的方式  垃圾算法
    // public IList<int> InOrderTravel2(TreeNode root){
    //     List<int> lst = new List<int>();
    //     Stack<TreeNode> stack = new Stack<TreeNode>();
    //     TreeNode tempRoot = root;
        
    //     while(stack.Count > 0 || tempRoot != null){
    //         if(tempRoot != null){
    //             var left = tempRoot.left;
    //             if(left != null){
    //                 tempRoot.left = null;  //这里会改变数的结构 不好
    //                 stack.Push(tempRoot);
    //                 stack.Push(left);
    //             }else{
    //                 lst.Add(tempRoot.val);
    //                 if(tempRoot.right != null)
    //                     stack.Push(tempRoot.right);
    //             }

    //             tempRoot = null;
    //         }
    //         else{
    //             tempRoot = stack.Pop();
    //         }
    //     }
    //     return lst;
    // }

    /// <summary>
    /// 使用迭代的方法遍历二叉树 leetcode官方推荐的方式 先把根节点的左子树全部都入栈 直到没有左子树 
    /// 然后弹出栈顶的元素 加入到存存储遍历结果的list中，然后接着处理该节点的右子树
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> InOrderTravel3(TreeNode root){
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();  //后进先出
        TreeNode temp = root;

        while(stack.Count > 0 || temp != null)
        {
            //将root节点以及它的左子树全部入栈，直到没有左子树
            if(temp != null){
                stack.Push(temp);
                temp = temp.left;
            }
            else{
                //左子树走到头了 弹出栈顶元素就放入结果列表里
                temp = stack.Pop();
                res.Add(temp.val);
                //重复上面的步骤 开始处理右子树 
                temp = temp.right;
            }

        }
        return res;
    }


    public void InOrderTravelTest()
    {
        //先构建树
        TreeNode root = new TreeNode(1,null,null);
        TreeNode node1 = new TreeNode(2,null,null);
        TreeNode node2 = new TreeNode(3,null,null);
        TreeNode node3 = new TreeNode(4,null,null);

        root.right = node1;
        node1.left = node2;
        node1.right = node3;

        var list = InOrderTravel3(root);
        for(int i = 0; i < list.Count; i++){
            Console.WriteLine(list[i]);
        }
       
    }

}
