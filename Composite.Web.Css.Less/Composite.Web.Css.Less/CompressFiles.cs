﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web.Hosting;
using Composite.Core.IO;

namespace Composite.Web.Css.Less
{
    public static class CompressFiles
    {
        private static readonly string LessCompilerFilePath = HostingEnvironment.MapPath("~/Frontend/Composite/Web/Css/Less/lessc.cmd");

        public static void CompressLess(string lessFilePath, string cssFilePath, DateTime folderLastUpdatedUtc)
        {
            var scriptProc = new Process();
            scriptProc.StartInfo.FileName = "\"" + LessCompilerFilePath + "\"";
            scriptProc.StartInfo.Arguments = lessFilePath;
            scriptProc.StartInfo.WorkingDirectory = Path.GetDirectoryName(lessFilePath);
            scriptProc.StartInfo.RedirectStandardOutput = true;
            scriptProc.StartInfo.RedirectStandardError = true;
            scriptProc.StartInfo.CreateNoWindow = true;
            scriptProc.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            scriptProc.StartInfo.UseShellExecute = false;
            scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            scriptProc.Start();

            string output = scriptProc.StandardOutput.ReadToEnd();
            string error = scriptProc.StandardError.ReadToEnd();

            if (scriptProc.ExitCode == 2)
            {
                throw new CssCompileException(error);
            }

            if (scriptProc.ExitCode != 0)
            {
                throw new InvalidOperationException("Compiling less caused a scripting host error. " + error);
            }

            C1File.WriteAllText(cssFilePath, output);

            File.SetLastWriteTimeUtc(cssFilePath, folderLastUpdatedUtc);
        }
    }
}