using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace TaoLa.Core
{
	public class ZipHelper
	{
		public class ZipInfo
		{
			public bool Success
			{
				get;
				set;
			}

			public string InfoMessage
			{
				get;
				set;
			}

			public string UnZipPath
			{
				get;
				set;
			}
		}

		public static ZipHelper.ZipInfo CreateZipFile(string filesPath, string zipFilePath)
		{
			ZipHelper.ZipInfo result;
			if (!System.IO.Directory.Exists(filesPath))
			{
				result = new ZipHelper.ZipInfo
				{
					Success = false,
					InfoMessage = "没有找到文件"
				};
			}
			else
			{
				try
				{
					string[] files = System.IO.Directory.GetFiles(filesPath);
					using (ZipOutputStream zipOutputStream = new ZipOutputStream(System.IO.File.Create(zipFilePath)))
					{
						zipOutputStream.SetLevel(9);
						byte[] array = new byte[4096];
						string[] array2 = files;
						for (int i = 0; i < array2.Length; i++)
						{
							string path = array2[i];
							zipOutputStream.PutNextEntry(new ZipEntry(System.IO.Path.GetFileName(path))
							{
								DateTime = System.DateTime.Now
							});
							using (System.IO.FileStream fileStream = System.IO.File.OpenRead(path))
							{
								int num;
								do
								{
									num = fileStream.Read(array, 0, array.Length);
									zipOutputStream.Write(array, 0, num);
								}
								while (num > 0);
							}
						}
						zipOutputStream.Finish();
						zipOutputStream.Close();
					}
					result = new ZipHelper.ZipInfo
					{
						Success = true,
						InfoMessage = "压缩成功"
					};
				}
				catch (System.Exception ex)
				{
					result = new ZipHelper.ZipInfo
					{
						Success = false,
						InfoMessage = ex.Message
					};
				}
			}
			return result;
		}

		public static ZipHelper.ZipInfo UnZipFile(string zipFilePath)
		{
			ZipHelper.ZipInfo result;
			if (!System.IO.File.Exists(zipFilePath))
			{
				result = new ZipHelper.ZipInfo
				{
					Success = false,
					InfoMessage = "没有找到解压文件"
				};
			}
			else
			{
				try
				{
					string text = zipFilePath.Replace(System.IO.Path.GetExtension(zipFilePath), string.Empty) + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
					string text2 = string.Empty;
					string text3 = string.Empty;
					using (ZipInputStream zipInputStream = new ZipInputStream(System.IO.File.OpenRead(zipFilePath)))
					{
						ZipEntry nextEntry;
						while ((nextEntry = zipInputStream.GetNextEntry()) != null)
						{
							text2 = System.IO.Path.GetDirectoryName(nextEntry.Name);
							text3 = System.IO.Path.GetFileName(nextEntry.Name);
							if (text2.Length > 0)
							{
								text2 = System.IO.Path.Combine(text, text2);
								if (!System.IO.Directory.Exists(text2))
								{
									System.IO.Directory.CreateDirectory(text2);
								}
							}
							else
							{
								text2 = text;
							}
							if (text3 != string.Empty)
							{
								text3 = System.IO.Path.Combine(text2, text3);
								using (System.IO.FileStream fileStream = System.IO.File.Create(text3))
								{
									byte[] array = new byte[2048];
									while (true)
									{
										int num = zipInputStream.Read(array, 0, array.Length);
										if (num <= 0)
										{
											break;
										}
										fileStream.Write(array, 0, num);
									}
								}
							}
						}
					}
					result = new ZipHelper.ZipInfo
					{
						Success = true,
						InfoMessage = "解压成功",
						UnZipPath = text
					};
				}
				catch (System.Exception ex)
				{
					result = new ZipHelper.ZipInfo
					{
						Success = false,
						InfoMessage = "解压文件:" + ex.Message
					};
				}
			}
			return result;
		}
	}
}
