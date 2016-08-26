using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Services
{
    public class GenreService
    {
        public const string Classic = "Classic";
        public const string SciFi = "SciFi";
        public const string Comedy = "Comedy";
        public const string Drama = "Drama";
        public const string Action = "Action";

        private List<SelectListItem> genreList;

        public GenreService()
        {
            genreList = new List<SelectListItem>();

            // simulate loading data from datasource
            genreList.Add(new SelectListItem { Text = Classic, Value = Classic });
            genreList.Add(new SelectListItem { Text = SciFi, Value = SciFi });
            genreList.Add(new SelectListItem { Text = Comedy, Value = Comedy });
            genreList.Add(new SelectListItem { Text = Drama, Value = Drama });
            genreList.Add(new SelectListItem { Text = Action, Value = Action });
        }

        public SelectList GetGenres()
        {
            return new SelectList(genreList.OrderBy(x =>x.Text), "Value", "Text");
        }
    }
}
