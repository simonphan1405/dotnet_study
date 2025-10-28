var source = "/Users/hieuphan/Documents/web-development/references/minio_samples/xls and xlsx/file_example_XLS_10.xls";
var dest = "/Users/hieuphan/Documents/web-development/references/minio_samples/copy_file_example_XLS_10.xls";

var buffer = new byte[1024 * 2];
using var instream = File.OpenRead(source);
using var outstream = File.OpenWrite(dest);

int n = instream.Read(buffer, 0, buffer.Length);
while (n > 0)
{
    Console.WriteLine(n.ToString());

    outstream.Write(buffer, 0, n);

    n = instream.Read(buffer, 0, buffer.Length);
}
instream.Close();
outstream.Close(); 