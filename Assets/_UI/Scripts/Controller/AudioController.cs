
using UnityEngine;
using System;
using Update;

namespace UI {
	public enum AudioName {
		None,
		/// <summary>
		/// 主菜单背景音乐
		/// </summary>
		Music_Menu,
		/// <summary>
		/// 游戏背景音乐
		/// </summary>
		Music_Game,
		/// <summary>
		/// 普通按钮点击音效
		/// </summary>
		Audio_BtnClick,

	}

	public enum AudioState {
		Stop,
		Play,
		Pause
	}

	public class AudioController : MonoBehaviour {

		private static AudioController instance;

		private event Action<bool> _OnChange = null;

		public AudioSource musicBG;
		public AudioSource audioEffect;

		public AudioListener Listener;

		private bool isAudioPause = false;
		private bool isMusicPause = false;
		private MenuType lastMenu = MenuType.None;
		private bool inited = false;

		public bool IsAudioPause
		{
			get
			{
				return isAudioPause;
			}
			set
			{
				CommonUtil.SetBool(UIData.IS_EFFECTS_PAUSED, value);
				if (isAudioPause != value && _OnChange != null)
				{
					_OnChange(value);
				}
				isAudioPause = value;
			}
		}

		public bool IsMusicPause
		{
			get
			{
				return isMusicPause;
			}
			set
			{
				CommonUtil.SetBool(UIData.IS_MUSIC_PAUSED, value);
				if (isMusicPause != value && _OnChange != null)
				{
					_OnChange(value);
				}
				isMusicPause = value;
				if (!isMusicPause)
				{
					SetBKMusic();
				} else {
					musicBG.Stop();
				}
			}
		}

		public event Action<bool> OnChange
		{
			add
			{
				_OnChange += value;
				value(!IsAudioPause);

			}
			remove
			{
				_OnChange -= value;
			}
		}

		public static AudioController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<AudioController>();
				}
				return instance;
			}
		}

		void Awake() {
			instance = this;
		}

		void Start() {
			if (!inited)
			{
				Init();
				inited = true;
			}
		}

		void Init() {
			isAudioPause = CommonUtil.GetBool(UIData.IS_EFFECTS_PAUSED, false);
			isMusicPause = CommonUtil.GetBool(UIData.IS_MUSIC_PAUSED, false);
		}

		public void SetAudio(AudioName _name, AudioState _state = AudioState.Play) {
			if (IsAudioPause)
			{
				return;
			}
			AudioClip ac = Resources.Load<AudioClip>(_name.ToString());
			if (ac == null)
			{
				Debug.LogError("update/audio/" + _name.ToString() + "不存在！");
				return;
			}
			if (_state == AudioState.Play)
			{
				audioEffect.PlayOneShot(ac);
			}
		}

		public void SetMusic(AudioName _name, AudioState _state = AudioState.Play) {
			if (!inited)
			{
				Init();
			}

			if (IsMusicPause)
			{
				return;
			}


			AudioClip ac = null;
			if ((ac = UIPreLoadManager.instance.GetAudioClipByACName(_name.ToString())) == null)
			{
				ac = Resources.Load<AudioClip>(_name.ToString());
				UIPreLoadManager.instance.SaveMusic(_name.ToString(), ac);
			}
			if (ac == null)
			{
				Debug.LogError("update/audio/" + _name.ToString() + "不存在！");
				return;
			}

			bool isChange = false;
			if (musicBG.clip != ac)
			{
				musicBG.clip = ac;
				isChange = true;
			}
			musicBG.loop = true;
			switch (_state)
			{
				case AudioState.Play:
					if (isChange || !musicBG.isPlaying)
					{
						musicBG.Play();
					}
					break;
				case AudioState.Pause:
					musicBG.Pause();
					break;
				case AudioState.Stop:
					musicBG.Stop();
					break;
				default:
					break;
			}
		}

		public void SetBKMusic(MenuType _menuType = MenuType.None) {
			if (lastMenu != _menuType || _menuType == MenuType.None)
			{
				if (_menuType == MenuType.None)
				{
					lastMenu = MainUIController.Instance.CurrentMenuType;
				} else {
					lastMenu = _menuType;
				}

				if (_menuType == MenuType.None)
				{
					_menuType = MainUIController.Instance.CurrentMenuType;
				}
				switch (_menuType)
				{
					case MenuType.Main:
						SetMusic(AudioName.Music_Menu);
						break;
					case MenuType.Game1:
						PauseBKMusic();
						SetMusic(AudioName.Music_Game);
						break;
					default:
						SetMusic(AudioName.Music_Menu);
						break;
				}
			}
		}

		public void PauseBKMusic() {
			musicBG.Pause();
		}

		public void ResumeBkMusic() {
			if (!IsMusicPause && !musicBG.isPlaying)
			{
				musicBG.Play();
			}
		}

		void OnApplicationPause(bool isPause) {
			if (isPause)
			{
				musicBG.Pause();
			} else {
				if (!IsMusicPause && !musicBG.isPlaying)
				{
					musicBG.Play();
				}
			}
		}
	}
}