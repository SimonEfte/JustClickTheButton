using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using System.Collections.Generic;

public class InAppPurchase : MonoBehaviour, IDetailedStoreListener
{
    public static bool isAdsRemoved, is3Cps, is7Cps, is12Cps;
    public static int isAdsRemovedPlayerprefs, is3CpsPlayerpref, is7CpsPlayerpref, is12CpsPlayerpref;

    IStoreController m_StoreController;

    public RemoveAds removeAdsItem;
    public CPS3 cps3Item;
    public CPS7 cps7Item;
    public CPS12 cps12Item;

    private void Start()
    {
        if (MobileScript.isMobile == true)
        {
            SetupBuilder();
            isAdsRemovedPlayerprefs = PlayerPrefs.GetInt("isAdsRemoved");

            is3CpsPlayerpref = PlayerPrefs.GetInt("is3Cps");
            is7CpsPlayerpref = PlayerPrefs.GetInt("is7Cps");
            is12CpsPlayerpref = PlayerPrefs.GetInt("is12Cps");
        }
    }

    #region All Remove ADS stuff
    [Serializable]
    public class RemoveAds
    {
        public string Name;
        public string Id;
        public string desc;
        public float price;
    }

    [Serializable]
    public class CPS3
    {
        public string Name;
        public string Id;
        public string desc;
        public float price;
    }

    [Serializable]
    public class CPS7
    {
        public string Name;
        public string Id;
        public string desc;
        public float price;
    }

    [Serializable]
    public class CPS12
    {
        public string Name;
        public string Id;
        public string desc;
        public float price;
    }
    #endregion

    //[Obsolete]
    void SetupBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(removeAdsItem.Id, ProductType.NonConsumable);
        builder.AddProduct(cps3Item.Id, ProductType.NonConsumable);
        builder.AddProduct(cps7Item.Id, ProductType.NonConsumable);
        builder.AddProduct(cps12Item.Id, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        //  Debug.Log("Successful initialize");
        m_StoreController = controller;

        CheckNonConsumable(removeAdsItem.Id);
        Check3Cps(cps3Item.Id);
        Check7Cps(cps7Item.Id);
        Check12Cps(cps12Item.Id);
    }

    #region StoreListener Stuff
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Error" + error);
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.Log("Error" + error + message);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Error");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log("Error");
    }
    #endregion

    public void RemoveTheAd()
    {
        m_StoreController.InitiatePurchase(removeAdsItem.Id);
    }
    public void Get3Cps()
    {
        m_StoreController.InitiatePurchase(cps3Item.Id);
    }
    public void Get7Cps()
    {
        m_StoreController.InitiatePurchase(cps7Item.Id);
    }
    public void Get12Cps()
    {
        m_StoreController.InitiatePurchase(cps12Item.Id);
    }

    public MobileScript mobileScript;

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        //Retrive the purchased product
        var product = purchaseEvent.purchasedProduct;

        if (product.definition.id == removeAdsItem.Id)
        {
            //  Debug.Log("Purchase Complete " + product.definition.id);

            isAdsRemoved = true;
            isAdsRemovedPlayerprefs = 1;
            PlayerPrefs.SetInt("isAdsRemoved", isAdsRemovedPlayerprefs);
            PlayerPrefs.Save();
            mobileScript.CloseShopFrame();
        }

        if (product.definition.id == cps3Item.Id)
        {
            // Debug.Log("Purchase Complete " + product.definition.id);

            is3Cps = true;
            is3CpsPlayerpref = 1;
            PlayerPrefs.SetInt("is3Cps", is3CpsPlayerpref);
            PlayerPrefs.Save();
            MobileScript.autoClick = true;
            mobileScript.CloseShopFrame();
        }

        if (product.definition.id == cps7Item.Id)
        {
            //Debug.Log("Purchase Complete " + product.definition.id);

            is7Cps = true;
            is7CpsPlayerpref = 1;
            PlayerPrefs.SetInt("is7Cps", is7CpsPlayerpref);
            PlayerPrefs.Save();
            MobileScript.autoClick = true;
            mobileScript.CloseShopFrame();
        }

        if (product.definition.id == cps12Item.Id)
        {
            //Debug.Log("Purchase Complete " + product.definition.id);

            is12Cps = true;
            is12CpsPlayerpref = 1;
            PlayerPrefs.SetInt("is12Cps", is12CpsPlayerpref);
            PlayerPrefs.Save();
            MobileScript.autoClick = true;
            mobileScript.CloseShopFrame();
        }

        return PurchaseProcessingResult.Complete;
    }


    void CheckNonConsumable(string id)
    {
        if (m_StoreController != null)
        {
            var product = m_StoreController.products.WithID(id);

            if (product != null)
            {
                if (product.hasReceipt)
                {
                    isAdsRemoved = true;
                    isAdsRemovedPlayerprefs = 1;
                    PlayerPrefs.SetInt("isAdsRemoved", isAdsRemovedPlayerprefs);
                    PlayerPrefs.Save(); 
                }
                else
                {
                    isAdsRemoved = false;
                    isAdsRemovedPlayerprefs = 0;
                }
            }
        }
    }

    void Check3Cps(string id)
    {
        if (m_StoreController != null)
        {
            var product = m_StoreController.products.WithID(id);

            if (product != null)
            {
                if (product.hasReceipt)
                {
                    is3Cps = true;
                    is3CpsPlayerpref = 1;
                    PlayerPrefs.SetInt("is3Cps", is3CpsPlayerpref);
                    PlayerPrefs.Save();
                    MobileScript.autoClick = true;
                }
                else
                {
                    is3Cps = false;
                    is3CpsPlayerpref = 0;
                }
            }
        }
    }

    void Check7Cps(string id)
    {
        if (m_StoreController != null)
        {
            var product = m_StoreController.products.WithID(id);

            if (product != null)
            {
                if (product.hasReceipt)
                {
                    is7Cps = true;
                    is7CpsPlayerpref = 1;
                    PlayerPrefs.SetInt("is7Cps", is7CpsPlayerpref);
                    PlayerPrefs.Save();
                    MobileScript.autoClick = true;
                }
                else
                {
                    is7Cps = false;
                    is7CpsPlayerpref = 0;
                }
            }
        }
    }

    void Check12Cps(string id)
    {
        if (m_StoreController != null)
        {
            var product = m_StoreController.products.WithID(id);

            if (product != null)
            {
                if (product.hasReceipt)
                {
                    is12Cps = true;
                    is12CpsPlayerpref = 1;
                    PlayerPrefs.SetInt("is12Cps", is12CpsPlayerpref);
                    PlayerPrefs.Save();
                    MobileScript.autoClick = true; 
                }
                else
                {
                    is12Cps = false;
                    is12CpsPlayerpref = 0;
                }
            }
        }
    }
}
