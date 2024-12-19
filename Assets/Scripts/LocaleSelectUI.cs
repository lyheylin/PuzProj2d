using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class LocaleSelectScene : MonoBehaviour {
    [SerializeField] private Button enButton;
    [SerializeField] private Button zhButton;
    [SerializeField] private Button confirmButton;
    [SerializeField] private TMPro.TextMeshProUGUI confirmButtonTMP;

    private void Awake() {
        //var localizer = gameObject.AddComponent<GameObjectLocalizer>();
        //var trackedText = localizer.GetTrackedObject<TrackedUGuiGraphic>(text);


        enButton.onClick.AddListener(()=> {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        }
        );

        zhButton.onClick.AddListener(() => {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
        );

        confirmButton.onClick.AddListener(() => { 
            
        }
        );
    }
}
