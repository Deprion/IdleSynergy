using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnBuyDelegate(int type);
    public delegate void OnChangeSynergyDelegate();
    public delegate void OnChaneMiningExpDelegate();
    public static event OnBuyDelegate OnBuyEvent;
    public static event OnChangeSynergyDelegate OnChangeSynergyEvent;
    public static event OnChaneMiningExpDelegate OnChaneMiningExpEvent;
    private TextManager tm;
    private void Start()
    {
        tm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextManager>();
        OnBuyEvent += tm.ChangeTextValues;
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
    public static void OnChaneMiningExp()
    {
        OnChaneMiningExpEvent?.Invoke();
    }
}
