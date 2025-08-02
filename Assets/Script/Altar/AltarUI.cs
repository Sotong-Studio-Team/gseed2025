using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SotongStudio.Bomber
{
    public class AltarUI : MonoBehaviour
    {
        public Button acceptButton;
        public Button declineButton;
        public Button okButton; 
        
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI option1LabelText;
        public TextMeshProUGUI option2LabelText;

        public Image option1Background;  
        public Image option2Background;  

        private AltarStatUpgrade.PlayerStatType option1Stat;
        private AltarStatUpgrade.PlayerStatType option2Stat;
        private AltarController altar;

        private bool isAnimating = false;
        
        [SerializeField] private Color defaultBackgroundColor = Color.gray;
        [SerializeField] private Color blinkColor1 = Color.red;
        [SerializeField] private Color blinkColor2 = Color.blue;

        public void Init(AltarStatUpgrade.PlayerStatType stat1, AltarStatUpgrade.PlayerStatType stat2,
            AltarController altarRef) //inisialisasi
        {
            option1Stat = stat1;
            option2Stat = stat2;
            altar = altarRef;
            
            descriptionText.text =
                "You have the opportunity to get an <color=blue><b>INCREASE</b></color> or <color=red><b>DECREASE</b></color> in status below:";
            
            option1LabelText.text = FormatStatName(stat1);
            option2LabelText.text = FormatStatName(stat2);
            
            ResetVisuals();
            
            acceptButton.onClick.RemoveAllListeners();
            declineButton.onClick.RemoveAllListeners();
            acceptButton.onClick.AddListener(() => StartCoroutine(PlaySelectionAnimation()));
            declineButton.onClick.AddListener(() => altar.DisableAltar());
            
            acceptButton.gameObject.SetActive(true);
            declineButton.gameObject.SetActive(true);
            okButton.gameObject.SetActive(false); // sembunyikan tombol ok di awal
        }

        private void ResetVisuals() // default color
        {
            // set warna latar awal ke warna default
            option1Background.color = defaultBackgroundColor;
            option2Background.color = defaultBackgroundColor;
        }

        private IEnumerator PlaySelectionAnimation()    
        {
            if (isAnimating) yield break;
            isAnimating = true;

            float duration = 3f;
            float elapsed = 0f;
            float blinkInterval = 0.1f;
            bool isOption1Red = true;

            // sembunyikan tombol accept dan decline saat animasi dimulai
            acceptButton.gameObject.SetActive(false);
            declineButton.gameObject.SetActive(false);

            // ngerandom si statnya mana yang akan +1 dan -1 
            bool option1IsIncrease = Random.value > 0.5f;
            var increaseStat = option1IsIncrease ? option1Stat : option2Stat;
            var decreaseStat = option1IsIncrease ? option2Stat : option1Stat;

            // loop animasi blink 
            while (elapsed < duration)
            {
                if (isOption1Red)
                {
                    option1Background.color = blinkColor1;
                    option2Background.color = blinkColor2;
                }
                else
                {
                    option1Background.color = blinkColor2;
                    option2Background.color = blinkColor1;
                }

                isOption1Red = !isOption1Red;

                yield return new WaitForSeconds(blinkInterval);
                elapsed += blinkInterval;

                // blink menjadi semakin lambat
                blinkInterval = Mathf.Lerp(0.1f, 0.3f, elapsed / duration);
            }

            // tampilkan warna akhir dan update teks stat
            if (option1IsIncrease)
            {
                option1Background.color = blinkColor2;
                option2Background.color = blinkColor1;

                option1LabelText.text = FormatStatName(option1Stat) + " +1";
                option2LabelText.text = FormatStatName(option2Stat) + " -1";
            }
            else
            {
                option1Background.color = blinkColor1;
                option2Background.color = blinkColor2;

                option1LabelText.text = FormatStatName(option1Stat) + " -1";
                option2LabelText.text = FormatStatName(option2Stat) + " +1";
            }
            
            string increaseText = $"<color=blue>{FormatStatName(increaseStat)} +1</color>";
            string decreaseText = $"<color=red>{FormatStatName(decreaseStat)} -1</color>";
            descriptionText.text = $"Congratulations! You get, {increaseText} and {decreaseText}";
            
            okButton.gameObject.SetActive(true);
            
            okButton.onClick.RemoveAllListeners();
            okButton.onClick.AddListener(() =>
            {
                altar.OnOptionSelected(increaseStat); 
                isAnimating = false;
            });
        }

        private string FormatStatName(AltarStatUpgrade.PlayerStatType stat) // untuk nama stat
        {
            switch (stat)
            {
                case AltarStatUpgrade.PlayerStatType.ExplosionLength: return "Explosion Range";
                case AltarStatUpgrade.PlayerStatType.BombCount: return "Bomb Count";
                case AltarStatUpgrade.PlayerStatType.MovementSpeed: return "Movement Speed";
                case AltarStatUpgrade.PlayerStatType.MaxHealth: return "Max Health";
                default: return stat.ToString();
            }
        }
    }
}
