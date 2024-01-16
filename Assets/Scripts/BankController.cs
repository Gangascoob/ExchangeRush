using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankController : MonoBehaviour
{
    /*
    private int CompanyAStock;
    private int CompanyBStock;
    private int CompanyCStock;
    private int CompanyDStock;
    private int CompanyEStock;

    private int CompanyAWorth;
    private int CompanyBWorth;
    private int CompanyCWorth;
    private int CompanyDWorth;
    private int CompanyEWorth;
    */

    private int CompanyATotal;
    private int CompanyBTotal;
    private int CompanyCTotal;
    private int CompanyDTotal;
    private int CompanyETotal;

    private int liquidBalance = 25000;
    private int totalWorth = 25000;
    private int stockValue = 0;

    private float updateTimer;

    [SerializeField] private TextMeshProUGUI stockText;
    [SerializeField] private TextMeshProUGUI liquidText;
    [SerializeField] private TextMeshProUGUI worthText;

    void Start()
    {
        UpdateWorth();
    }


    private void UpdateWorth()
    {
        Debug.Log("Company A Total is: " + CompanyATotal);
        stockValue = CompanyATotal + CompanyBTotal + CompanyCTotal + CompanyDTotal + CompanyETotal;
        Debug.Log("Stock Value is: " + stockValue);
        totalWorth = stockValue + liquidBalance;
        stockText.text = "$" + stockValue.ToString();
        liquidText.text = "$" + liquidBalance.ToString();
        worthText.text = "$" + totalWorth.ToString();
    }

    /*
    private void UpdateLiquid()
    {
        liquidText.text = "$" + liquidBalance.ToString();
    }
    */

    public void UpdateCompanyA(int stockWorth)
    {
        CompanyATotal = stockWorth;
        UpdateWorth();
    }
    
    public void UpdateCompanyB(int stockWorth)
    {
        CompanyBTotal = stockWorth;
        UpdateWorth();
    }

    public void UpdateCompanyC(int stockWorth)
    {
        CompanyCTotal = stockWorth;
        UpdateWorth();
    }

    public void UpdateCompanyD(int stockWorth)
    {
        CompanyDTotal = stockWorth;
        UpdateWorth();
    }

    public void UpdateCompanyE(int stockWorth)
    {
        CompanyETotal = stockWorth;
        UpdateWorth();
    }

    public void ExchangeLiquid(int value)
    {
        if(value > 0)
        {
            liquidBalance += value;
        }
        else if(value < 0)
        {
            liquidBalance += value;
        }
        UpdateWorth();
    }

    public int ReturnBalance()
    {
        return liquidBalance;
    }

    

}
