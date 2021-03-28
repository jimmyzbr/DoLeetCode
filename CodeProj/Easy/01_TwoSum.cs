using System;

public sealed class Solution{
    public int[] TwoSum(int[] nums,int target){
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

    public void TwoSum_Test()
    {
        int[] nums = new int[] { 1, 8, 12, 87, 13 };
        int target = 20;

        int[] resIndex = TwoSum(nums, target);
        if(resIndex != null)
        {
            for (int i = 0; i < resIndex.Length; ++i)
            {
                Console.WriteLine(resIndex[i]);
            }
        }
    }
}