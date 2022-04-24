using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.QrCodeService
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Drawing.Imaging;
    using ZXing;
    using ZXing.Common;
    using ZXing.QrCode;
    using System.Collections.Generic;
    using global::CoffeeBaz.Service.QrCode;

    namespace CoffeeBaz.Service.QrCode
    {
        public enum EnumsQRCodePlainTextType
        {
            defaultType, // defalt type is string
            Dictionary
        }
        public class QrCodeService : IDisposable,IQrCodeService
        {
            #region Fields

            /// <summary>
            /// each part of your dictionary must be recognizable from other parts.
            /// this key use for this subject.
            /// </summary>
            private const string BREAK_KEY_OF_PLAINTEXT = "€$";

            public static string BREAK_KEY_OF_PLAINTEXT1 => BREAK_KEY_OF_PLAINTEXT;

            public static string BREAK_KEY_OF_PLAINTEXT2 => BREAK_KEY_OF_PLAINTEXT;

            #endregion

            #region Utilities Methods

            /// <summary>
            /// Create a barcode writer for encoding
            /// </summary>
            /// <param name="width">QRCode Image Width</param>
            /// <param name="height">QRCode Image Height</param>
            /// <returns></returns>
            private BarcodeWriter CreateBarcodeWriter(int width = 200, int height = 200)
            {
                return new BarcodeWriter()
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions
                    {
                        DisableECI = true, // if you want use UTF-8 this field must be true
                        CharacterSet = "UTF-8",
                        Width = width,
                        Height = height
                    }
                };
            }

            /// <summary>
            /// create a barcode reader for decoding
            /// </summary>
            /// <returns></returns>
            private BarcodeReader CreateBarcodeReader()
            {
                return new BarcodeReader
                {
                    AutoRotate = true,
                    Options = new DecodingOptions { TryHarder = true }
                };
            }

            /// <summary>
            /// Write QRCode Type in plain text for create a recognizable QRCode
            /// </summary>
            /// <param name="QRCodeType">QRCode Type</param>
            /// <returns></returns>
            private string WriteQRcodeType(EnumsQRCodePlainTextType QRCodeType)
            {
                return QRCodeType.ToString() + BREAK_KEY_OF_PLAINTEXT1;
            }

            /// <summary>
            /// Read the type of QRCode for doing a correct parsing
            /// </summary>
            /// <param name="plainText">plain text</param>
            /// <exception cref="ArgumentNullException">if plainText is null or empity</exception>
            /// <returns></returns>
            private EnumsQRCodePlainTextType ReadQRcodeType(string plainText)
            {
                if (string.IsNullOrEmpty(plainText))
                    throw new ArgumentNullException("plainText", "plainText is null or empity in ReadQRCodeType Method");

                if (plainText.Contains(BREAK_KEY_OF_PLAINTEXT1) == false)
                    return EnumsQRCodePlainTextType.defaultType;

                string QRCodeType = plainText.Substring(0, plainText.IndexOf(BREAK_KEY_OF_PLAINTEXT1));

                if (QRCodeType == EnumsQRCodePlainTextType.Dictionary.ToString())
                    return EnumsQRCodePlainTextType.Dictionary;
                else
                    return EnumsQRCodePlainTextType.defaultType;
            }

            // parsing

            // parse Dictionary Type

            /// <summary>
            /// this method create a organized plainText from a dictionary
            /// </summary>
            /// <typeparam name="Tkey">this type must override "ToString()"</typeparam>
            /// <typeparam name="Tvalue">this type must override "ToString()"</typeparam>
            /// <param name="plainValues">The values that you want convert to plainText</param>
            /// <exception cref="ArgumentNullException">if plainValues or one of keys be null or empity</exception>
            /// <returns></returns>
            private string ParseDictionaryToPlainText<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> plainValues)
            {
                // if plainValues be null or empity writer can't creat QRCode and it will throw an error
                if (plainValues.Count == 0 || plainValues == null)
                    throw new ArgumentNullException("plainValues", "plainValues can't be null or empity");

                string plainText = "";

                // Write the QRCode Type in plain text
                plainText = WriteQRcodeType(EnumsQRCodePlainTextType.Dictionary);

                // Write count of values of dictionary in plainText
                plainText += plainValues.Count.ToString() + BREAK_KEY_OF_PLAINTEXT1;

                // Write values in plainText
                foreach (var item in plainValues)
                {
                    // no one Of Keys can't be null or empity
                    if (string.IsNullOrEmpty(item.Key.ToString()))
                        throw new ArgumentNullException("Key", "no one of keys can't be null or empity");

                    // Write key and value in plainText
                    plainText += item.Key.ToString() + BREAK_KEY_OF_PLAINTEXT1 + item.Value.ToString() +
                                 BREAK_KEY_OF_PLAINTEXT1;
                }

                return plainText;
            }

            /// <summary>
            /// this method parse your plainText to a dictionary
            /// </summary>
            /// <param name="plainText">The plainText that you want convert to Dictionary</param>
            /// <exception cref="ArgumentNullException">if plainText has been null or empity</exception>
            /// <exception cref="IncorrectQRCodeTypeException">if type of QRCode isn't Dictionary</exception>
            /// <returns></returns>
            private Dictionary<string, string> ParsePlainTextToDictionary(string plainText)
            {
                // if plainText be null or empity
                if (string.IsNullOrEmpty(plainText))
                    throw new ArgumentNullException("plainText", "plainText can't be null or empity");

                // Check type of QRCode (in this method it must be Dictionary)
                EnumsQRCodePlainTextType plainTextQRCodeType = ReadQRcodeType(plainText);
                if (plainTextQRCodeType != EnumsQRCodePlainTextType.Dictionary)
                    throw new Exception("error");

                Dictionary<string, string> plainValues = new Dictionary<string, string>();

                int currentPosition = 0;
                int countOfSub = 0;

                // skip QRCode Type
                countOfSub = plainText.IndexOf(BREAK_KEY_OF_PLAINTEXT1, currentPosition) - currentPosition;
                currentPosition += countOfSub + BREAK_KEY_OF_PLAINTEXT1.Length;

                // get count of values
                countOfSub = plainText.IndexOf(BREAK_KEY_OF_PLAINTEXT1, currentPosition) - currentPosition;
                int PVCount = Convert.ToInt16(plainText.Substring(currentPosition, countOfSub));
                currentPosition += countOfSub + BREAK_KEY_OF_PLAINTEXT1.Length;

                string key = "", value = "";

                // get values
                for (int i = 0; i < PVCount; i++)
                {
                    countOfSub = plainText.IndexOf(BREAK_KEY_OF_PLAINTEXT1, currentPosition) - currentPosition;
                    key = plainText.Substring(currentPosition, countOfSub);
                    currentPosition += countOfSub + BREAK_KEY_OF_PLAINTEXT1.Length;

                    countOfSub = plainText.IndexOf(BREAK_KEY_OF_PLAINTEXT1, currentPosition) - currentPosition;
                    value = plainText.Substring(currentPosition, countOfSub);
                    currentPosition += countOfSub + BREAK_KEY_OF_PLAINTEXT1.Length;

                    plainValues[key] = value;
                }

                return plainValues;
            }

            // parse String Type

            /// <summary>
            /// this method create a organized plainText from a string
            /// </summary>
            /// <param name="plainValue">The value that you want convert to plainText</param>
            /// <exception cref="ArgumentNullException">if plainValue be null or empity</exception>
            /// <returns></returns>
            private string ParseStringToPlainText(string plainValue)
            {
                // if plainValue be null or empity writer can't creat QRCode and it will throw an error
                if (string.IsNullOrEmpty(plainValue))
                    throw new ArgumentNullException("plainValue", "plainValue can't be null or empity");

                string plainText = "";

                // Write the QRCode Type in plain text
                // string is defualt type and don't need to write in plaintext

                // Write value in plainText
                plainText = plainValue;

                return plainText;
            }

            /// <summary>
            /// this method parse your plainText to a string
            /// </summary>
            /// <param name="plainText">The plainText that you want convert to string</param>
            /// <exception cref="ArgumentNullException">if plainText has been null or empity</exception>
            /// <exception cref="IncorrectQRCodeTypeException">if type of QRCode isn't String</exception>
            /// <returns></returns>
            private string ParsePlainTextToString(string plainText)
            {
                // if plainText be null or empity
                if (string.IsNullOrEmpty(plainText))
                    throw new ArgumentNullException("plainText", "plainText can't be null or empity");

                // Check type of QRCode (in this method it must be String)
                // dont need because we are in default type and we just must decode the QRCode

                return plainText;
            }

            #endregion

            #region Public Methods

            // Encoding

            // Encode Dictionary Type

            /// <summary>
            /// this method encode your values and return a QRCode on Bitmap type
            /// </summary>
            /// <typeparam name="Tkey">this type must override "ToString()"</typeparam>
            /// <typeparam name="Tvalue">this type must override "ToString()"</typeparam>
            /// <param name="plainValues">The values that you want convert to QRCode</param>
            /// <param name="Width">QRCode Image Width</param>
            /// <param name="Height">QRCode Image Height</param>
            /// <exception cref="ArgumentNullException">if plainValues be null or empity</exception>
            /// <returns></returns>
            public Bitmap CreateQRCodeOnBitmap<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> plainValues, int Width = 200,
                int Height = 200)
            {
                // if plainValues be null or empity writer can't creat QRCode and it will throw an error
                if (plainValues.Count == 0 || plainValues == null)
                    throw new ArgumentNullException("plainValues", "plainValues can't be null or empity");

                // Create a barcode writer
                BarcodeWriter writer = CreateBarcodeWriter(Width, Height);

                // create qrcode and return
                return writer.Write(ParseDictionaryToPlainText(plainValues));
            }

            /// <summary>
            /// this method encode your values and return a QRCode on Image type
            /// </summary>
            /// <typeparam name="Tkey">this type must override "ToString()"</typeparam>
            /// <typeparam name="Tvalue">this type must override "ToString()"</typeparam>
            /// <param name="plainValues">The values that you want convert to QRCode</param>
            /// <param name="Width">QRCode Image Width</param>
            /// <param name="Height">QRCode Image Height</param>
            /// <exception cref="ArgumentNullException">if plainValues be null or empity</exception>
            /// <returns></returns>
            public Image CreateQRCodeOnImage<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> plainValues, int Width = 200,
                int Height = 200)
            {
                // use result of CreateQRCodeOnBitmap and convert it to image and return result
                return Image.FromHbitmap(CreateQRCodeOnBitmap(plainValues, Width, Height).GetHbitmap());
            }

            /// <summary>
            /// this method encode your values and return a QRCode on array of bytes
            /// </summary>
            /// <typeparam name="TKey">this type must override "ToString()"</typeparam>
            /// <typeparam name="TValue">this type must override "ToString()"</typeparam>
            /// <param name="plainValues">The values that you want convert to QRCode</param>
            /// <param name="Width">QRCode Image Width</param>
            /// <param name="Height">QRCode Image Height</param>
            /// <exception cref="ArgumentNullException">if plainValues be null or empity</exception>
            /// <returns></returns>
            public byte[] CreateQRCodeOnByteArray<TKey, TValue>(Dictionary<TKey, TValue> plainValues, int Width = 200,
                int Height = 200)
            {
                byte[] QRCodeOnByte;
                // use result of CreateQRCodeOnBitmap and convert it to byte array and return result
                using (MemoryStream MS = new MemoryStream())
                {
                    CreateQRCodeOnBitmap(plainValues, Width, Height).Save(MS, ImageFormat.Bmp);
                    QRCodeOnByte = MS.ToArray();
                }
                return QRCodeOnByte;
            }

            // Encode String Type

            /// <summary>
            /// this method encode your value and return a QRCode on Bitmap type
            /// </summary>
            /// <param name="plainValue">The value that you want convert to QRCode</param>
            /// <param name="width">QRCode Image Width</param>
            /// <param name="height">QRCode Image Height</param>
            /// <exception cref="ArgumentNullException">if plainValue be null or empity</exception>
            /// <returns></returns>
            public Bitmap CreateQRCodeOnBitmap(string plainValue, int width = 200, int height = 200)
            {
                // if plainValues be null or empity writer can't creat QRCode and it will throw an error
                if (string.IsNullOrEmpty(plainValue))
                    throw new ArgumentNullException("plainValue", "plainValue can't be null or empity");

                // Create a barcode writer
                BarcodeWriter writer = CreateBarcodeWriter(width, height);

                // create qrcode and return
                return writer.Write(ParseStringToPlainText(plainValue));
            }

            /// <summary>
            /// this method encode your value and return a QRCode on Image type
            /// </summary>
            /// <param name="plainValue">The value that you want convert to QRCode</param>
            /// <param name="width">QRCode Image Width</param>
            /// <param name="height">QRCode Image Height</param>
            /// <exception cref="ArgumentNullException">if plainValue be null or empity</exception>
            /// <returns></returns>
            public Image CreateQRCodeOnImage(string plainValue, int width = 200, int height = 200)
            {
                // use result of CreateQRCodeOnBitmap and convert it to image and return result
                return Image.FromHbitmap(CreateQRCodeOnBitmap(plainValue, width, height).GetHbitmap());
            }

            /// <summary>
            /// this method encode your value and return a QRCode on array of bytes
            /// </summary>
            /// <param name="plainValue">The value that you want convert to QRCode</param>
            /// <param name="width">QRCode Image Width</param>
            /// <param name="height">QRCode Image Height</param>
            /// <exception cref="ArgumentNullException">if plainValues be null or empity</exception>
            /// <returns></returns>
            public byte[] CreateQRCodeOnByteArray(string plainValue, int width = 200, int height = 200)
            {
                byte[] QRCodeOnByte;
                // use result of CreateQRCodeOnBitmap and convert it to byte array and return result
                using (MemoryStream MS = new MemoryStream())
                {
                    CreateQRCodeOnBitmap(plainValue, width, height).Save(MS, ImageFormat.Bmp);
                    QRCodeOnByte = MS.ToArray();
                }
                return QRCodeOnByte;
            }

            // Decoding

            // Decode Dictionary Type

            /// <summary>
            /// this method decode your QRCode
            /// </summary>
            /// <param name="qrCodeImage">QRCode Image</param>
            /// <exception cref="DamagedQRCodeException">when barcode reader can't read and decode your QRCode.</exception>
            /// <returns></returns>
            public Dictionary<string, string> DecodeQRCode(Bitmap qrCodeImage)
            {
                // Create Barcode Reader for Decoding
                var reader = CreateBarcodeReader();
                var result = reader.Decode(qrCodeImage);

                // if barcode reader can't decode our QRCode will return null
                if (result == null)
                    throw new Exception("");

                // return parsed result of decoding
                return ParsePlainTextToDictionary(result.ToString());
            }

            /// <summary>
            /// this method decode your QRCode
            /// </summary>
            /// <param name="qrCodeImage">QRCode Image</param>
            /// <exception cref="DamagedQRCodeException">when barcode reader can't read and decode your QRCode.</exception>
            /// <returns></returns>
            public Dictionary<string, string> DecodeQRCode(Image qrCodeImage)
            {
                // Create a bitmap from QRCode Image ( Because barcode reader decode function need to a bitmap type of QRCode )
                var bitmap = new Bitmap(qrCodeImage);

                // return parsed result of decoding
                return DecodeQRCode(bitmap);
            }

            /// <summary>
            /// this method decode your QRCode
            /// </summary>
            /// <param name="qrCodeImage">QRCode Image</param>
            /// <exception cref="DamagedQRCodeException">when barcode reader can't read and decode your QRCode.</exception>
            /// <returns></returns>
            public Dictionary<string, string> DecodeQRCode(byte[] qrCodeImage)
            {
                // Create a bitmap from QRCode on byte type ( Because barcode reader decode function need to a bitmap type of QRCode )
                Bitmap bitmap;
                using (var ms = new MemoryStream(qrCodeImage))
                {
                    bitmap = new Bitmap(ms);
                }

                // return parsed result of decoding
                return DecodeQRCode(bitmap);
            }

            // Decode String Type

            /// <summary>
            /// this method decode your QRCode
            /// </summary>
            /// <param name="qrCodeImage">QRCode Image</param>
            /// <exception cref="DamagedQRCodeException">when barcode reader can't read and decode your QRCode.</exception>
            /// <returns></returns>
            public string DecodeStringQRCode(Bitmap qrCodeImage)
            {
                // Create Barcode Reader for Decoding
                var reader = CreateBarcodeReader();
                var result = reader.Decode(qrCodeImage);

                // if barcode reader can't decode our QRCode will return null
                if (result == null)
                    throw new Exception("");

                // return parsed result of decoding
                return ParsePlainTextToString(result.ToString());
            }

            /// <summary>
            /// this method decode your QRCode
            /// </summary>
            /// <param name="qrCodeImage">QRCode Image</param>
            /// <exception cref="DamagedQRCodeException">when barcode reader can't read and decode your QRCode.</exception>
            /// <returns></returns>
            public string DecodeStringQRCode(Image qrCodeImage)
            {
                // Create a bitmap from QRCode Image ( Because barcode reader decode function need to a bitmap type of QRCode )
                Bitmap bitmap = new Bitmap(qrCodeImage);

                // return parsed result of decoding
                return DecodeStringQRCode(bitmap);
            }

            /// <summary>
            /// this method decode your QRCode
            /// </summary>
            /// <param name="qrCodeImage">QRCode Image</param>
            /// <exception cref="DamagedQRCodeException">when barcode reader can't read and decode your QRCode.</exception>
            /// <returns></returns>
            public string DecodeStringQRCode(byte[] qrCodeImage)
            {
                // Create a bitmap from QRCode on byte type ( Because barcode reader decode function need to a bitmap type of QRCode )
                Bitmap bitmap;
                using (var ms = new MemoryStream(qrCodeImage))
                {
                    bitmap = new Bitmap(ms);
                }

                // return parsed result of decoding
                return DecodeStringQRCode(bitmap);
            }

            public void Dispose()
            {
                // Suppress finalization.
                GC.SuppressFinalize(this);
            }

            #endregion
        }
    }
}
