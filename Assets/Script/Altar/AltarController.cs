using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using SotongStudio.Bomber.Gameplay.Bomb;
using SotongStudio.Bomber.Gameplay.Character.DataService;
using SotongStudio.Bomber.Gameplay.HUD;

namespace SotongStudio.Bomber
{
    public class AltarController : MonoBehaviour
    {
        [SerializeField] private GameObject altarPopupUI;
        [SerializeField] private AltarUI altarUI;

        private IBombGameplayUpdateService _bombUpdateService;
        private IBombGameplayDataService _bombDataService;
        private ICharacterGameplayUpdateService _charUpdateService;
        private ICharacterGameplayDataService _charDataService;
        private IGameplayHudLogic _hudLogic;

        // Batas minimum stat
        private const int MIN_HEALTH = 3;
        private const int MIN_SPEED = 1;
        private const int MIN_BOMB_COUNT = 1;
        private const int MIN_EXPLOSION_RANGE = 1;

        private readonly List<AltarStatUpgrade.PlayerStatType> allStats = new()
        {
            AltarStatUpgrade.PlayerStatType.ExplosionLength,
            AltarStatUpgrade.PlayerStatType.BombCount,
            AltarStatUpgrade.PlayerStatType.MovementSpeed,
            AltarStatUpgrade.PlayerStatType.MaxHealth
        };

        private bool isPopupShown = false;

        
        private AltarStatUpgrade.PlayerStatType _currentOption1;
        private AltarStatUpgrade.PlayerStatType _currentOption2;
        
        [Inject]
        public void Inject(
            IBombGameplayUpdateService bombUpdateService,
            IBombGameplayDataService bombDataService,
            ICharacterGameplayUpdateService charUpdateService,
            ICharacterGameplayDataService charDataService,
            IGameplayHudLogic hudLogic)
        {
            _bombUpdateService = bombUpdateService;
            _bombDataService = bombDataService;
            _charUpdateService = charUpdateService;
            _charDataService = charDataService;
            _hudLogic = hudLogic;
        }



        /*private void Update()
        {
            //TESTING dengan inputan : A
           if (Input.GetKeyDown(KeyCode.C) && !isPopupShown)
           {
               ShowAltar();
          }
        }*/
        
        public void ShowAltar() // fungsi yang akan dipanggil untuk mengshow sekaligus merandom stat yang disediakan. 
        {
            isPopupShown = true;
            altarPopupUI.SetActive(true);

            var randomOptions = allStats.OrderBy(_ => Random.value).ToList();
            _currentOption1 = randomOptions[0];
            _currentOption2 = randomOptions[1];

            altarUI.Init(_currentOption1, _currentOption2, this);
        }
        
        public void DisableAltar() // fungsi yang akan dipanggil untuk menghilangkan altar. 
        {
            isPopupShown = false;
            altarPopupUI.SetActive(false);
        }

        public void OnOptionSelected(AltarStatUpgrade.PlayerStatType increasedStat) // option terpilih
        {
            var decreasedStat = (increasedStat == _currentOption1) ? _currentOption2 : _currentOption1;

            IncreaseStat(increasedStat);
            DecreaseStat(decreasedStat);

            altarPopupUI.SetActive(false);
            isPopupShown = false;
        }

        private void IncreaseStat(AltarStatUpgrade.PlayerStatType stat) // untuk meningkatkan stat
        {
            switch (stat)
            {
                case AltarStatUpgrade.PlayerStatType.ExplosionLength:
                    _bombUpdateService.AddBombRange(1);
                    break;
                case AltarStatUpgrade.PlayerStatType.BombCount:
                    _charUpdateService.AddBombAmount(1); // Ubah ke AddBombCount jika ada
                    break;
                case AltarStatUpgrade.PlayerStatType.MovementSpeed:
                    _charUpdateService.AddPlayerSpeed(1);
                    break;
                case AltarStatUpgrade.PlayerStatType.MaxHealth:
                    _charUpdateService.AddPlayerMaxHealth(1);
                    break;
            }

            _hudLogic.UpdateAllStat();
        }

        private void DecreaseStat(AltarStatUpgrade.PlayerStatType stat) // untuk decrease stat
        {
            switch (stat)
            {
                case AltarStatUpgrade.PlayerStatType.ExplosionLength:
                    if (_bombDataService.GetBombRange() > MIN_EXPLOSION_RANGE)
                        _bombUpdateService.ReduceBombRange(1);
                    else
                        Debug.Log("Explosion Length sudah di batas minimum!");
                    break;

                case AltarStatUpgrade.PlayerStatType.BombCount:
                    if ( _charDataService.GetBombAmount() > MIN_BOMB_COUNT) // asumsi bomb count = bomb damage
                        _charUpdateService.ReduceBombAmount(1);
                    else
                        Debug.Log("Bomb Count sudah di batas minimum!");
                    break;

                case AltarStatUpgrade.PlayerStatType.MovementSpeed:
                    if (_charDataService.GetCharacterSpeed() > MIN_SPEED)
                    {
                        _charUpdateService.ReducePlayerSpeed(1);
                    }
                    else
                    {
                        Debug.Log("Movement Speed sudah di batas minimum!");
                    }
                    break;

                case AltarStatUpgrade.PlayerStatType.MaxHealth:
                    if (_charDataService.GetCharacterMaxHealth() > MIN_HEALTH)
                    {
                        _charUpdateService.ReducePlayerMaxHealth(1);
                    }
                    else
                    {
                        Debug.Log("Max HP sudah di batas minimum!");
                    }
                    break;
            }

            _hudLogic.UpdateAllStat();
        }

    }
}
