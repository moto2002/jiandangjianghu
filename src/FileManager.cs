using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
	public static bool FileExist(string filePath)
	{
		return File.Exists(filePath);
	}

	public static bool DirectoryExist(string dir)
	{
		return Directory.Exists(dir);
	}

	public static void BinaryCopyFile(string sourceFile, string destFile)
	{
		try
		{
			byte[] bytes = File.ReadAllBytes(sourceFile);
			File.WriteAllBytes(destFile, bytes);
		}
		catch (Exception ex)
		{
			Debug.Log("Copy file error: " + ex.ToString());
		}
	}

	public static void StringCopyFile(string sourceFile, string destFile)
	{
		try
		{
			string contents = File.ReadAllText(sourceFile);
			File.WriteAllText(destFile, contents);
		}
		catch (Exception ex)
		{
			Debug.Log("Copy file error: " + ex.ToString());
		}
	}

	public static void WriteFile(string filePath, string content)
	{
		try
		{
			using (StreamWriter streamWriter = File.CreateText(filePath))
			{
				streamWriter.Write(content);
			}
		}
		catch (Exception ex)
		{
			Debug.Log("Write file error: " + ex.ToString());
		}
	}

	public static void WriteFile(string filePath, byte[] bytes)
	{
		try
		{
			File.WriteAllBytes(filePath, bytes);
			Debug.Log("Write file to " + filePath);
		}
		catch (Exception ex)
		{
			Debug.Log("Write file error: " + ex.ToString());
		}
	}

	public static byte[] ReadFileByte(string filePath)
	{
		FileStream fileStream = new FileStream(filePath, FileMode.Open);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Dispose();
		return array;
	}

	public static string ReadFileString(string filePath)
	{
		return File.ReadAllText(filePath);
	}

	public static void ClearPath(string path, List<string> savePattern, bool recursive = true)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		if (recursive)
		{
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			for (int i = 0; i < directories.Length; i++)
			{
				DirectoryInfo directoryInfo2 = directories[i];
				if (FileManager.DirectoryExist(directoryInfo2.FullName))
				{
					FileManager.ClearPath(directoryInfo2.FullName, savePattern, recursive);
					Directory.Delete(directoryInfo2.FullName);
				}
			}
		}
		FileInfo[] files = directoryInfo.GetFiles();
		int j = 0;
		while (j < files.Length)
		{
			FileInfo fileInfo = files[j];
			if (!fileInfo.Name.Contains("."))
			{
				goto IL_B4;
			}
			string item = fileInfo.Name.Split(new char[]
			{
				'.'
			})[1];
			if (savePattern == null || !savePattern.Contains(item))
			{
				goto IL_B4;
			}
			IL_C0:
			j++;
			continue;
			IL_B4:
			File.Delete(fileInfo.FullName);
			goto IL_C0;
		}
		Debug.Log("Clear path: " + path);
	}

	public static void DeleteFolder(string dir)
	{
		string[] fileSystemEntries = Directory.GetFileSystemEntries(dir);
		for (int i = 0; i < fileSystemEntries.Length; i++)
		{
			string text = fileSystemEntries[i];
			if (File.Exists(text))
			{
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Attributes.ToString().IndexOf("ReadOnly") != -1)
				{
					fileInfo.Attributes = FileAttributes.Normal;
				}
				File.Delete(text);
			}
			else
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text);
				if (directoryInfo.GetFiles().Length != 0)
				{
					FileManager.DeleteFolder(directoryInfo.FullName);
				}
				Directory.Delete(text);
			}
		}
	}

	public static void CopyDirectory(string sourcePath, string destinationPath)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
		Directory.CreateDirectory(destinationPath);
		FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
		for (int i = 0; i < fileSystemInfos.Length; i++)
		{
			FileSystemInfo fileSystemInfo = fileSystemInfos[i];
			string text = Path.Combine(destinationPath, fileSystemInfo.Name);
			if (fileSystemInfo is FileInfo)
			{
				File.Copy(fileSystemInfo.FullName, text);
			}
			else
			{
				Directory.CreateDirectory(text);
				FileManager.CopyDirectory(fileSystemInfo.FullName, text);
			}
		}
	}
}
