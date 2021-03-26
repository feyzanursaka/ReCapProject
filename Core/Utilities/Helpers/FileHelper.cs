using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
	public class FileHelper
	{
		public static string Add(IFormFile file)
		{
			var result = newPath(file);
			try
			{
				var sourcepath = Path.GetTempFileName();
				if (file.Length > 0)
				{
					using (var stream = new FileStream(sourcepath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
				}

				File.Move(sourcepath, result.newPath);
			}
			catch (Exception exception)
			{
				return exception.Message;
			}

			return result.Path2;
		}
		public static string Update(string sourcefile, IFormFile file)
		{
			var result = newPath(file);
			try
			{
				if (sourcefile.Length > 0)
				{
					using (var stream = new FileStream(result.newPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
				}
				File.Delete(sourcefile);
			}
			catch (Exception exception)
			{

				return exception.Message;
			}
			return result.Path2;
		}
		public static IResult Delete(string path)
		{
			try
			{
				File.Delete(path);
			}
			catch (Exception exception)
			{
				return new ErrorResult(exception.Message);
			}

			return new SuccessResult();
		}
		public static (string newPath, string Path2) newPath(IFormFile file)
		{
			System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
			string fileExtension = ff.Extension;

			var creatingUniqueFilename = Guid.NewGuid().ToString()
				+ "_" + DateTime.Now.Month + "_"
				+ DateTime.Now.Day + "_"
				+ DateTime.Now.Year + fileExtension;

			string path = Environment.CurrentDirectory + @"\Images\CarImages";
			string result = $@"{path}\{creatingUniqueFilename}";
			return (result, $"\\CarImages\\{creatingUniqueFilename}");
		}
	}
}