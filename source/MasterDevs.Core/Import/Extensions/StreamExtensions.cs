namespace System.IO
{
    public static class StreamExtensions
    {
        public static Stream AsStream(this string me)
        {
            if (string.IsNullOrEmpty(me)) return null;

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(me);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static Stream AsStream(this byte[] me)
        {
            return new MemoryStream(me);
        }

        public static long GetLength(this Stream me)
        {
            if (null == me) return 0;

            if (!me.CanRead) return 0;

            if (!me.CanSeek) return 0;

            var priorPosition = me.Position;
            var val = me.Length;

            me.Position = priorPosition;

            return val;
        }

        public static byte[] ToByteArray(this MemoryStream me, bool disposeStream = true)
        {
            if (null == me)
                return null;

            var result = me.ToArray();

            if (disposeStream)
                me.Dispose();

            return result;
        }

        public static byte[] ToByteArray(this Stream me)
        {
            if (null == me)
                return null;

            if (!me.CanRead)
                return null;

            var ms = new MemoryStream();
            me.CopyTo(ms);
            me.Dispose();
            return ms.ToArray();
        }
    }
}