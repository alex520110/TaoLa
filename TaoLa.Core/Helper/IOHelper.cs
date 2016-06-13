using System;
using System.IO;
using System.Web;

namespace TaoLa.Core
{
	public class IOHelper
	{
		public static string GetMapPath(string path)
		{
			string result;
			if (HttpContext.Current != null)
			{
				result = HttpContext.Current.Server.MapPath(path);
			}
			else
			{
				string applicationBase = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
				if (!string.IsNullOrWhiteSpace(path))
				{
					path = path.Replace("/", "\\");
					if (!path.StartsWith("\\"))
					{
						path = "\\" + path;
					}
					path = path.Substring(path.IndexOf('\\') + (applicationBase.EndsWith("\\") ? 1 : 0));
				}
				result = applicationBase + path;
			}
			return result;
		}

		public static void CopyFile(string fileFullPath, string destination, bool isDeleteSourceFile = false, string fileName = "")
		{
			if (string.IsNullOrWhiteSpace(fileFullPath))
			{
				throw new System.ArgumentNullException("fileFullPath", "源文件全路径不能为空");
			}
			if (!System.IO.File.Exists(fileFullPath))
			{
				throw new System.IO.FileNotFoundException("找不到源文件", fileFullPath);
			}
			if (!System.IO.Directory.Exists(destination))
			{
				throw new System.IO.DirectoryNotFoundException("找不到目标目录 " + destination);
			}
			try
			{
				fileName = (string.IsNullOrWhiteSpace(fileName) ? System.IO.Path.GetFileName(fileFullPath) : fileName);
				System.IO.File.Copy(fileFullPath, System.IO.Path.Combine(destination, fileName), true);
				if (isDeleteSourceFile)
				{
					System.IO.File.Delete(fileFullPath);
				}
			}
			catch (System.Exception)
			{
				throw;
			}
		}

		public static long GetDirectoryLength(string dirPath)
		{
			long result;
			if (!System.IO.Directory.Exists(dirPath))
			{
				result = 0L;
			}
			else
			{
				long num = 0L;
				System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(dirPath);
				System.IO.FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					System.IO.FileInfo fileInfo = files[i];
					num += fileInfo.Length;
				}
				System.IO.DirectoryInfo[] directories = directoryInfo.GetDirectories();
				if (directories.Length > 0)
				{
					for (int j = 0; j < directories.Length; j++)
					{
						num += IOHelper.GetDirectoryLength(directories[j].FullName);
					}
				}
				result = num;
			}
			return result;
		}
	}
}
