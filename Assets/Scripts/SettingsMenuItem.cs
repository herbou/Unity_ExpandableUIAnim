using UnityEngine ;
using UnityEngine.UI ;

public class SettingsMenuItem : MonoBehaviour {
   [HideInInspector] public Image img ;
   [HideInInspector] public RectTransform rectTrans ;

   //SettingsMenu reference
   SettingsMenu settingsMenu ;

   //item button
   Button button ;

   //index of the item in the hierarchy
   int index ;

   void Awake () {
      img = GetComponent<Image> () ;
      rectTrans = GetComponent<RectTransform> () ;

      settingsMenu = rectTrans.parent.GetComponent <SettingsMenu> () ;

      //-1 to ignore the main button
      index = rectTrans.GetSiblingIndex () - 1 ;

      //add click listener
      button = GetComponent<Button> () ;
      button.onClick.AddListener (OnItemClick) ;
   }

   void OnItemClick () {
      settingsMenu.OnItemClick (index) ;
   }

   void OnDestroy () {
      //remove click listener to avoid memory leaks
      button.onClick.RemoveListener (OnItemClick) ;
   }
}
