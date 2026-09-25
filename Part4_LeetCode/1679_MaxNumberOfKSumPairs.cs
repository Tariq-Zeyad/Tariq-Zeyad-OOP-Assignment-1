using System;

namespace Object_OrientedOOP.Part4_LeetCode
{
    public class _1679_MaxNumberOfKSumPairs
    {
        public int MaxOperations(int[] nums, int k)
        {
            Array.Sort(nums);

            int left = 0;
            int right = nums.Length - 1;
            int count = 0;

            while (left < right)
            {
                int sum = nums[left] + nums[right];

                if (sum == k)
                {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < k)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return count;
        }
    }
}