﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai15__File_Serialization
{
    class CopyFile
    {
        static void Main() 
        {
            Console.WriteLine("Enter source file: ");
            string sourcePath = Console.ReadLine();
            Console.WriteLine("Enter destination file: ");
            string destinationPath = Console.ReadLine();

            FileInfo source = new FileInfo(sourcePath);
            FileInfo des = new FileInfo(destinationPath);
            try
            {
                CopyFileUsingFileInfo(source, des);
                Console.WriteLine("Copy Completed");
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot Copy");
                Console.Error.WriteLine(e.Message);
            }
        }
        private static void CopyFileUsingFileInfo(FileInfo source, FileInfo dest)
        {
            Console.WriteLine("Start Copy using FileInfo");
            source.CopyTo(dest.FullName, true);
        }
        private static void CopyFileUsingStream(FileInfo source, FileInfo dest)
        {
            Console.WriteLine("Start Copy using Stream");
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                reader = new StreamReader(source.FullName);
                writer = new StreamWriter(dest.FullName);
                Char[] buffer = new Char[1024];
                int length;
                while ((length = reader.Read(buffer)) > 0)
                {
                    writer.Write(buffer, 0, length);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                writer.Close();
                writer.Dispose();
            }

        }
    }
}
