using System;
using System.Collections.Generic;

namespace InterfaceLib.Database
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// 홑따옴표 달기
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string AddQuotation(this string message)
        {
            return $"'{message.Trim()}'";
        }
    }
}