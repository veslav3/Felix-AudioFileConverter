using System;
using NAudio;
using NAudio.Wave;
using MimeSharp;
namespace SoundShareFileServer {
	class Mp3ToWave : IConversionMethod {
		public void convert(string filepath) {
			Mime mime = new Mime();
			string mimeType = mime.Lookup(filepath);

			Console.WriteLine(mimeType);
			if (mimeType == "audio/mpeg") {
				string wavfile = filepath.Replace(".mp3", ".wav");
				string wavpath = wavfile;

				int index = wavfile.LastIndexOf("\\");
				string wavname = wavfile.Substring(index + 1, wavfile.Length - index - 1);
				index = filepath.LastIndexOf("\\");
				string mp3name = filepath.Substring(index + 1, filepath.Length - index - 1);
				Console.Out.WriteLine("Converting {0} to {1}", mp3name, wavname);
				try {
					using (Mp3FileReader reader = new Mp3FileReader(filepath)) {
						using (WaveStream wavestream = WaveFormatConversionStream.CreatePcmStream(reader)) {
							WaveFileWriter.CreateWaveFile(wavfile, wavestream);
						}
					}
				} catch (Exception e) {
					// Exception when there is a wrong filetype
					Console.Out.WriteLine("Exception occured: " + e);
				}
			}
		}
	}
}
