﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuriimu2_WinForms.Extensions
{
    static class StringExtensions
    {
        public static byte[] Hexlify(this string hex, int length = -1)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[(length < 0) ? NumberChars / 2 : (length + 1) & ~1];
            for (int i = 0; i < ((length < 0) ? NumberChars : length * 2); i += 2)
                bytes[i / 2] = System.Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
