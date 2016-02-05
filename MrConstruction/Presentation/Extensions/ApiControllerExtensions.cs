using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MrConstruction.Presentation.Controllers {
    public static class ApiControllerExtensions {

        public static async Task<MultipartFormInfo> ReadFile(this ApiController controller) {

            var Request = controller.Request;

            if (Request.Content.IsMimeMultipartContent()) {
                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);

                await Request.Content.ReadAsMultipartAsync(provider);

                var form = new MultipartFormInfo();

                foreach (MultipartFileData file in provider.FileData) {
                    var mpi = new MultipartFileInfo() {
                        RemoteFileName = file.Headers.ContentDisposition.FileName,
                        FileInfo = new FileInfo(HttpContext.Current.Server.MapPath(file.LocalFileName))
                    };

                    form.Files.Add(mpi);
                }

                foreach (var key in provider.FormData.AllKeys) {
                    form.FormData[key] = provider.FormData.GetValues(key);
                }

                return form;
            }

            return null;
        }

        public class MultipartFormInfo {

            public IList<MultipartFileInfo> Files { get; private set; }

            public IDictionary<string, string[]> FormData { get; private set; }

            public MultipartFormInfo() {
                Files = new List<MultipartFileInfo>();
                FormData = new Dictionary<string, string[]>();
            }
        }

        public class MultipartFileInfo {

            public FileInfo FileInfo { get; set; }

            public string RemoteFileName { get; set; }
        }
    }
}