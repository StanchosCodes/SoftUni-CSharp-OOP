namespace SoftuniLogger.IO
{
    using Interfaces;
    using System.Text;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder sbContent;
        private readonly IFileWriter fileWriter;

        private LogFile()
        {
            this.sbContent = new StringBuilder();
        }
        public LogFile(IFileWriter fileWriter)
            : this()
        {
            this.fileWriter = fileWriter;
        }
        public int Size
            => this.sbContent.Length;

        public string Content
            => this.sbContent.ToString();

        public void SaveAs(string fileName)
        {
            this.fileWriter.WriteContent(this.Content, fileName);
        }

        public void Write(string content)
        {
            this.sbContent.AppendLine(content);
        }
    }
}
