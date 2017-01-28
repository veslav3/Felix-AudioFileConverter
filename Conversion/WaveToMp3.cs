using MimeSharp;
using NAudio.Wave;
using NAudio.Lame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SoundShareFileServer.Conversion {
	class WaveToMp3 : IConversionMethod {
		public void convert(string filepath) {
			Mime mime = new Mime();
			string mimeType = mime.Lookup(filepath);

			string mp3path = filepath.Replace(".wav", ".mp3");
			Debug.WriteLine(mp3path);
			
			try {
				byte[] wavFile = File.ReadAllBytes(filepath);

				using (MemoryStream memoryStream = new MemoryStream())
				using (MemoryStream WaveMemoryStream = new MemoryStream(wavFile))
				using (WaveFileReader WaveFileReader = new WaveFileReader(WaveMemoryStream))
				using (LameMP3FileWriter mp3Writer = new LameMP3FileWriter(memoryStream, WaveFileReader.WaveFormat, 128)) {
					WaveFileReader.CopyTo(mp3Writer);
					try {
						File.WriteAllBytes(mp3path, memoryStream.ToArray());
					} catch (Exception e) {
						// error writing file
						Debug.WriteLine(e);
					}
				}
			} catch (Exception e) {
				Debug.WriteLine(e);
			}
		}
	}
}
