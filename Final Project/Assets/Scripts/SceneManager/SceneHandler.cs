using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace SceneSystem
{
    public enum SceneTypes
    {
        StartScene,
        GameScene
    }
    public class SceneHandler : AbstractSingelton<SceneHandler>
    {
        private const int STARTSCENE = 0;
        private const int GAMESCENE = 1;

        private Dictionary<SceneTypes, int> m_Scenes = new Dictionary<SceneTypes, int>()
        {
            { SceneTypes.StartScene, STARTSCENE },
            { SceneTypes.GameScene, GAMESCENE }
        };

        public void SwitchScene(SceneTypes scene)
        {
            SceneManager.LoadScene(m_Scenes[scene]);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(GAMESCENE);
        }
    }

}

