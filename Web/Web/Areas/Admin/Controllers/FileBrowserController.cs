//using System;
//using System.IO;
//using Kendo.Mvc.UI;

//namespace Erzasoft.Web.Areas.Admin.Controllers
//{
//    public class FileBrowserController : EditorFileBrowserController
//    {
//        private const string contentFolderRoot = "~/";
//        private const string prettyName = "Editor/";
//        private static readonly string[] foldersToCopy = new[] { "~/Upload/Editor/" };


//        /// <summary>
//        /// Gets the base paths from which content will be served.
//        /// </summary>
//        public override string ContentPath
//        {
//            get
//            {
//                return CreateUserFolder();
//            }
//        }

//        /// <summary>
//        /// Gets the valid file extensions by which served files will be filtered.
//        /// </summary>
//        public override string Filter
//        {
//            get
//            {
//                return "*.pdf, *.txt, *.doc, *.docx, *.xls, *.xlsx, *.ppt, *.pptx, *.zip, *.rar, *.jpg, *.jpeg, *.gif, *.png";
//            }
//        }

//        private string CreateUserFolder()
//        {
//            var virtualPath = Path.Combine(contentFolderRoot, "Upload", prettyName);

//            var path = Server.MapPath(virtualPath);
//            if (!Directory.Exists(path))
//            {
//                Directory.CreateDirectory(path);
//                foreach (var sourceFolder in foldersToCopy)
//                {
//                    CopyFolder(Server.MapPath(sourceFolder), path);
//                }
//            }
//            return virtualPath;
//        }

//        private void CopyFolder(string source, string destination)
//        {
//            if (!Directory.Exists(destination))
//            {
//                Directory.CreateDirectory(destination);
//            }

//            foreach (var file in Directory.EnumerateFiles(source))
//            {
//                var dest = Path.Combine(destination, Path.GetFileName(file));
//                System.IO.File.Copy(file, dest);
//            }

//            foreach (var folder in Directory.EnumerateDirectories(source))
//            {
//                var dest = Path.Combine(destination, Path.GetFileName(folder));
//                CopyFolder(folder, dest);
//            }
//        }
//    }
//}