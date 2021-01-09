using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DataManager dt;
    private GameHandler gh;
    private float time = 1.0f;
    private void Start()
    {
        dt = GetComponent<DataManager>();
        gh = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
    }
    public void CreateCrystals(int type, int amount)
    {
        if (dt.PrimoCrystal >= amount * (dt.CostSynergyCrystals[type]/10) && 
            dt.SynergyShards[type] >= amount * dt.CostSynergyCrystals[type])
        {
            dt.PrimoCrystal -= (long)(amount * (dt.CostSynergyCrystals[type] / 10));
            dt.SynergyShards[type] -= (long)(amount * dt.CostSynergyCrystals[type]);
            dt.SynergyCrystals[type] += amount;
            dt.CostSynergyCrystals[type] += amount * 0.1f;
            EventManager.OnBuy(type);
        }
    }
    public void AddPrimo(int amount)
    {
        dt.PrimoCrystal += amount;
        EventManager.OnChangePrimo();
    }
    public void RandomShard()
    {
        if (dt.Synergy >= dt.CostSynergy)
        {
            dt.Synergy -= dt.CostSynergy;
            int num = Random.Range(0, 8);
            int primoCrystalChance = Random.Range(0, 101);
            dt.SynergyShards[num] += 1;
            dt.CostSynergy += (long)(dt.CostSynergy * 0.1);
            EventManager.OnChangeSynergy();
            gh.GenerateRandomShardInScene(num);
            gh.GenerateRandomPrimoInScene(primoCrystalChance);
        }
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            int summary = 0;
            foreach (int num in dt.SynergyCrystals)
            {
                summary += num;
            }
            dt.Synergy += summary;
            EventManager.OnChangeSynergy();
            time = 1.0f;
        }
    }
}
