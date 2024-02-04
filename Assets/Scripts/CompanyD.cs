using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyD : MonoBehaviour
{

    private int stockPrice = 1200;

    private int updateTime = 7;
    private int diceRoll;
    private float timeCounter = 0.0f;

    public int totalStock = 0;
    public int stockWorth;

    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private TextMeshProUGUI stockDisplay;

    [SerializeField] private BankController bank;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Company A started");
        textDisplay.text = "$" + stockPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > updateTime)
        {
            Debug.Log("Update Started");
            StartCoroutine(UpdatePrice());
            timeCounter = 0.0f;
        }
    }

    private IEnumerator UpdatePrice()
    {
        yield return new WaitForSeconds(updateTime);
        diceRoll = Random.Range(0, 100);
        Debug.Log(diceRoll);
        if(diceRoll >= 50)
        {
            IncreasePrice();
        }
        if(diceRoll < 50)
        {
            DecreasePrice();
        }
        
    }

    private void IncreasePrice()
    {
        stockPrice += Random.Range(25, 40);
        Debug.Log(stockPrice);
        textDisplay.text = "$" + stockPrice.ToString();
        UpdateWorth();
    }

    private void DecreasePrice()
    {
        stockPrice -= Random.Range(40, 60);
        Debug.Log(stockPrice);
        textDisplay.text = "$" + stockPrice.ToString();
        UpdateWorth();
    }

    public void BuyStock(int number)
    {
        int balanceCheck = bank.ReturnBalance();
        int costCheck = number * stockPrice;

        if(balanceCheck >= costCheck)
        {
            totalStock += number;
            bank.ExchangeLiquid((-1 * costCheck));
            DisplayStock();
        }
        UpdateWorth();

    }

    public void SellStock(int number)
    {

        int saleValue = number * stockPrice;

        if(totalStock >= number)
        {
            totalStock -= number;
            bank.ExchangeLiquid(saleValue);
        }
        else if(totalStock < number)
        {
            int sellAllValue = totalStock * stockPrice;
            bank.ExchangeLiquid(sellAllValue);
            totalStock = 0;
        }
        DisplayStock();
        UpdateWorth();
    }

    private void DisplayStock()
    {
        stockDisplay.text = totalStock.ToString();
    }

    private void UpdateWorth()
    {
        stockWorth = totalStock * stockPrice;
        Debug.Log(stockWorth);
        bank.UpdateCompanyD(stockWorth);
    }

    public int ReturnStockPrice()
    {
        return stockPrice;
    }
}
