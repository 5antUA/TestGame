using UnityEngine;

namespace MainSpace.Root
{
    public class RootView : MonoBehaviour
    {
        [SerializeField] private Transform _sceneContainer;
        [SerializeField] private GameObject _loadingScreen;

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }

        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneContainer(_sceneContainer);

            sceneUI.transform.SetParent(_sceneContainer, false);
        }

        private void ClearSceneContainer(Transform container)
        {
            int childCount = container.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }

    }
}
