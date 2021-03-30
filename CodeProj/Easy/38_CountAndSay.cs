using System;

public partial class Solution
{
    //3322251
    public string CountAndSay(int n)
    {
        string s = "";
        for(int i = 1; i <= n; ++i)
        {
            if (i == 1)
                s = "1";
            else
            {
                string temp = "";
                int num = 0;
                int count = 0;

                for(int j = 0;j < s.Length;++j)
                {
                    int curNum = int.Parse(s[j].ToString());
                    if (j == 0 || curNum != num)
                    {
                        if (j != 0)
                            temp += string.Format("{0}{1}", count, num);
                        num = curNum;
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                }
                temp += string.Format("{0}{1}", count, num);
                s = temp;
            }
        }

        return s;
    }

    //递归写法
    public string CountAndSay2(int n)
    {
        //退出条件
        if (n == 1)
            return "1";
        return CountAndSay2(n - 1); //递归求解n-1的结果

        //求解过程


    }

    public void CountAndSayTest()
    {
        string s = CountAndSay(5);
        Console.Write(s);
    }
}