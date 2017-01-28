using SoundShareFileServer.Conversion;
using System;

namespace SoundShareFileServer {
	class Program {
		static void Main(string[] args) {
			String filepath = "C:\\Users\\veslav\\Downloads\\test.wav";
			IConversionMethod converter = new WaveToMp3();
			converter.convert(filepath);
		}
	}
}
