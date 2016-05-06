
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UI;

namespace Update {
	public class UIPreLoadManager : MonoBehaviour {
		public Action onFinish;
		public static UIPreLoadManager instance;

		public List<string> PreloadAudios;
		public List<string> PreloadObjects;
		public List<string> PreloadAtlas;
		private Dictionary<string, AtlasData> _atlasData = new Dictionary<string, AtlasData>();
		private Dictionary<string, AudioClip> m_audioClipData = new Dictionary<string, AudioClip>();
		private Dictionary<string, GameObject> m_prefabData = new Dictionary<string, GameObject>();

		void Awake() {
			instance = this;
			onFinish = OnFinish;
		}

		void Start() {
			StartCoroutine(Load());
		}

		void OnFinish() {
			MainUIController.Instance.Show(MenuType.Main);
		}

		IEnumerator Load() {
			foreach (string str in PreloadAudios) {
				SaveMusic(str, Resources.Load(str) as AudioClip);
			}

			foreach (string str in PreloadObjects) {
				SavePrefabData(str, Resources.Load(str) as GameObject);
			}

			foreach (string str in PreloadAtlas) {
				SaveAtlas(str, Resources.Load(str) as AtlasData);
			}

			if (onFinish != null) {
				onFinish();
			} else {
				Debug.LogError("PreLoad Over But OnFinish = null");
			}
			yield return 0;
		}

		public void SaveMusic(string str, AudioClip ac) {
			if (ac == null) {
				Debug.LogError("Audio " + str + " is null");
				return;
			}
			if (!m_audioClipData.ContainsKey(str)) {
				m_audioClipData.Add(str, ac);
			}
		}

		public void SavePrefabData(string name, GameObject obj) {
			if (obj == null) {
				Debug.LogError("GameObject " + name + " is null");
				return;
			}
			if (!m_prefabData.ContainsKey(name)) {
				m_prefabData.Add(name, obj);
			}
		}

		public void SaveAtlas(string atlasName, AtlasData UIvalue) {
			if (UIvalue == null) {
				Debug.LogError("Font " + atlasName + " is null");
				return;
			}
			if (!_atlasData.ContainsKey(atlasName)) {
				_atlasData.Add(atlasName, UIvalue);
			}
		}

		public AudioClip GetAudioClipByACName(string musicName) {
			if (m_audioClipData.ContainsKey(musicName)) {
				return m_audioClipData[musicName];
			}
			return null;
		}

		public GameObject GetGameObjectByName(string name) {
			if (m_prefabData.ContainsKey(name)) {
				return m_prefabData[name];
			}
			return null;
		}

		public AtlasData GetAtlasByAtlasName(string atlasName) {
			if (_atlasData.ContainsKey(atlasName)) {
				return _atlasData[atlasName];
			}
			return null;
		}

		public bool ExistGameObject(string name) {
			return m_prefabData.ContainsKey(name);
		}

	}

}
