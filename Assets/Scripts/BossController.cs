using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private int aWorth, bWorth, cWorth, dWorth, eWorth;
    private int aStock, bStock, cStock, dStock, eStock;

    private int init_aWorth, init_bWorth, init_cWorth, init_dWorth, init_eWorth;
    private int init_aBuy, init_bBuy, init_cBuy, init_dBuy, init_eBuy;

    private float countTime;
    private int intervalTime;
    private int diceRoll;

    [SerializeField] private CompanyA companyA;
    [SerializeField] private CompanyB companyB;
    [SerializeField] private CompanyC companyC;
    [SerializeField] private CompanyD companyD;
    [SerializeField] private CompanyE companyE;

    // Start is called before the first frame update
    void Start()
    {
        init_aWorth = companyA.ReturnStockPrice();
        init_bWorth = companyB.ReturnStockPrice();
        init_cWorth = companyC.ReturnStockPrice();
        init_dWorth = companyD.ReturnStockPrice();
        init_eWorth = companyE.ReturnStockPrice();
    }

    // Update is called once per frame
    void Update()
    {
        countTime = Time.deltaTime;
        if(countTime >= intervalTime)
        {
            Placeholder();
            intervalTime = Random.Range(1, 4);
            countTime = 0;
        }
    }

    private void Placeholder()
    {

    }

    private void BossAction()
    {
        int selectedCompany = Random.Range(1, 5);
        switch (selectedCompany)
        {
            case 1:

                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;

            case 5:

                break;
        }
    }



    
}
