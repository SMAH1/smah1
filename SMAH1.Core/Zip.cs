using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace SMAH1
{
    public static class Zip
    {
        /// <summary>
        /// Compress and Decompress file with Zip format
        /// </summary>
        /// <param name="signature">Signature in begin file (can be null)</param>
        /// <param name="filenameIn">Input file</param>
        /// <param name="filenameOut">Output file</param>
        /// <param name="compress">True: compress, False: decompress</param>
        /// <param name="message">If raise error,return related message</param>
        /// <returns>True: success, False: fail</returns>
        public static bool CompressDecompressZip(
            byte[] signature,
            string filenameIn, string filenameOut,
            bool compress, out string message)
        {
            if (!File.Exists(filenameIn))
            {
                message = "Source file not found!";
                return false;
            }

            FileStream infile = null;
            FileStream outfile = null;
            GZipStream zipStream = null;
            bool ret = false;
            message = "";
            try
            {
                infile = new FileStream(filenameIn, FileMode.Open, FileAccess.Read, FileShare.Read);

                //int count = infile.Read(buffer, 0, buffer.Length);
                if (File.Exists(filenameOut))
                    File.Delete(filenameOut);  //If not delete,may be overwrite first bytes and stay last bytes!
                outfile = new FileStream(filenameOut, FileMode.OpenOrCreate, FileAccess.Write);

                if (compress)
                {
                    if (signature != null && signature.Length > 0)
                        outfile.Write(signature, 0, signature.Length);
                    zipStream = new GZipStream(outfile, CompressionMode.Compress, true);
                    infile.CopyTo(zipStream);
                    ret = true;
                }
                else
                {
                    bool notError = true;
                    if (signature != null && signature.Length > 0)
                    {
                        byte[] signature2 = new byte[signature.Length];
                        infile.Read(signature2, 0, signature.Length);
                        for (int i = 0; i < signature.Length; i++)
                            if (signature[i] != signature2[i])
                            {
                                notError = false;
                                break;
                            }
                    }
                    if (notError)
                    {
                        zipStream = new GZipStream(infile, CompressionMode.Decompress);
                        zipStream.CopyTo(outfile);
                        ret = true;
                    }
                    else
                        message = "Error: Invalid file signature.";
                }
            }
            catch (InvalidDataException exc)
            {
                message = "Error: The file being read contains invalid data." + Environment.NewLine + exc.Message;
            }
            catch (FileNotFoundException exc)
            {
                message = "Error:The file specified was not found." + Environment.NewLine + exc.Message;
            }
            catch (ArgumentException exc)
            {
                message = "Error: path is a zero-length string, contains only white space, or contains one or more invalid characters" + Environment.NewLine + exc.Message;
            }
            catch (PathTooLongException exc)
            {
                message = "Error: The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters." + Environment.NewLine + exc.Message;
            }
            catch (DirectoryNotFoundException exc)
            {
                message = "Error: The specified path is invalid, such as being on an unmapped drive." + Environment.NewLine + exc.Message;
            }
            catch (IOException exc)
            {
                message = "Error: An I/O error occurred while opening the file." + Environment.NewLine + exc.Message;
            }
            catch (UnauthorizedAccessException exc)
            {
                message = "Error: path specified a file that is read-only, the path is a directory, or caller does not have the required permissions." + Environment.NewLine + exc.Message;
            }
            catch (IndexOutOfRangeException exc)
            {
                message = "Error: You must provide parameters for MyGZIP." + Environment.NewLine + exc.Message;
            }
            catch (Exception exc)
            {
                message = "Unknow Error : " + exc.Message + Environment.NewLine + exc.StackTrace;
            }
            finally
            {
                if (zipStream != null)
                    zipStream.Close();
                if (outfile != null)
                    outfile.Close();
                if (infile != null)
                    infile.Close();
            }
            return ret;
        }
    }
}
