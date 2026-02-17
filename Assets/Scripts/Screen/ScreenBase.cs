using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;


namespace Screens
{
    public enum ScreenType
    {
        MainMenu,
        Game,
        Pause,
        GameOver
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listObjects;
        public bool startHided = false;

        [Header("Animation")]
        public float delayBetweenObjects = 0.05f;
        public float animationDuration = 0.3f;


        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }


        [Button]
        protected virtual void Show() 
        {
            ShowObjects();
            Debug.Log("Show");
        }

        [Button]
        protected virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listObjects.Count; i++)
            {
                var obj = listObjects[i];
                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i*delayBetweenObjects);
            }
                
        }
        private void ForceShowObjects()
        {
            listObjects.ForEach(i => i.gameObject.SetActive(true));
        }
        private void HideObjects()
        {
            listObjects.ForEach(i => i.gameObject.SetActive(false));
        }
    }
}


