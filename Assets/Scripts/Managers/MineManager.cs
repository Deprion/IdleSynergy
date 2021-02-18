using UnityEngine;
using UnityEngine.UI;

public class MineManager : MonoBehaviour
{
    public Sprite[] BackGroundImages = new Sprite[10];
    public CurrentMine CurrentWorld = new CurrentMine();
    public GameObject MineObj;
    private DataManager dt;
    public enum CurrentMine
    { 
        Black = 0,
        Blue = 1,
        Cyan = 2,
        Green = 3,
        Pink = 4,
        Red = 5,
        Yeelow = 6,
        White = 7,
        Primo = 8,
        Standart = 9
    }
    private void Start()
    {
        CurrentWorld = CurrentMine.Standart;
        dt = GetComponent<DataManager>();
        MineObj.GetComponent<Image>().sprite = BackGroundImages[9];
    }
    public void BuyNewWorld(byte id)
    { 
        
    }
    public void ChangeWorld(byte id)
    {
        if (dt.PurchasedLocation[id] == true)
        {
            CurrentWorld = (CurrentMine)id;
            print((CurrentMine)id);
            MineObj.GetComponent<Image>().sprite = BackGroundImages[id];
            switch (CurrentWorld)
            { 
                
            }
        }
        else
        {
            BuyNewWorld(id);
        }
    }
}