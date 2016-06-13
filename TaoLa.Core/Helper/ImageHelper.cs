using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace TaoLa.Core
{
	public class ImageHelper
	{
		private static bool _isloadjpegcodec = false;

		private static System.Drawing.Imaging.ImageCodecInfo _jpegcodec = null;

		public static System.Drawing.Imaging.ImageCodecInfo GetJPEGCodec()
		{
			System.Drawing.Imaging.ImageCodecInfo jpegcodec;
			if (ImageHelper._isloadjpegcodec)
			{
				jpegcodec = ImageHelper._jpegcodec;
			}
			else
			{
				System.Drawing.Imaging.ImageCodecInfo[] imageEncoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
				System.Drawing.Imaging.ImageCodecInfo[] array = imageEncoders;
				for (int i = 0; i < array.Length; i++)
				{
					System.Drawing.Imaging.ImageCodecInfo imageCodecInfo = array[i];
					if (imageCodecInfo.MimeType.IndexOf("jpeg") > -1)
					{
						ImageHelper._jpegcodec = imageCodecInfo;
						break;
					}
				}
				ImageHelper._isloadjpegcodec = true;
				jpegcodec = ImageHelper._jpegcodec;
			}
			return jpegcodec;
		}

		public static void CreateThumbnail(string sourceFilename, string destFilename, int width, int height)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(sourceFilename);
			if (image.Width <= width && image.Height <= height)
			{
				System.IO.File.Copy(sourceFilename, destFilename, true);
				image.Dispose();
			}
			else
			{
				int width2 = image.Width;
				int height2 = image.Height;
				float num = (float)height / (float)height2;
				if ((float)width / (float)width2 < num)
				{
					num = (float)width / (float)width2;
				}
				width = (int)((float)width2 * num);
				height = (int)((float)height2 * num);
				System.Drawing.Image image2 = new System.Drawing.Bitmap(width, height);
				System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(image2);
				graphics.Clear(System.Drawing.Color.White);
				graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, width, height), new System.Drawing.Rectangle(0, 0, width2, height2), System.Drawing.GraphicsUnit.Pixel);
				System.Drawing.Imaging.EncoderParameters encoderParameters = new System.Drawing.Imaging.EncoderParameters();
				System.Drawing.Imaging.EncoderParameter encoderParameter = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
				encoderParameters.Param[0] = encoderParameter;
				System.Drawing.Imaging.ImageCodecInfo[] imageEncoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
				System.Drawing.Imaging.ImageCodecInfo encoder = null;
				for (int i = 0; i < imageEncoders.Length; i++)
				{
					if (imageEncoders[i].FormatDescription.Equals("JPEG"))
					{
						encoder = imageEncoders[i];
						break;
					}
				}
				image2.Save(destFilename, encoder, encoderParameters);
				encoderParameters.Dispose();
				encoderParameter.Dispose();
				image.Dispose();
				image2.Dispose();
				graphics.Dispose();
			}
		}

		public static void GenerateImageWatermark(string originalPath, string watermarkPath, string targetPath, int position, int opacity, int quality)
		{
			System.Drawing.Image image = null;
			System.Drawing.Image image2 = null;
			System.Drawing.Imaging.ImageAttributes imageAttributes = null;
			System.Drawing.Graphics graphics = null;
			try
			{
				image = System.Drawing.Image.FromFile(originalPath);
				image2 = new System.Drawing.Bitmap(watermarkPath);
				if (image2.Height >= image.Height || image2.Width >= image.Width)
				{
					image.Save(targetPath);
				}
				else
				{
					if (quality < 0 || quality > 100)
					{
						quality = 80;
					}
					float num;
					if (opacity > 0 && opacity <= 10)
					{
						num = (float)opacity / 10f;
					}
					else
					{
						num = 0.5f;
					}
					int x = 0;
					int y = 0;
					switch (position)
					{
					case 1:
						x = (int)((float)image.Width * 0.01f);
						y = (int)((float)image.Height * 0.01f);
						break;
					case 2:
						x = (int)((float)image.Width * 0.5f - (float)(image2.Width / 2));
						y = (int)((float)image.Height * 0.01f);
						break;
					case 3:
						x = (int)((float)image.Width * 0.99f - (float)image2.Width);
						y = (int)((float)image.Height * 0.01f);
						break;
					case 4:
						x = (int)((float)image.Width * 0.01f);
						y = (int)((float)image.Height * 0.5f - (float)(image2.Height / 2));
						break;
					case 5:
						x = (int)((float)image.Width * 0.5f - (float)(image2.Width / 2));
						y = (int)((float)image.Height * 0.5f - (float)(image2.Height / 2));
						break;
					case 6:
						x = (int)((float)image.Width * 0.99f - (float)image2.Width);
						y = (int)((float)image.Height * 0.5f - (float)(image2.Height / 2));
						break;
					case 7:
						x = (int)((float)image.Width * 0.01f);
						y = (int)((float)image.Height * 0.99f - (float)image2.Height);
						break;
					case 8:
						x = (int)((float)image.Width * 0.5f - (float)(image2.Width / 2));
						y = (int)((float)image.Height * 0.99f - (float)image2.Height);
						break;
					case 9:
						x = (int)((float)image.Width * 0.99f - (float)image2.Width);
						y = (int)((float)image.Height * 0.99f - (float)image2.Height);
						break;
					}
					System.Drawing.Imaging.ColorMap[] map = new System.Drawing.Imaging.ColorMap[]
					{
						new System.Drawing.Imaging.ColorMap
						{
							OldColor = System.Drawing.Color.FromArgb(255, 0, 255, 0),
							NewColor = System.Drawing.Color.FromArgb(0, 0, 0, 0)
						}
					};
					float[][] array = new float[5][];
					float[][] arg_2DE_0 = array;
					int arg_2DE_1 = 0;
					float[] array2 = new float[5];
					array2[0] = 1f;
					arg_2DE_0[arg_2DE_1] = array2;
					float[][] arg_2F5_0 = array;
					int arg_2F5_1 = 1;
					array2 = new float[5];
					array2[1] = 1f;
					arg_2F5_0[arg_2F5_1] = array2;
					float[][] arg_30C_0 = array;
					int arg_30C_1 = 2;
					array2 = new float[5];
					array2[2] = 1f;
					arg_30C_0[arg_30C_1] = array2;
					float[][] arg_320_0 = array;
					int arg_320_1 = 3;
					array2 = new float[5];
					array2[3] = num;
					arg_320_0[arg_320_1] = array2;
					array[4] = new float[]
					{
						0f,
						0f,
						0f,
						0f,
						1f
					};
					float[][] newColorMatrix = array;
					System.Drawing.Imaging.ColorMatrix newColorMatrix2 = new System.Drawing.Imaging.ColorMatrix(newColorMatrix);
					imageAttributes = new System.Drawing.Imaging.ImageAttributes();
					imageAttributes.SetRemapTable(map, System.Drawing.Imaging.ColorAdjustType.Bitmap);
					imageAttributes.SetColorMatrix(newColorMatrix2, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);
					graphics = System.Drawing.Graphics.FromImage(image);
					graphics.DrawImage(image2, new System.Drawing.Rectangle(x, y, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, System.Drawing.GraphicsUnit.Pixel, imageAttributes);
					System.Drawing.Imaging.EncoderParameters encoderParameters = new System.Drawing.Imaging.EncoderParameters();
					encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, new long[]
					{
						(long)quality
					});
					if (ImageHelper.GetJPEGCodec() != null)
					{
						image.Save(targetPath, ImageHelper._jpegcodec, encoderParameters);
					}
					else
					{
						image.Save(targetPath);
					}
				}
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (graphics != null)
				{
					graphics.Dispose();
				}
				if (imageAttributes != null)
				{
					imageAttributes.Dispose();
				}
				if (image2 != null)
				{
					image2.Dispose();
				}
				if (image != null)
				{
					image.Dispose();
				}
			}
		}

		public static void GenerateTextWatermark(string originalPath, string targetPath, string text, int textSize, string textFont, int position, int quality)
		{
			System.Drawing.Image image = null;
			System.Drawing.Graphics graphics = null;
			try
			{
				image = System.Drawing.Image.FromFile(originalPath);
				graphics = System.Drawing.Graphics.FromImage(image);
				if (quality < 0 || quality > 100)
				{
					quality = 80;
				}
				System.Drawing.Font font = new System.Drawing.Font(textFont, (float)textSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
				System.Drawing.SizeF sizeF = graphics.MeasureString(text, font);
				float num = 0f;
				float num2 = 0f;
				switch (position)
				{
				case 1:
					num = (float)image.Width * 0.01f;
					num2 = (float)image.Height * 0.01f;
					break;
				case 2:
					num = (float)image.Width * 0.5f - sizeF.Width / 2f;
					num2 = (float)image.Height * 0.01f;
					break;
				case 3:
					num = (float)image.Width * 0.99f - sizeF.Width;
					num2 = (float)image.Height * 0.01f;
					break;
				case 4:
					num = (float)image.Width * 0.01f;
					num2 = (float)image.Height * 0.5f - sizeF.Height / 2f;
					break;
				case 5:
					num = (float)image.Width * 0.5f - sizeF.Width / 2f;
					num2 = (float)image.Height * 0.5f - sizeF.Height / 2f;
					break;
				case 6:
					num = (float)image.Width * 0.99f - sizeF.Width;
					num2 = (float)image.Height * 0.5f - sizeF.Height / 2f;
					break;
				case 7:
					num = (float)image.Width * 0.01f;
					num2 = (float)image.Height * 0.99f - sizeF.Height;
					break;
				case 8:
					num = (float)image.Width * 0.5f - sizeF.Width / 2f;
					num2 = (float)image.Height * 0.99f - sizeF.Height;
					break;
				case 9:
					num = (float)image.Width * 0.99f - sizeF.Width;
					num2 = (float)image.Height * 0.99f - sizeF.Height;
					break;
				}
				graphics.DrawString(text, font, new System.Drawing.SolidBrush(System.Drawing.Color.White), num + 1f, num2 + 1f);
				graphics.DrawString(text, font, new System.Drawing.SolidBrush(System.Drawing.Color.Black), num, num2);
				System.Drawing.Imaging.EncoderParameters encoderParameters = new System.Drawing.Imaging.EncoderParameters();
				encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, new long[]
				{
					(long)quality
				});
				if (ImageHelper.GetJPEGCodec() != null)
				{
					image.Save(targetPath, ImageHelper._jpegcodec, encoderParameters);
				}
				else
				{
					image.Save(targetPath);
				}
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (graphics != null)
				{
					graphics.Dispose();
				}
				if (image != null)
				{
					image.Dispose();
				}
			}
		}

		public static System.IO.MemoryStream GenerateCheckCode(out string checkCode)
		{
			checkCode = string.Empty;
			System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#1AE61A");
			char[] array = new char[]
			{
				'2',
				'3',
				'4',
				'5',
				'6',
				'8',
				'9',
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'J',
				'K',
				'L',
				'M',
				'N',
				'P',
				'R',
				'S',
				'T',
				'W',
				'X',
				'Y'
			};
			System.Random random = new System.Random();
			for (int i = 0; i < 4; i++)
			{
				checkCode += array[random.Next(array.Length)];
			}
			int width = 85;
			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, 30);
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			System.Random random2 = new System.Random(System.DateTime.Now.Millisecond);
			System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(4683611));
			graphics.Clear(System.Drawing.ColorTranslator.FromHtml("#EBFDDF"));
			using (System.Drawing.StringFormat stringFormat = new System.Drawing.StringFormat())
			{
				stringFormat.Alignment = System.Drawing.StringAlignment.Center;
				stringFormat.LineAlignment = System.Drawing.StringAlignment.Center;
				stringFormat.FormatFlags = System.Drawing.StringFormatFlags.NoWrap;
				System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
				float num = -25f;
				float num2 = 0f;
				graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				for (int i = 0; i < checkCode.Length; i++)
				{
					int num3 = random2.Next(20, 24);
					System.Drawing.Font font = ImageHelper.CreateFont(IOHelper.GetMapPath("/fonts/checkCode.ttf"), (float)num3, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
					System.Drawing.SizeF sizeF = graphics.MeasureString(checkCode[i].ToString(), font);
					matrix.RotateAt((float)random2.Next(-15, 10), new System.Drawing.PointF(num + sizeF.Width / 2f, num2 + sizeF.Height / 2f));
					graphics.Transform = matrix;
					graphics.DrawString(checkCode[i].ToString(), font, System.Drawing.Brushes.Green, new System.Drawing.RectangleF(num, num2, (float)bitmap.Width, (float)bitmap.Height), stringFormat);
					num += sizeF.Width * 3f / 5f;
					num2 += 0f;
					graphics.RotateTransform(0f);
					matrix.Reset();
					font.Dispose();
				}
			}
			System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 0f);
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			System.IO.MemoryStream result;
			try
			{
				bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
				result = memoryStream;
			}
			finally
			{
				bitmap.Dispose();
				graphics.Dispose();
			}
			return result;
		}

		public static System.Drawing.Font CreateFont(string fontFile, float fontSize, System.Drawing.FontStyle fontStyle, System.Drawing.GraphicsUnit graphicsUnit, byte gdiCharSet)
		{
			System.Drawing.Text.PrivateFontCollection privateFontCollection = new System.Drawing.Text.PrivateFontCollection();
			privateFontCollection.AddFontFile(fontFile);
			return new System.Drawing.Font(privateFontCollection.Families[0], fontSize, fontStyle, graphicsUnit, gdiCharSet);
		}

		public static void TranserImageFormat(string originalImagePath, string newFormatImagePath, System.Drawing.Imaging.ImageFormat fortmat)
		{
			System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(originalImagePath);
			bitmap.Save(newFormatImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
		}
	}
}
