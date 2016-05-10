﻿using System;

namespace Microsoft.Build.Logging.StructuredLogger
{
    public class AbstractDiagnostic : TextNode
    {
        public DateTime Timestamp { get; set; }
        public string Code { get; set; }
        public int ColumnNumber { get; set; }
        public int EndColumnNumber { get; set; }
        public int EndLineNumber { get; set; }
        public string File { get; set; }
        public int LineNumber { get; set; }
        public string ProjectFile { get; set; }
        public string Subcategory { get; set; }

        public override string ToString()
        {
            File = File ?? "";

            string position = "";
            if (LineNumber != 0 || ColumnNumber != 0)
            {
                position = $"({LineNumber},{ColumnNumber}):";
            }

            string code = "";
            if (!string.IsNullOrWhiteSpace(Code))
            {
                code = $" {this.GetType().Name.ToLowerInvariant()} {Code}:";
            }

            string text = Text;
            if (File.Length + position.Length + code.Length > 0)
            {
                text = " " + text;
            }

            string projectFile = "";
            if (!string.IsNullOrWhiteSpace(ProjectFile))
            {
                projectFile = $" [{ProjectFile}]";
            }

            return $"{File}{position}{code}{text}{projectFile}";
        }
    }
}
