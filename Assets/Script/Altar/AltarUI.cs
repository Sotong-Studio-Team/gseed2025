using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.Bomber
{
    public class AltarUI : MonoBehaviour
    {
        public Button option1Button;
        public Button option2Button;
        private AltarStatUpgrade.PlayerStatType option1Stat;
        private AltarStatUpgrade.PlayerStatType option2Stat;
        private AltarController altar;

        public void Init(AltarStatUpgrade.PlayerStatType stat1, AltarStatUpgrade.PlayerStatType stat2,
            AltarController altarRef)
        {
            option1Stat = stat1;
            option2Stat = stat2;
            altar = altarRef;

            option1Button.GetComponentInChildren<Text>().text = stat1.ToString() + " +1";
            option2Button.GetComponentInChildren<Text>().text = stat2.ToString() + " +1";

            option1Button.onClick.RemoveAllListeners();
            option2Button.onClick.RemoveAllListeners();

            option1Button.onClick.AddListener(() => altar.OnOptionSelected(option1Stat));
            option2Button.onClick.AddListener(() => altar.OnOptionSelected(option2Stat));
        }
    }
}
