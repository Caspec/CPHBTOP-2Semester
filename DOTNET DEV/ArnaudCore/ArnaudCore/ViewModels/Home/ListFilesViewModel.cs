using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArnaudCore.ViewModels.Home
{
    public class ListFilesViewModel
    {
        public IEnumerable<SelectListItem> FilesList { get; private set; }
        public string Directory { get; private set; }

        public ListFilesViewModel(string directory, string[] files)
        {
            Directory = directory;
            FilesList = files.Select(f => new SelectListItem() { Text = f });
        }
    }
}
