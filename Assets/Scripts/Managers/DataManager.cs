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
    public bool[] PurchasedLocation = new bool[9];
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
            CostSynergyCrystals = new long[] { 10, 10, 10, 10, 10, 10, 10, 10 };
            ChanceCrystals = new double[8, 3] { { 0, 0, 0.125 }, { 1, 0.125, 0.25 },
            { 2, 0.25, 0.375 }, { 3, 0.375, 0.5 }, { 4, 0.5, 0.625 }, { 5, 0.625, 0.75 },
            { 6, 0.75, 0.875 }, { 7, 0.825, 1 } };
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
