using Config;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class SoundManager : Manager
	{
		public enum SoundType
		{
			BGM,
			SKILL,
			TALK,
			UI,
			EFFECT
		}

		private class AudioData
		{
			public GameObject go
			{
				get;
				private set;
			}

			public AudioSource audio
			{
				get;
				private set;
			}

			public SoundManager.SoundType type
			{
				get;
				private set;
			}

			public string path
			{
				get;
				private set;
			}

			private float minPitch
			{
				get;
				set;
			}

			private float maxPitch
			{
				get;
				set;
			}

			private float defaultVol
			{
				get;
				set;
			}

			public AudioData(string path, SoundManager.SoundType type, bool loop, Transform parent, Vector3 position, int priority, float minPitch, float maxPitch, float volume)
			{
				this.go = new GameObject(string.Format("Audio_{0}_{1}", type.ToString(), path));
				this.go.transform.SetParent(parent);
				this.go.transform.position = position;
				this.path = path;
				this.type = type;
				this.audio = this.go.AddComponent<AudioSource>();
				this.audio.playOnAwake = false;
				this.audio.bypassEffects = true;
				this.audio.loop = loop;
				this.audio.priority = priority;
				this.audio.rolloffMode = AudioRolloffMode.Linear;
				this.audio.dopplerLevel = 0f;
				this.audio.maxDistance = 25f;
				this.audio.volume = volume;
				this.defaultVol = volume;
				this.minPitch = minPitch;
				this.maxPitch = maxPitch;
			}

			public void Play(float delay)
			{
				if (this.audio == null)
				{
					return;
				}
				if (this.type == SoundManager.SoundType.SKILL)
				{
					float pitch = UnityEngine.Random.Range(this.minPitch, this.maxPitch);
					this.audio.pitch = pitch;
				}
				this.audio.PlayDelayed(delay);
			}

			public void Stop()
			{
				if (this.audio == null)
				{
					return;
				}
				this.audio.Stop();
			}

			public void ChangeVolume(float volume)
			{
				if (this.audio == null)
				{
					return;
				}
				if (this.type == SoundManager.SoundType.SKILL)
				{
					volume = this.defaultVol * volume;
				}
				this.audio.volume = volume;
			}

			public void Destory()
			{
				if (this.audio != null)
				{
					this.audio.clip = null;
				}
				UnityEngine.Object.Destroy(this.go);
			}
		}

		private LFUCache<string, SoundManager.AudioData> sounds = new LFUCache<string, SoundManager.AudioData>(20);

		private SoundManager.AudioData bgm;

		private GameObject _soundParent;

		private GameObject SoundParent
		{
			get
			{
				if (this._soundParent == null)
				{
					this._soundParent = new GameObject("SoundParent");
				}
				this._soundParent.transform.localPosition = Vector3.zero;
				this._soundParent.transform.localScale = Vector3.one;
				return this._soundParent;
			}
		}

		private new void Start()
		{
			this.sounds.DestroyAction = delegate(Node<string, SoundManager.AudioData> node)
			{
				node.Value.Stop();
				node.Value.Destory();
				node.Value = null;
			};
		}

		private string GetAudioClipPath(string name, int type)
		{
			string arg = string.Empty;
			switch (type)
			{
			case 0:
				arg = "bgm";
				break;
			case 1:
				arg = "skill";
				break;
			case 2:
				arg = "talk";
				break;
			case 3:
				arg = "ui";
				break;
			case 4:
				arg = "effect";
				break;
			}
			return string.Format("Sound/{0}/{1}", arg, name);
		}

		private void LoadAudioClip(string name, int type, float volume, Vector3 position, float delay, string extension = "ogg", int priority = 128, bool loop = false, float minPitch = 0f, float maxPitch = 3f)
		{
			string path = this.GetAudioClipPath(name, type);
			if (this.sounds[path] != null)
			{
				SoundManager.AudioData audioData = this.sounds[path];
				if (audioData != null && audioData.audio != null)
				{
					audioData.audio.volume = volume;
					audioData.go.transform.position = position;
					audioData.Play(delay);
				}
				else
				{
					this.sounds.RemoveKey(path);
				}
			}
			else
			{
				SoundManager.AudioData data = new SoundManager.AudioData(path, (SoundManager.SoundType)type, loop, this.SoundParent.transform, position, priority, minPitch, maxPitch, volume);
				base.StartCoroutine(Util.LoadAudioClipAsync(data.go, path, extension, delegate(AudioClip clip, string str)
				{
					if (clip != null)
					{
						data.audio.clip = clip;
						data.audio.volume = volume;
						data.Play(delay);
						this.sounds.Put(path, data, 1);
					}
				}));
			}
		}

		public bool CanPlayBackSound()
		{
			return User_Config.isMusic == 1 && User_Config.volumn >= 0.1f;
		}

		public void PlayBGM(string name, float volume)
		{
			if (!this.CanPlayBackSound())
			{
				return;
			}
			string audioClipPath = this.GetAudioClipPath(name, 0);
			if (this.bgm != null && this.bgm.path != audioClipPath)
			{
				this.bgm.Destory();
				this.bgm = null;
			}
			if (this.bgm == null)
			{
				this.bgm = new SoundManager.AudioData(audioClipPath, SoundManager.SoundType.BGM, true, this.SoundParent.transform, Vector3.zero, 128, 1f, 1f, (volume <= 1f) ? volume : 1f);
				base.StartCoroutine(Util.LoadBGMAudioAsync(this.bgm.go, audioClipPath, "ogg", delegate(AudioClip clip, string str)
				{
					if (clip != null)
					{
						this.bgm.audio.clip = clip;
						this.bgm.audio.volume = volume;
						this.bgm.Play(0f);
					}
				}));
			}
			else
			{
				this.bgm.audio.volume = volume;
				if (!this.bgm.audio.isPlaying)
				{
					this.bgm.Play(0f);
				}
			}
		}

		public bool CanPlaySoundEffect()
		{
			return User_Config.isAudio == 1 && User_Config.volumn >= 0.1f;
		}

		public void PlaySkillSound(string name, float volume, float delay, Vector3 position, int priority, bool loop, float minPitch, float maxPitch, string extension)
		{
			if (!this.CanPlaySoundEffect())
			{
				return;
			}
			this.LoadAudioClip(name, 1, volume * User_Config.volumn, position, delay, extension, priority, loop, minPitch, maxPitch);
		}

		public void PlayEffectSound(string name, Vector3 position, bool loop)
		{
			if (!this.CanPlaySoundEffect())
			{
				return;
			}
			this.LoadAudioClip(name, 4, User_Config.volumn, position, 0f, "ogg", 128, loop, 0f, 3f);
		}

		public void PlayTalkSound(string name, float volume, float delay, Vector3 position)
		{
			if (!this.CanPlaySoundEffect())
			{
				return;
			}
			this.LoadAudioClip(name, 2, volume * User_Config.volumn, position, delay, "ogg", 128, false, 0f, 3f);
		}

		public void PlayUISound(string name, float volume, float delay, string extension)
		{
			if (!this.CanPlaySoundEffect())
			{
				return;
			}
			this.LoadAudioClip(name, 3, volume * User_Config.volumn, Vector3.zero, delay, extension, 128, false, 0f, 3f);
		}

		public void ChangeVolume(float volume)
		{
			IEnumerator enumerator = this.sounds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, LFUNode<string, SoundManager.AudioData>> keyValuePair = (KeyValuePair<string, LFUNode<string, SoundManager.AudioData>>)enumerator.Current;
				keyValuePair.Value.Value.ChangeVolume(volume);
			}
			if (this.bgm != null)
			{
				this.bgm.ChangeVolume(volume);
			}
		}

		public void StopBGM()
		{
			if (this.bgm != null)
			{
				this.bgm.Stop();
				this.bgm.Destory();
				this.bgm = null;
			}
		}

		public void PauseMusic()
		{
			if (this.bgm != null)
			{
				this.bgm.audio.Pause();
			}
		}

		public void ReplayMusic()
		{
			if (this.bgm != null)
			{
				this.bgm.audio.Play();
			}
		}

		public void StopEffectSound(string name, int type)
		{
			string audioClipPath = this.GetAudioClipPath(name, type);
			if (this.sounds.ContainsKey(audioClipPath))
			{
				SoundManager.AudioData audioData = this.sounds[audioClipPath];
				audioData.Stop();
			}
		}

		public void StopEffectSound()
		{
			this.sounds.Destroy();
		}

		public void Clear()
		{
			this.StopBGM();
			this.StopEffectSound();
			UnityEngine.Object.Destroy(this._soundParent);
			this._soundParent = null;
		}
	}
}
