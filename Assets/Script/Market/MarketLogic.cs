using SotongStudio.Bomber.Gameplay.HUD;
using TMPro;
using UnityEngine;
using VContainer;
using SotongStudio.Utilities.AudioSystem;
using SotongStudio.Bomber.Gameplay.LevelManager;
using System;

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
        private int _hpPrice => _hpBasePrice + (_hpBuyAmount * _hpIncreament);
        private int _speedPrice => _speedBasePrice + (_speedBuyAmount * _speedIncreament);
        private int _bombPrice => _bombBasePrice + (_bombBuyAmount * _bombIncreament);
        private int _explosionPrice => _explosionBasePrice + (_explosionBuyAmount * _explosionIncreament);

        private int _hpBasePrice = 15;
        private int _speedBasePrice = 5;
        private int _bombBasePrice = 10;
        private int _explosionBasePrice = 5;

        private int _hpBuyAmount = 0;
        private int _speedBuyAmount = 0;
        private int _bombBuyAmount = 0;
        private int _explosionBuyAmount = 0;

        [SerializeField]
        private int _hpIncreament = 15;
        [SerializeField]
        private int _speedIncreament = 5;
        [SerializeField]
        private int _bombIncreament = 10;
        [SerializeField]
        private int _explosionIncreament = 5;

        private IGameplayHudLogic _gameplayHUD;

        private void Start()
        {
            _view.HideUI();
            OpenShopItems();
            //_data.Setup();

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

            //_data.PrintStat();
        }

        [Inject]
        private void Inject(IGameplayHudLogic gameplayHUD,
                            ILevelManager levelManager)
        {
            _gameplayHUD = gameplayHUD;
            levelManager.OnChangeLevel.AddListener(RefreshShop);

        }

        private void RefreshShop(int level)
        {
            OpenShopItems();
        }

        private void OpenShopItems()
        {
            for (int i = 0; i <= 4; i++)
            {
                _view.OpenItem(i);
            }
            _view.UpdatePriceText(_hpPrice, _speedPrice, _bombPrice, _explosionPrice);
        }

        private bool IsCurrencyEnough(int price)
        {
            if (_data.GetCurrency() >= price)
            {
                _data.BuyingSucceed(price);
                _gameplayHUD.UpdateCrystal();
                return true;
            }
            else return false;
        }

        private void BuyHeal()
        {
            if (IsCurrencyEnough(_healPrice))
            {
                _view.Close(4);
                BasicAudioSystem.Instance.PlaySFX("accept market");
                _data.Heal();
            }
            _data.PrintStat();
        }

        private void BuyMaxHP()
        {
            if (IsCurrencyEnough(_hpPrice))
            {
                _view.Close(0);
                BasicAudioSystem.Instance.PlaySFX("accept market");
                _data.AddMaxHP();
                _hpBuyAmount++;
            }
            _data.PrintStat();
        }

        private void BuySpeed()
        {
            if (IsCurrencyEnough(_speedPrice))
            {
                _view.Close(1);
                BasicAudioSystem.Instance.PlaySFX("accept market");
                _data.AddSpeed();
                _speedBuyAmount++;
            }
            _data.PrintStat();
        }

        private void BuyMaxBomb()
        {
            if (IsCurrencyEnough(_bombPrice))
            {
                _view.Close(2);
                BasicAudioSystem.Instance.PlaySFX("accept market");
                _data.AddBomb();
                _bombBuyAmount++;
            }
            _data.PrintStat();
        }

        private void BuyExplosion()
        {
            if (IsCurrencyEnough(_explosionPrice))
            {
                _view.Close(3);
                BasicAudioSystem.Instance.PlaySFX("accept market");
                _data.AddExplosion();
                _explosionBuyAmount++;
            }
            _data.PrintStat();
        }
    }
}
