using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SoundBoardLive {
	class SoundSessionFile {

		public SoundSessionFile() {
			this.FileList = new Dictionary<char, string>();
		}

		/// <summary>
		/// The location of this file
		/// </summary>
		public String FileName { get; private set; }

		/// <summary>
		/// The dictionary of keys and filenames in this session
		/// </summary>
		public Dictionary<char, String>  FileList { get; set; }

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
