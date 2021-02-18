using UnityEngine;
public class TransformArray : MonoBehaviour
{
    public static T[] TransformToOne<T>(T[,] array)
    {
        int columns = array.GetUpperBound(1) + 1;
        int rows = array.GetUpperBound(0) + 1;
        T[] arrayToReturn = new T[rows * columns];
        int k = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                arrayToReturn[k++] = array[i, j];
        return arrayToReturn;
    }
    public static T[,] TransformToTwo<T>(T[] array, int r, int c)
    {
        T[,] arrayToReturn = new T[r, c];
        int k = 0;
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                arrayToReturn[i, j] = array[k++];
        return arrayToReturn;
    }
}
