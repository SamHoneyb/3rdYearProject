using UnityEngine;
using TMPro;

public class AbilityCountHUD : MonoBehaviour
{

    public TMP_Text HeavyMoveOwnedTxt;
    public TMP_Text HealthMoveOwnedTxt;
    public TMP_Text FreezeMoveOwnedTxt;
    public TMP_Text QuakeMoveOwnedTxt;
    public TMP_Text RangeMoveOwnedTxt;
    public Shop Shop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Shop = FindObjectOfType<Shop>();
        SetUIVariables();
    }

    // Update is called once per frame
    void Update()
    {
        SetUIVariables();
    }

    public void SetUIVariables()
    {
        SetFreezeOwned();
        SetHealthOwned();
        SetQuakeOwned();
        SetRangeOwned();
        SetHeavyOwned();
    }

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
