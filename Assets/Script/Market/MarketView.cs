using NaughtyAttributes;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio.Bomber
{
    public class MarketView : MonoBehaviour
    {
        [SerializeField] private GameObject _wholeUI;
        [SerializeField] private List<GameObject> _itemLid;

        public UnityEvent OnHealBought;
        public UnityEvent OnMaxHPBought;
        public UnityEvent OnSpeedBought;
        public UnityEvent OnBombBought;
        public UnityEvent OnExplosionBought;

        [Button]
        public void ShowUI()
        {
            _wholeUI.SetActive(true);
        }

        public void HideUI()
        {
            _wholeUI.SetActive(false);
        }

        public void OpenItem(int index)
        {
            _itemLid[index].SetActive(false);
        }

        public void Close(int index)
        {
            _itemLid[index].SetActive(true);
        }

        public void BuyHeal()
        {
            OnHealBought.Invoke();
        }

        public void BuyMaxHP()
        {
            OnMaxHPBought.Invoke();
        }

        public void BuySpeed()
        {
            OnSpeedBought.Invoke();
        }

        public void BuyMaxBomb()
        {
            OnBombBought.Invoke();
        }

        public void BuyExplosion()
        {
            OnExplosionBought.Invoke();
        }
    }
}
