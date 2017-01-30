using MimeSharp;
using NAudio.Lame;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundShareFileServer.Conversion {
	class AiffToMp3 : IConversionMethod {
		public void convert(string filepath) {
			Mime mime = new Mime();
			string mimeType = mime.Lookup(filepath);

			string wavpath = filepath.Replace(".aif", ".wav");
			Debug.WriteLine(wavpath);
			// Console.In.ReadLine();

			try {
				using (var reader = new AiffFileReader(filepath)) {
					using (var writer = new WaveFileWriter(wavpath, new WaveFormat())) {
						byte[] buffer = new byte[4096];
						int bytesRead = 0;
						do {
							bytesRead = reader.Read(buffer, 0, buffer.Length);
							writer.Write(buffer, 0, bytesRead);
						} while (bytesRead > 0);
					}
				}			
				
			} catch (Exception e) {
				Debug.WriteLine(e);
			}
		}
	}
}
