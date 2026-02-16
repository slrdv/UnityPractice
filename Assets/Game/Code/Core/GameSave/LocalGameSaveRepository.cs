using System.IO;
using UnityEngine;

namespace Game
{
    public sealed class LocalGameSaveRepository : IGameSaveRepository
    {
        private readonly string _saveFilePath = Path.Combine(Application.persistentDataPath, PathConstants.GAME_SAVE_FILE);

        public bool TryLoad(out GameSaveData data)
        {

            if (!File.Exists(_saveFilePath))
            {
                Debug.LogWarning($"Profile file {_saveFilePath} not found");
                data = null;
                return false;
            }

            data = JsonUtility.FromJson<GameSaveData>(File.ReadAllText(_saveFilePath));
            return true;
        }

        public void Save(GameSaveData data)
        {
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(_saveFilePath, json);

            Debug.Log($"Profile saved to {_saveFilePath}");
        }

        public void Delete()
        {
            if (File.Exists(_saveFilePath))
            {
                File.Delete(_saveFilePath);
            }
        }
    }
}
