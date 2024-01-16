using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanyA : MonoBehaviour
{

    public int stockPrice = 1000;

    private int updateTime = 10;
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
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > 10f)
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
        stockPrice += Random.Range(20, 50);
        Debug.Log(stockPrice);
        textDisplay.text = "$" + stockPrice.ToString();
        UpdateWorth();
    }

    private void DecreasePrice()
    {
        stockPrice -= Random.Range(20, 50);
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
        bank.UpdateCompanyA(stockWorth);
    }
}
