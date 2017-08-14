using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MvcMovie.Models.Database;

namespace MvcMovie.Models.Views
{
    public class CommentViewModel
    {
        public string Text;
        public int MovieID;
    }
}
