﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Managed.x64dbg.SDK
{
    public static class PLog
    {
        public static void WriteLine(string format, params object[] args)
        {
            Write(string.Format(format.Replace("%", "%%") + "\n", args));
        }

        public static void Write(string format, params object[] args)
        {
            Plugins._plugin_logprintf(string.Format(format.Replace("%", "%%"), args));
        }
    }

    public class TextWriterPLog : TextWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }

        public override void Write(string value)
        {
            PLog.Write(value);
        }
    }
}
