using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SoundBoardLive {

	/// <summary>
	/// Holds the information for a single cue
	/// </summary>
	public class SoundCueInfo {

		public SoundCueInfo(String FilePath, int volume) {
			this.FilePath = FilePath;
			this.volume = volume;
		}

		/// <summary>
		/// The path to the sound file, absolute or relative
		/// </summary>
		public String FilePath{ get; set; }

		/// <summary>
		/// volume, valid values between 0 and 100
		/// </summary>
		public int volume { get; set; }
	}

	/// <summary>
	/// Holds the information of an entire session
	/// </summary>
	public class SoundSessionFile {


		/// <summary>
		/// The location of this file
		/// </summary>
		public String FileName { get; private set; }

		/// <summary>
		/// The dictionary of keys and filenames in this session
		/// </summary>
		public Dictionary<char, SoundCueInfo>  FileList { get; set; }

		/// <summary>
		/// Indicates if this session has been modified since it was loaded (or last saved)
		/// </summary>
		public bool Modified { get; set; }


		
		
		/// <summary>
		/// Initializes an empty session object
		/// </summary>
		public SoundSessionFile() {
			this.FileList = new Dictionary<char, SoundCueInfo>();
			this.Modified = false;
			this.FileName = null;
		}

		/// <summary>
		/// Loads and returns a session file
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public static SoundSessionFile Load(String FileName) {
			using (StreamReader File = new StreamReader(FileName)) {
				String TextContent = File.ReadToEnd();
				SoundSessionFile Session = JsonConvert.DeserializeObject<SoundSessionFile>(TextContent);
				Session.FileName = FileName;
				return Session;
			}
		}

		/// <summary>
		/// Saves this session to the file it came from
		/// </summary>
		public void Save(String FileName = null) {
			if ( FileName != null ) {
				this.FileName = FileName;
			}
			if (this.FileName == null) throw new ArgumentNullException("FileName was not provided");

			String TextContent = JsonConvert.SerializeObject(this);
			using(StreamWriter File = new StreamWriter(this.FileName, false)) {
				File.Write(TextContent);
			}
		}
	}
}
