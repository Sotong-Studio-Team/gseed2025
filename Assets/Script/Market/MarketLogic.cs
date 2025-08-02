using TMPro;
using UnityEngine;

namespace SotongStudio.Bomber
{
    public class MarketLogic : MonoBehaviour
    {
        [SerializeField] private MarketView _view;
        [SerializeField] private MarketDataTest _data;

        [SerializeField] private TextMeshProUGUI _healPriceText;
        [SerializeField] private TextMeshProUGUI _hpPriceText;
        [SerializeField] private TextMeshProUGUI _speedPriceText;
        [SerializeField] private TextMeshProUGUI _bombPriceText;
        [SerializeField] private TextMeshProUGUI _explosionPriceText;

        private int _healPrice = 3;
        private int _hpPrice = 15;
        private int _speedPrice = 5;
        private int _bombPrice = 10;
        private int _explosionPrice = 5;

        private void Start()
        {
            _view.HideUI();
            OpenShopItems();
            _data.Setup();

            _view.OnHealBought.AddListener(BuyHeal);
            _view.OnMaxHPBought.AddListener(BuyMaxHP);
            _view.OnSpeedBought.AddListener(BuySpeed);
            _view.OnBombBought.AddListener(BuyMaxBomb);
            _view.OnExplosionBought.AddListener(BuyExplosion);

            _healPriceText.text = _healPrice.ToString();
            _hpPriceText.text = _hpPrice.ToString();
            _speedPriceText.text = _speedPrice.ToString();
            _bombPriceText.text = _bombPrice.ToString();
            _explosionPriceText.text = _explosionPrice.ToString();

            _data.PrintStat();
        }

        private void OpenShopItems()
        {
            for (int i = 0; i < 4; i++)
            {
                _view.OpenItem(i);
            }
        }

        private bool IsCurrencyEnough(int price)
        {
            if (_data.GetCurrency() >= price)
            {
                _data.BuyingSucceed(price);
                return true;
            }
            else return false;
        }

        private void BuyHeal()
        {
            if (IsCurrencyEnough(_healPrice))
            {
                _view.Close(4);
                _data.Heal();
            }
            _data.PrintStat();
        }

        private void BuyMaxHP()
        {
            if (IsCurrencyEnough(_hpPrice))
            {
                _view.Close(0);
                _data.AddMaxHP();
            }
            _data.PrintStat();
        }

        private void BuySpeed()
        {
            if (IsCurrencyEnough(_speedPrice))
            {
                _view.Close(1);
                _data.AddSpeed();
            }
            _data.PrintStat();
        }

        private void BuyMaxBomb()
        {
            if (IsCurrencyEnough(_bombPrice))
            {
                _view.Close(2);
                _data.AddBomb();
            }
            _data.PrintStat();
        }

        private void BuyExplosion()
        {
            if (IsCurrencyEnough(_explosionPrice))
            {
                _view.Close(3);
                _data.AddExplosion();
            }
            _data.PrintStat();
        }
    }
}
