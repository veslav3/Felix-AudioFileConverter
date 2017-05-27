using MimeSharp;
using NAudio.Wave;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace SoundShareFileServer.Conversion {
	class AiffToMp3 : IConversionMethod
	{
        public void convert(string filepath) {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            var filepath2 = filepath.Replace("Preview.aif", "preview.mp3");
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg.exe");
            startInfo.Arguments = "-i C:/Users/veslav/Desktop/convertertest/Preview.wav C:/Users/veslav/Desktop/convertertest/preview.ogg";
            startInfo.RedirectStandardOutput = true;
            //startInfo.RedirectStandardError = true;

            Console.WriteLine(string.Format(
                "Executing \"{0}\" with arguments \"{1}\".\r\n",
                startInfo.FileName,
                startInfo.Arguments));

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Console.WriteLine(line);
                    }

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
	}
}
