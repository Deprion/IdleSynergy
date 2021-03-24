using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text AmountSynergy;
    public Slider AmountMining;
    private CrystalsButtonHandler crButtonHandler;
    private DataManager dt;
    private void Start()
    {
        GameObject objHandler = GameObject.FindGameObjectWithTag("GameHandler");
        GameObject objManager = GameObject.FindGameObjectWithTag("GameManager");
        dt = objManager.GetComponent<DataManager>();
        crButtonHandler = objHandler.GetComponent<CrystalsButtonHandler>();
        AmountSynergy.text = dt.Synergy.ToString();
        AmountMining.maxValue = dt.MiningExp.Limit;
        AmountMining.value = dt.MiningExp.Current;
        for (int i = 0; i < 8; i++)
        {
            crButtonHandler.CrystalsAmount[i].text = dt.SynergyCrystals[i].ToString();
        }
        EventManager.OnChaneMiningExpEvent += ChangeMiningValue;
        EventManager.OnChangeSynergyEvent += ChangeSynergyValue;
    }
    public void ChangeTextValues(int type)
    {
        crButtonHandler.CrystalsAmount[type].text = dt.SynergyCrystals[type].ToString();
        crButtonHandler.CurrentAmount.text = $"Current shards:{dt.SynergyShards[type]}" +
            $"\nCurrent primo:{dt.PrimoCrystal}";
    }
    public void ChangeSynergyValue()
    {
        AmountSynergy.text = dt.Synergy.ToString();
    }
    public void ChangeMiningValue()
    {
        AmountMining.value = dt.MiningExp.Current;
    }
}
