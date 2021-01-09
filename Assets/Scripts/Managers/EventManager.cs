using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnBuyDelegate(int type);
    public delegate void OnChangeSynergyDelegate();
    public static event OnBuyDelegate OnBuyEvent;
    public static event OnChangeSynergyDelegate OnChangeSynergyEvent;
    private TextManager tm;
    private void Start()
    {
        tm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextManager>();
        OnBuyEvent += tm.ChangeTextValues;
        OnChangeSynergyEvent += tm.ChangeSynergyValue;
    }
    public static void OnBuy(int type)
    {
        OnBuyEvent?.Invoke(type);
    }
    public static void OnChangeSynergy()
    {
        OnChangeSynergyEvent?.Invoke();
    }
    public static void OnChangePrimo()
    { 
        
    }
}
