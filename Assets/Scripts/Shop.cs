using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Shop : MonoBehaviour
{
    public int healthOwned;
    public int heavyOwned;
    public int freezeOwned;
    public int quakeOwned;
    public int rangeOwned;
    public ScenarioCall scenarioCall;
    public int healthCost = 50;
    public int heavyCost = 20;
    public int freezeCost = 50;
    public int quakeCost = 50;
    public int rangeCost = 10;

    public TMP_Text MoneyCountTxt;
    public TMP_Text HealthCostTxt;
    public TMP_Text FreezeCostTxt;
    public TMP_Text RangeCostTxt;
    public TMP_Text QuakeCostTxt;
    public TMP_Text HeavyCostTxt;

    public TMP_Text HealthQuantityTxt;
    public TMP_Text FreezeQuantityTxt;
    public TMP_Text RangeQuantityTxt;
    public TMP_Text QuakeQuantityTxt;
    public TMP_Text HeavyQuantityTxt;





    void Start()
    {
        scenarioCall = FindObjectOfType<ScenarioCall>();

        MoneyCountTxt.text = scenarioCall.money.ToString();

        HealthCostTxt.text = "Cost: " + healthCost.ToString();
        FreezeCostTxt.text = "Cost: " + freezeCost.ToString();
        RangeCostTxt.text = "Cost: " + rangeCost.ToString();
        QuakeCostTxt.text = "Cost: " + quakeCost.ToString();
        HeavyCostTxt.text = "Cost:  " + heavyCost.ToString();
    }

    //purchases the ability and adds one to the players count 
    public void PurchaseHealthAbility()
    {
        if (scenarioCall.money < healthCost)
        {

        }
        else
        {
            healthOwned += 1;
            scenarioCall.money -= healthCost;
            HealthQuantityTxt.text = "Quantity: " + healthOwned.ToString();
            MoneyCountTxt.text = scenarioCall.money.ToString();
            CheckMoney();
        }

    }
    //purchases the ability and adds one to the players count 
    public void PurchaseHeavyAbility()
    {
        if (scenarioCall.money < heavyCost)
        {

        }
        else
        {
            heavyOwned += 1;
            scenarioCall.money -= heavyCost;
            HeavyQuantityTxt.text = "Quantity: " + heavyOwned.ToString();
            MoneyCountTxt.text = scenarioCall.money.ToString();
            CheckMoney();
        }

    }
    //purchases the ability and adds one to the players count 
    public void PurchaseFreezeAbility()
    {
        if (scenarioCall.money < freezeCost)
        {

        }
        else
        {
            freezeOwned += 1;
            scenarioCall.money -= freezeCost;
            FreezeQuantityTxt.text = "Quantity: " + freezeOwned.ToString();
            MoneyCountTxt.text = scenarioCall.money.ToString();
            CheckMoney();
        }

    }

    //purchases the ability and adds one to the players count 
    public void PurchaseQuakeAbility()
    {
        if (scenarioCall.money < quakeCost)
        {

        }
        else
        {
            quakeOwned += 1;
            scenarioCall.money -= quakeCost;
            QuakeQuantityTxt.text = "Quantity: " + quakeOwned.ToString();
            MoneyCountTxt.text = scenarioCall.money.ToString();
            CheckMoney();
        }

    }

    //purchases the ability and adds one to the players count 
    public void PurchaseRangeAbility()
    {
        if (scenarioCall.money < rangeCost)
        {

        }
        else
        {
            rangeOwned += 1;
            scenarioCall.money -= rangeCost;
            RangeQuantityTxt.text = "Quantity: " + rangeOwned.ToString();
            MoneyCountTxt.text = scenarioCall.money.ToString();
            CheckMoney();
        }

    }

    //checks if the player has enough money to buy the ability
    void CheckMoney()
    {
        if(scenarioCall.money == 0)
        {
            SceneManager.LoadSceneAsync("Game");
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
