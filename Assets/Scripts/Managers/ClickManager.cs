using UnityEngine;
public class ClickManager : MonoBehaviour
{
    private DataManager dataManager;
    private GameManager gameManager;
    private void Start()
    {
        dataManager = GetComponent<DataManager>();
        gameManager = GetComponent<GameManager>();
    }
    public void ClickSynergy()
    {
        dataManager.Synergy += dataManager.SynergyOnClick;
        EventManager.OnChangeSynergy();
    }
    public void ClickShards()
    {
        if (dataManager.Synergy >= dataManager.CostSynergy &&
            dataManager.MiningExp.AmountOfOverFlow(dataManager.MiningPower) > 0)
        {
            dataManager.MiningExp += dataManager.MiningPower;
            EventManager.OnChaneMiningExp();
            gameManager.RandomShard();
        }
        else if (dataManager.Synergy >= dataManager.CostSynergy)
        {
            dataManager.MiningExp += dataManager.MiningPower;
            EventManager.OnChaneMiningExp();
        }
    }
}
