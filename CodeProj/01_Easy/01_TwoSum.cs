using System;
using System.Collections.Generic;

public partial class Solution{

    public int[] TwoSum(int[] nums,int target){
        //暴力枚举法 时间复杂度O(N*N)
        int len = nums.Length;
        for(int i = 0; i < len - 1; ++i)
        {
            for(int j = i+1; j < len; ++j)
            {
                if (nums[i] + nums[j] == target)
                    return new int[] { i,j};
            }
        }
        return null;

    }


    //用map的key 和value 去映射 时间复杂度o(1）
    public int[] TwoSum2(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int len = nums.Length;
        for (int i = 0; i < len; ++i)     
        {
            var key = nums[i];
            if (map.ContainsKey(key)) 
            {
                return new int[2] { map[key], i };
            }
            else
            {
                map.Add(target - key, i);
            }
        }
        return null;
    }




    public void TwoSum_Test()
    {
        int[] nums = new int[] { 1, 8, 12, 87, 13 };
        int target = 20;

        int[] resIndex = TwoSum2(nums, target);
        if(resIndex != null)
        {
            for (int i = 0; i < resIndex.Length; ++i)
            {
                Console.WriteLine(resIndex[i]);
            }
        }
    }
}