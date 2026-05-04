using UnityEngine;
using TMPro;

public class AbilityCountHUD : MonoBehaviour
{
    //sets the buttons and assets in unity as variables
    public TMP_Text HeavyMoveOwnedTxt;
    public TMP_Text HealthMoveOwnedTxt;
    public TMP_Text FreezeMoveOwnedTxt;
    public TMP_Text QuakeMoveOwnedTxt;
    public TMP_Text RangeMoveOwnedTxt;
    public Shop Shop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //finds the shop object
        Shop = FindObjectOfType<Shop>();
        SetUIVariables();
    }

    void Update()
    {
        SetUIVariables();
    }

    //sets all the variables
    public void SetUIVariables()
    {
        SetFreezeOwned();
        SetHealthOwned();
        SetQuakeOwned();
        SetRangeOwned();
        SetHeavyOwned();
    }

    //sets the HUDS ability numbers
    public void SetHeavyOwned()
    {
        HeavyMoveOwnedTxt.text = Shop.heavyOwned.ToString();
    }
    public void SetHealthOwned()
    {
        HealthMoveOwnedTxt.text = Shop.healthOwned.ToString();
    }
    public void SetFreezeOwned()
    {
        FreezeMoveOwnedTxt.text = Shop.freezeOwned.ToString();
    }
    public void SetQuakeOwned()
    {
        QuakeMoveOwnedTxt.text = Shop.quakeOwned.ToString();
    }
    public void SetRangeOwned()
    {
        RangeMoveOwnedTxt.text = Shop.rangeOwned.ToString();
    }
}
