using System;
using System.Text;

namespace Itch.Common
{
    public static class Extensions
    {
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            if(end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            var res = new T[len];
            for(int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }

        public static uint GetUInt32(this byte[] source, int start)
        {
            var bytes = source.Slice(start, start + 4);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static UInt64 GetUInt64(this byte[] source, int start)
        {
            var bytes = source.Slice(start, start + 8);
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        public static string GetString(this byte[] source, int start, int length)
        {
            var bytes = source.Slice(start, start + length);
            return Encoding.ASCII.GetString(bytes);
        }

        public static T GetEnum<T>(this byte[] source, int index)
        {
            return (T)Enum.ToObject(typeof (T), source[index]);
        }
    }
}