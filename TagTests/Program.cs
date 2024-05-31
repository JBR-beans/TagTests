using System.IO;
using System.Text;

namespace TagTests
{

	internal class Program
	{
		public static string rootSeparator = "|";

		public static string delimiterRootStart = "<root>";
		public static string delimiterRootEnd = "</root>";

		public static string delimiterPathStart = "<path>";
		public static string delimiterPathEnd = "</path>";

		public static string delimiterNameStart = "<name>";
		public static string delimiterNameEnd = "</name>";

		public static string testFilePath = "D:\\filepath";
		public static string testFileName = "name";


		public static string appendedFilePath;
		public static string appendedFileName;
		public static string appendedFileRoots;

		public static string appendedTestString = string.Empty;

		public static string theFile = "D:\\Test1.txt";

		public static string currentDelimiterStart;
		public static string currentDelimiterEnd;
		static void Main(string[] args)
		{
			currentDelimiterStart = delimiterRootStart;
			currentDelimiterEnd = delimiterRootEnd;

			// writing
			Write();


			// reading
			Read();
		}

		public static void Write()
		{
			try
			{

				StreamWriter streamWriter = new StreamWriter(theFile);

				Console.WriteLine("Building String...");
				for (int i = 0; i < 10; i++)
				{
					appendedFilePath = delimiterPathStart + testFilePath + i.ToString() + ".txt" + delimiterPathEnd;
					Console.WriteLine("String appended... <path>");
					Console.WriteLine("Preview: " + appendedFilePath);

					appendedFileName = delimiterNameStart + testFileName + i.ToString() + delimiterNameEnd;
					Console.WriteLine("String appended... <name>");
					Console.WriteLine("Preview: " + appendedFileName);

					appendedFileRoots = delimiterRootStart + appendedFilePath + appendedFileName + delimiterRootEnd;
					Console.WriteLine("String appended... <root>");
					Console.WriteLine("Preview: " + appendedFileRoots);

					appendedFileRoots = rootSeparator + appendedFileRoots + rootSeparator;
					Console.WriteLine("Root appended... . ");
					Console.WriteLine("Preview: " + appendedFileRoots);

					appendedTestString += appendedFileRoots;
					Console.WriteLine("Object added to array... \n");

				}
				streamWriter.Write(appendedTestString);
				Console.WriteLine("File written...");
				Console.WriteLine("File preview... \n{0}", appendedTestString);
				streamWriter.Close();
				Console.WriteLine("Closing stream...");
			}
			catch (Exception e) 
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
				Console.WriteLine("Executing finally block. \n");
			}
		}

		public static void Read()
		{

			string line;
			int totalFiles = 0;

			try
			{
				Console.WriteLine("Begin read operation...");
				StreamReader streamReader = new StreamReader(theFile);

				line = streamReader.ReadLine();
				Console.WriteLine("File read...");

				string[] PathArrayDirty = line.Split(new string[] { rootSeparator }, StringSplitOptions.None);
				Console.WriteLine("File parsed to array...");

				Console.WriteLine("Objects found: \n");

				foreach (string path in PathArrayDirty)
				{
					Console.WriteLine(path);
				}

				// used for length of clean array
				int totalCleanedPaths = 0;

				Console.WriteLine();
				Console.WriteLine("Validating objects... \n");
				for (int i = 0; i < PathArrayDirty.Length; i++)
				{
					Console.WriteLine("Validation criteria: {0}", currentDelimiterStart);
					Console.WriteLine("Checking object validation... ");
					Console.WriteLine("Preview: {0}", PathArrayDirty[i]);
					// cleaning name data away
					if (PathArrayDirty[i].Contains(currentDelimiterStart) == false)
					{
						// set that string object to empty
						PathArrayDirty[i] = string.Empty;
						Console.WriteLine("Object invalidated... ");
						// clean array needs one less position because it wont store PathArrayDirty[i] object
						if (totalCleanedPaths > 0)
						{
							//totalCleanedPaths--;
						}
						if (totalCleanedPaths == 0)
						{
							totalCleanedPaths = 0;
						}
						Console.WriteLine("Total reduced... ");
						Console.WriteLine("Total: {0}... ", totalCleanedPaths);
					}

					if (PathArrayDirty[i].Contains(currentDelimiterStart) == true && PathArrayDirty[i] != string.Empty)
					{
						Console.WriteLine("Object validated... ");
						// we need to account for this object and increase the length of the array
						totalCleanedPaths++;
						Console.WriteLine("Total increased... ");
						Console.WriteLine("Total: {0}... ", totalCleanedPaths);
					}
					Console.WriteLine("Finished object validation... \n");
				}

				Console.WriteLine("All objects validated... \n");


				string[] pathArrayClean = new string[totalCleanedPaths];
				Console.WriteLine("Clean array initialized... \n");

				int indexClean = 0;

				// dirty is looped through completely
				for (int indexDirty = 0; indexDirty < PathArrayDirty.Length; indexDirty++)
				{
					Console.WriteLine("Checking object validation...");
					Console.WriteLine("Preview: {0}", PathArrayDirty[indexDirty]);
					// only increment if string is valid
					if (PathArrayDirty[indexDirty] != string.Empty)
					{
						Console.WriteLine("Object is valid... ");
						pathArrayClean[indexClean] = PathArrayDirty[indexDirty];
						Console.WriteLine("Object copied to clean array... \n");
						indexClean++;
					}
					// skip this object, which we turned to empty previously
					if (PathArrayDirty[indexDirty] == string.Empty)
					{
						Console.WriteLine("Object was invalid and skipped... \n");
						continue;
					}
				}

				Console.WriteLine("Cleaned objects stored in new array... ");


				Console.WriteLine();
				Console.WriteLine("Clean: ");

				foreach(string path in pathArrayClean)
				{
					Console.WriteLine(path);
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
				Console.WriteLine("File successfully parsed and cleaned... \n");
				Console.WriteLine("Nya uwu :3");
			}


		}
	}
}
