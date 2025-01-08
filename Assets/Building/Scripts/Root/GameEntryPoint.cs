using UnityEngine;
using MainSpace.Utils;
using System.Collections;
using UnityEngine.SceneManagement;
using DI;
using MainSpace.Game.Root;

namespace MainSpace.Root
{
    public class GameEntryPoint
    {
        private static GameEntryPoint Instance;

        private readonly Coroutines _coroutines;
        private readonly RootView _rootView;
        private readonly DIContainer _rootContainer;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void EntryPoint()
        {
            Instance = new GameEntryPoint();
            Instance.RunGame();
        }

        private GameEntryPoint()
        {
            _coroutines = new GameObject("Coroutines").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var rootViewResources = Resources.Load<RootView>("RootView");
            _rootView = Object.Instantiate(rootViewResources);
            Object.DontDestroyOnLoad(_rootView.gameObject);


            _rootContainer = new DIContainer();

            _rootContainer.RegisterInstance(_rootView);
        }

        public void RunGame()
        {
            _coroutines.StartCoroutine(LoadGameplayScene());
        }

        private IEnumerator LoadGameplayScene()
        {
            _rootView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return new WaitForSeconds(0.5f);
            yield return LoadScene(Scenes.GAMEPLAY);

            var gameplayEntryPoint = Object.FindAnyObjectByType<GameplayEntryPoint>();
            gameplayEntryPoint.Run(_rootContainer);

            _rootView.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
