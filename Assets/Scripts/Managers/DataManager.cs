using UnityEngine;
using System;
using System.IO;
using TintDomain;

public class DataManager : MonoBehaviour
{
    public long Synergy, SynergyOnClick,
        PrimoCrystal, UniversalCrystal, UniversalShard, Gems,
        MiningPower, MiningLvl, CostSynergy, DroppedShards, DropChancePrimo;
    public llong MiningExp { get; set; }
    public long[] SynergyCrystals;
    public long[] SynergyShards;
    public long[] CostSynergyCrystals;
    public bool[] PurchasedLocation;
    public double[,] ChanceCrystals;
    public DateTime FreeChest, PastTime;
    private string DataPath;
    private void Awake()
    {
        DataPath = Application.persistentDataPath + "/Data.json";
        LoadData();
    }
    [Serializable]
    private class Data
    {
        public long synergy, synergyOnClick, primoCrystal, universalCrystal,
            universalShard, gems, miningPower, miningLvl, costSynergy, droppedShards,
            dropChancePrimo;
        public llong miningExp;
        public long[] synergyCrystals, synergyShards;
        public long[] costSynergyCrystals;
        public bool[] purchasedLocation;
        public double[] chanceCrystals;
        public int rows, columns;
        public long freeChestTimeLeft, pastTime;
        public Data(DataManager dt) 
        {
            synergy = dt.Synergy;
            synergyOnClick = dt.SynergyOnClick;
            primoCrystal = dt.PrimoCrystal;
            universalCrystal = dt.UniversalCrystal;
            universalShard = dt.UniversalShard;
            gems = dt.Gems;
            miningPower = dt.MiningPower;
            miningLvl = dt.MiningLvl;
            miningExp = dt.MiningExp;
            costSynergy = dt.CostSynergy;
            droppedShards = dt.DroppedShards;
            synergyCrystals = dt.SynergyCrystals;
            synergyShards = dt.SynergyShards;
            costSynergyCrystals = dt.CostSynergyCrystals;
            dropChancePrimo = dt.DropChancePrimo;
            purchasedLocation = dt.PurchasedLocation;
            chanceCrystals = TransformArray.TransformToOne(dt.ChanceCrystals);
            rows = dt.ChanceCrystals.GetUpperBound(0) + 1;
            columns = dt.ChanceCrystals.GetUpperBound(1) + 1;
            freeChestTimeLeft = dt.FreeChest.ToFileTimeUtc();
            pastTime = DateTime.Now.ToFileTimeUtc();
        }
    }
    private void LoadData()
    {
        if (File.Exists(DataPath))
        {
            Data data = JsonUtility.FromJson<Data>(File.ReadAllText(DataPath));
            Synergy = data.synergy;
            SynergyOnClick = data.synergyOnClick;
            PrimoCrystal = data.primoCrystal;
            UniversalCrystal = data.universalCrystal;
            UniversalShard = data.universalShard;
            Gems = data.gems;
            MiningPower = data.miningPower;
            MiningLvl = data.miningLvl;
            MiningExp = data.miningExp;
            CostSynergy = data.costSynergy;
            DroppedShards = data.droppedShards;
            SynergyCrystals = data.synergyCrystals;
            SynergyShards = data.synergyShards;
            CostSynergyCrystals = data.costSynergyCrystals;
            DropChancePrimo = data.dropChancePrimo;
            PurchasedLocation = data.purchasedLocation;
            ChanceCrystals = TransformArray.TransformToTwo(data.chanceCrystals,
                data.rows, data.columns);
            FreeChest = DateTime.FromFileTimeUtc(data.freeChestTimeLeft);
            PastTime = DateTime.Now;
        }
        else
        {
            SynergyOnClick = 1;
            MiningPower = 1;
            CostSynergy = 10;
            DropChancePrimo = 5;
            MiningExp = new llong(0, 10);
            PurchasedLocation = new bool[9];
            CostSynergyCrystals = new long[] { 10, 10, 10, 10, 10, 10, 10, 10 };
            ChanceCrystals = DropChanceCrystals.ChanceCrystals;
            FreeChest = DateTime.Now.AddMinutes(30);
        }
    }
    public void SaveData()
    {
        Data data = new Data(this);
        File.WriteAllText(DataPath, JsonUtility.ToJson(data));
    }
    private void OnApplicationFocus(bool focus)
    {
        SaveData();
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
