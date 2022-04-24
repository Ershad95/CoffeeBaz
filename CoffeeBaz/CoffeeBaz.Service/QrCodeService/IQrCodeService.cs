using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Service.QrCode
{
    public interface IQrCodeService
    {
        Bitmap CreateQRCodeOnBitmap<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> plainValues, int Width = 200,
                int Height = 200);
        Image CreateQRCodeOnImage<Tkey, Tvalue>(Dictionary<Tkey, Tvalue> plainValues, int Width = 200,
                int Height = 200);
        byte[] CreateQRCodeOnByteArray<TKey, TValue>(Dictionary<TKey, TValue> plainValues, int Width = 200,
                int Height = 200);
        Bitmap CreateQRCodeOnBitmap(string plainValue, int width = 200, int height = 200);
        Image CreateQRCodeOnImage(string plainValue, int width = 200, int height = 200);
        byte[] CreateQRCodeOnByteArray(string plainValue, int width = 200, int height = 200);
    }
}
