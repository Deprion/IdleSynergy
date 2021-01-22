[System.Serializable]
public struct llong
{
    public long Current;
    public long Limit;

    public static bool operator +(llong num1, long num2)
    {
        if (num1.Current + num2 > num1.Limit)
        {
            num1.Current = num1.Current + num2 - num1.Limit;
            return true;
        }
        else
        {
            num1.Current += num2;
            return false;
        }
    }
    public llong(long c, long l)
    {
        Current = c;
        Limit = l;
    }
}