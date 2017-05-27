﻿using SoundShareFileServer.Conversion;
using System;

namespace SoundShareFileServer {
	class Program {
		static void Main(string[] args) {
			String filepath = "C:\\Users\\veslav\\Desktop\\convertertest\\Preview.aif";
            IConversionMethod converter = new AiffToMp3();
			converter.convert(filepath);
		}
	}
}
