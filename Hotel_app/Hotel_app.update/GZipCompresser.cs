using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.IO.Compression;

namespace Hotel_app.update
{
    /// <summary>
    /// GZipѹ��
    /// </summary>
    /// <remarks>
    /// ����ļ�(��)ѹ����ÿ���ļ���Ӧһ��GZipUnit������GZipUnit����
    /// ��ʽ���㷨��[FileNameLength][FileName][ContentLength][Content]...
    ///             |<------1----->|          |<-----4----->|
    /// </remarks>
    public class GZipCompresser
    {
        #region ����

        /// <summary>
        /// ��ѹ�����Ԫ����
        /// </summary>
        public const int MaxUnitLength = 4096;
        /// <summary>
        /// Ĭ����չ��
        /// </summary>
        public const string DefaultExtension = ".gz";

        #endregion

        #region ��������

        /// <summary>
        /// ��Ŀ���ļ�(��)����ѹ������ѹ���������Ϊָ���ļ�
        /// </summary>
        /// <param name="path">Ŀ���ļ�(��)</param>
        /// <param name="zipFile">ѹ���ļ���</param>
        public static void Compress(string path, string zipFile)
        {
            if (File.Exists(path))
            {
                List<GZipUnit> units = new List<GZipUnit> ();
                {
                    new GZipUnit(Path.GetFileName(path), File.ReadAllBytes(path));
                }
                EncodeAndCompress(zipFile, units);
            }
            else if (Directory.Exists(path))
            {
                List<GZipUnit> units = Prepare(path, Path.GetDirectoryName(path));
                EncodeAndCompress(zipFile, units);
            }
            else
                throw new FileNotFoundException("Not Found", path);
        }

        /// <summary>
        /// ��ͬĿ¼�µĶ���ļ�����ѹ������ѹ���������Ϊָ���ļ�
        /// </summary>
        /// <param name="fileNames">�ļ�������</param>
        /// <param name="zipFile">ѹ���ļ���</param>
        public static void Compress(string[] fileNames, string zipFile)
        {
            if (fileNames != null)
            {
                List<GZipUnit> units = new List<GZipUnit>();
                foreach (string  fn in fileNames)
                {
                    units.Add(new GZipUnit(Path.GetFileName(fn), File.ReadAllBytes(fn)));
                }
                EncodeAndCompress(zipFile, units);
            }
        }

        /// <summary>
        /// ѹ���ֽ�����
        /// </summary>
        /// <param name="buffer">��ѹ�����ֽ�����</param>
        /// <returns></returns>
        public static byte[] Compress(byte[] buffer)
        {
            return Compress(new MemoryStream(buffer));
        }

        /// <summary>
        /// ѹ����
        /// </summary>
        /// <param name="stream">��ѹ������</param>
        /// <returns></returns>
        public static byte[] Compress(Stream stream)
        {
            using (MemoryStream destination = new MemoryStream())
            {
                using (GZipStream output = new GZipStream(destination, CompressionMode.Compress, true))
                {
                    byte[] bytes = new byte[MaxUnitLength];
                    int n;
                    while ((n = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        output.Write(bytes, 0, n);
                    }
                    //�����ȹرգ���ΪGZipStream����Dispose��ʱ���������ȫд��
                    output.Close();
                    return destination.ToArray();
                }
            }
        }

        /// <summary>
        /// ��Ŀ��ѹ���ļ���ѹ���������ݽ�ѹ����ָ���ļ���
        /// </summary>
        /// <param name="zipFile">ѹ���ļ�</param>
        /// <param name="dirPath">��ѹ��Ŀ¼</param>
        public static void Decompress(string zipFile, string dirPath)
        {
            //��ѹ
            byte[] buffer = Decompress(zipFile);
            //���벢�����ļ�
            DecodeAndCreateFile(buffer, dirPath);
        }

        /// <summary>
        /// ��ѹ��ȡ����������
        /// </summary>
        /// <param name="buffer">��ѹǰ����������</param>
        /// <returns></returns>
        public static byte[] Decompress(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("not found", fileName);
            }
            return Decompress(File.ReadAllBytes(fileName));
        }

        /// <summary>
        /// ��ѹ��ȡ����������
        /// </summary>
        /// <param name="buffer">��ѹǰ����������</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] buffer)
        {
            if (buffer == null)
                return null;
            using (Stream destination = new MemoryStream(buffer))
            {
                List<byte> result = new List<byte>();
                using (GZipStream input = new GZipStream(destination, CompressionMode.Decompress, true))
                {
                    byte[] bytes = new byte[MaxUnitLength];
                    int n;
                    while ((n = input.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        if (n == bytes.Length)
                        {
                            result.AddRange(bytes);
                        }
                        else
                        {
                            for (int i = 0; i < n; ++i)
                            {
                                result.Add(bytes[i]);
                            }
                        }
                    }
                }

                return result.ToArray();
            }
        }

        #endregion ��������

        #region ˽�з���

        /// <summary>
        /// ׼��ѹ��
        /// </summary>
        /// <param name="dirpath"></param>
        /// <param name="basePath"></param>
        /// <returns></returns>
        private static List<GZipUnit> Prepare(string dirpath, string basePath)
        {
            List<GZipUnit> units = new List<GZipUnit>();
            Prepare(units, dirpath, basePath);
            return units;
        }

        /// <summary>
        /// ׼��ѹ��
        /// </summary>
        /// <param name="units"></param>
        /// <param name="dirPath"></param>
        /// <param name="basePath"></param>
        private static void Prepare(List<GZipUnit> units, string dirPath, string basePath)
        {
            foreach (string file in Directory.GetFiles(dirPath))
            {
                byte[] destBuffer = File.ReadAllBytes(file);
                string relativeFileName = file.Replace(basePath, string.Empty);

                while (relativeFileName.StartsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    relativeFileName = relativeFileName.Remove(0, 1);
                }
                GZipUnit gzipUnit = new GZipUnit(relativeFileName, destBuffer);
                units.Add(gzipUnit);
            }
            foreach (string dir in Directory.GetDirectories(dirPath))
            {
                Prepare(units, dir, basePath);
            }
        }

        /// <summary>
        /// ����ѹ���ļ���
        /// </summary>
        /// <param name="zipFile">ѹ���ļ���</param>
        private static void FixZipFile(ref string zipFile)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(zipFile)))
            {
                zipFile += DefaultExtension;
            }
        }

        /// <summary>
        /// ���벢ѹ��
        /// </summary>
        /// <param name="zipFile">ѹ���ļ���</param>
        /// <param name="units">GZip��Ԫ����</param>
        private static void EncodeAndCompress(string zipFile, List<GZipUnit> units)
        {
            FixZipFile(ref zipFile);
            using (Stream stream = new MemoryStream())
            {
                byte[] content = Encode(units);
                stream.Write(content, 0, content.Length);
                stream.Position = 0;
                CreateCompressFile(stream, zipFile);
            }
        }

        /// <summary>
        /// GZip��Ԫ����
        /// </summary>
        /// <param name="units">GZip��Ԫ����</param>
        /// <returns></returns>
        private static byte[] Encode(List<GZipUnit> units)
        {
            if (units == null || units.Count == 0)
                return new byte[0];
            List<byte> result = new List<byte>();
            foreach (GZipUnit unit in units)
            {
                byte[] fn = Encoding.Default.GetBytes(unit.FileName);
                int fnLength = fn.Length;
                if (fnLength > 255)
                    throw new ArgumentException(string.Format("file name[{0}] is too long, max length is 255", unit.FileName));

                //�ļ�������
                result.Add((byte)fnLength);
                //�ļ���
                result.AddRange(fn);
                //���ݳ���
                result.AddRange(UInt32ToBytes((UInt32)unit.Buffer.Length));
                //����
                result.AddRange(unit.Buffer);
            }
            return result.ToArray();
        }

        /// <summary>
        /// GZip��Ԫ����
        /// </summary>
        /// <param name="buffer">��ѹ��Ķ���������</param>
        /// <returns></returns>
        private static List<GZipUnit> Decode(byte[] buffer)
        {
            List<GZipUnit> result = new List<GZipUnit>();
            for (int i = 0; i < buffer.Length; )
            {
                //�ļ�������
                byte fnLen = buffer[i];
                //�ļ���
                byte[] fnBytes = GetSubBytes(buffer, i + 1, fnLen);
                string fileName = Encoding.Default.GetString(fnBytes);

                //���ݳ���
                UInt32 cLen = BytesToUInt32(GetSubBytes(buffer, i + 1 + fnLen, 4));
                //����
                byte[] cBytes = GetSubBytes(buffer, i + fnLen + 5, (int)cLen);

                GZipUnit unit = new GZipUnit(fileName, cBytes);
                result.Add(unit);
                i += (fnLen + 5 + (int)cLen);
            }
            return result;
        }

        /// <summary>
        /// ���벢�����ļ�
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="dirPath"></param>
        private static void DecodeAndCreateFile(byte[] buffer, string dirPath)
        {
            List<GZipUnit> units = Decode(buffer);
            foreach (GZipUnit unit in units)
            {
                string newName = Path.Combine(dirPath, unit.FileName);
                string dir = Path.GetDirectoryName(newName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                using (FileStream fs = new FileStream(newName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(unit.Buffer, 0, unit.Buffer.Length);
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// ����ѹ���ļ�
        /// </summary>
        /// <param name="source">��ѹ����</param>
        /// <param name="destinationName">ѹ���ļ�</param>
        private static void CreateCompressFile(Stream source, string destinationName)
        {
            //ѹ��
            byte[] buffer = Compress(source);
            //д�ļ�
            File.WriteAllBytes(destinationName, buffer);
        }

        /// <summary>
        /// ���޷���32λ������ת����byte[4]
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static Byte[] UInt32ToBytes(UInt32 val)
        {
            Byte[] result = new Byte[4];
            result[3] = Convert.ToByte(val % 256);
            val /= 256;
            result[2] = Convert.ToByte(val % 256);
            val /= 256;
            result[1] = Convert.ToByte(val % 256);
            val /= 256;
            result[0] = Convert.ToByte(val % 256);
            return result;
        }

        /// <summary>
        /// �� byte[4] ת���� �޷���32λ����
        /// </summary>
        /// <param name="val">��ת���� byte[4]</param>
        /// <returns>ת���ɵ� �޷���32λ����</returns>
        private static UInt32 BytesToUInt32(Byte[] val)
        {
            UInt32 result = Convert.ToUInt32(((int)val[0] << 24) + ((int)val[1] << 16) + ((int)val[2] << 8) + (int)val[3]);
            return result;
        }

        /// <summary>
        /// ��ȡ�ֽ�����������
        /// </summary>
        /// <param name="bytes">�ֽ�����</param>
        /// <param name="startIndex">��ʼIndex</param>
        /// <param name="length">����</param>
        /// <returns></returns>
        private static byte[] GetSubBytes(byte[] bytes, int startIndex, int length)
        {
            if (startIndex > bytes.Length - 1)
                return null;
            List<byte> result = new List<byte>();
            for (int i = startIndex; i < bytes.Length && i < startIndex + length; i++)
            {
                result.Add(bytes[i]);
            }
            return result.ToArray();
        }

        #endregion ˽�з���

        #region �ڲ�������

        /// <summary>
        /// GZip����Ԫ
        /// </summary>
        [Serializable]
        private class GZipUnit
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="GZipUnit"/> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="buffer">The buffer.</param>
            public GZipUnit(string name, byte[] buffer)
            {
                _fileName = name;
                _buffer = buffer;
            }

            private string _fileName;
            /// <summary>
            /// Gets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName
            {
                get { return _fileName; }
            }

            private byte[] _buffer;
            /// <summary>
            /// Gets the buffer.
            /// </summary>
            /// <value>The buffer.</value>
            public byte[] Buffer
            {
                get { return _buffer; }
            }
        }
        #endregion
    }
}
