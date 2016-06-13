using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode.decoder;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TaoLa.Core
{
	public class QRCodeHelper
	{
		public static System.Drawing.Bitmap Create(string content)
		{
			MultiFormatWriter multiFormatWriter = new MultiFormatWriter();
			ByteMatrix byteMatrix = multiFormatWriter.encode(content, BarcodeFormat.QR_CODE, 300, 300);
			return byteMatrix.ToBitmap();
		}

		public static System.Drawing.Bitmap Create(string content, string imagePath)
		{
			System.Drawing.Image centralImage = System.Drawing.Image.FromFile(imagePath);
			return QRCodeHelper.Create(content, centralImage);
		}

		public static System.Drawing.Bitmap Create(string content, System.Drawing.Image centralImage)
		{
			MultiFormatWriter multiFormatWriter = new MultiFormatWriter();
			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			hashtable.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
			hashtable.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
			ByteMatrix byteMatrix = multiFormatWriter.encode(content, BarcodeFormat.QR_CODE, 300, 300, hashtable);
			System.Drawing.Bitmap bitmap = byteMatrix.ToBitmap();
			System.Drawing.Size encodeSize = multiFormatWriter.GetEncodeSize(content, BarcodeFormat.QR_CODE, 300, 300);
			int num = System.Math.Min((int)((double)encodeSize.Width / 3.5), centralImage.Width);
			int num2 = System.Math.Min((int)((double)encodeSize.Height / 3.5), centralImage.Height);
			int x = (bitmap.Width - num) / 2;
			int y = (bitmap.Height - num2) / 2;
			System.Drawing.Bitmap bitmap2 = new System.Drawing.Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap2))
			{
				graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				graphics.DrawImage(bitmap, 0, 0);
			}
			System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(bitmap2);
			graphics2.FillRectangle(System.Drawing.Brushes.White, x, y, num, num2);
			graphics2.DrawImage(centralImage, x, y, num, num2);
			return bitmap2;
		}
	}
}
